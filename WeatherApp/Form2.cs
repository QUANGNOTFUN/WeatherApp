using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private DateTime displayedDate; // Ngày hiện tại được hiển thị
        private DateTime endDate; // Ngày kết thúc của khoảng thời gian dự báo
        private string cityName; // Tên thành phố

        private bool isUpdating; // Biến kiểm soát việc cập nhật dữ liệu
        private CancellationTokenSource cts; // Biến quản lý hủy yêu cầu HTTP

        // Từ điển dịch mô tả thời tiết từ tiếng Anh sang tiếng Việt
        private Dictionary<string, string> weatherDescriptions = new Dictionary<string, string>
        {
            {"clear sky", "Trời quang"},
            {"few clouds", "Ít mây"},
            {"scattered clouds", "Mây rải rác"},
            {"broken clouds", "Mây nhiều"},
            {"shower rain", "Mưa rào"},
            {"rain", "Mưa"},
            {"thunderstorm", "Dông"},
            {"snow", "Tuyết"},
            {"mist", "Sương mù"},
            {"light rain", "Mưa nhẹ"},
            {"overcast clouds", "Mây u ám"}
            // Thêm các mô tả khác nếu cần
        };

        // Constructor của Form2, khởi tạo các thuộc tính và đăng ký các sự kiện
        public Form2(string cityName)
        {
            InitializeComponent();
            this.cityName = cityName; // Nhận tên thành phố từ Form1
            displayedDate = DateTime.Today; // Ngày bắt đầu là ngày hiện tại
            endDate = displayedDate.AddDays(6); // 7 ngày liên tiếp từ ngày hôm nay

            // Đặt thuộc tính DoubleBuffered để giảm nhấp nháy
            this.DoubleBuffered = true;

            // Đăng ký sự kiện Paint và Resize
            this.Paint += new PaintEventHandler(Form2_Paint);
            this.Resize += new EventHandler(Form2_Resize);

            isUpdating = false; // Khởi tạo biến kiểm soát
            cts = new CancellationTokenSource(); // Khởi tạo CancellationTokenSource
        }

        // Sự kiện Load của Form2, thiết lập kích thước và vị trí của Form, cập nhật hiển thị ngày và danh sách thời tiết
        private void Form2_Load(object sender, EventArgs e)
        {
            var screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Size = new Size((int)(screenSize.Width * 0.9), (int)(screenSize.Height * 0.9));
            this.StartPosition = FormStartPosition.Manual;

            cityNameLabel.Text = $"Thành phố: {cityName}";

            UpdateDateDisplay();
            UpdateWeatherList();

            this.Invalidate(); // Yêu cầu vẽ lại để áp dụng gradient nền

            Form2_Resize(this, EventArgs.Empty); // Cập nhật kích thước và vị trí các điều khiển
        }

        // Cập nhật nhãn hiển thị ngày
        private void UpdateDateDisplay()
        {
            currentDateLabel.Text = $"Ngày: {displayedDate:dd/MM/yyyy} ({displayedDate.DayOfWeek})";
        }

        // Cập nhật danh sách thời tiết, hủy bỏ các yêu cầu cũ và lấy dữ liệu mới
        private async void UpdateWeatherList()
        {
            if (isUpdating)
                return; // Nếu đang cập nhật, không thực hiện thêm thao tác nào khác

            isUpdating = true; // Bắt đầu cập nhật dữ liệu

            // Tạm dừng cập nhật giao diện người dùng
            this.SuspendLayout();

            // Xóa tất cả các khung thời tiết cũ từ form
            var controlsToRemove = new List<Control>();
            foreach (Control control in this.Controls)
            {
                if (control is Panel && control != cityNameLabel && control != currentDateLabel && control != nextDayButton && control != previousDayButton && control != backButton)
                {
                    controlsToRemove.Add(control);
                }
            }

            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

            // Hủy yêu cầu trước nếu có
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();

            await GetWeatherForecast(displayedDate, cts.Token);

            // Tiếp tục cập nhật giao diện người dùng
            this.ResumeLayout();

            isUpdating = false; // Kết thúc cập nhật dữ liệu
        }

        // Xử lý sự kiện khi nhấn nút "Ngày kế tiếp"
        private void nextDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate < endDate)
            {
                displayedDate = displayedDate.AddDays(1);
                UpdateDateDisplay();
                UpdateWeatherList();
            }
        }

        // Xử lý sự kiện khi nhấn nút "Ngày trước"
        private void previousDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate > DateTime.Today)
            {
                displayedDate = displayedDate.AddDays(-1);
                UpdateDateDisplay();
                UpdateWeatherList();
            }
        }

        // Lấy dự báo thời tiết từ API, phân tích dữ liệu và tạo các bảng hiển thị dự báo
        private async Task GetWeatherForecast(DateTime date, CancellationToken token)
        {
            string apiKey = "62800263f5dd019d92880a8782a73dab";
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url, token);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject forecastData = JObject.Parse(responseBody);
                        JArray forecastList = (JArray)forecastData["list"];

                        int panelTop = 60;
                        int panelLeft = 20;
                        int panelWidth = (this.ClientSize.Width / 4) - 30;
                        int panelHeight = 200;

                        foreach (JObject forecast in forecastList)
                        {
                            token.ThrowIfCancellationRequested(); // Kiểm tra nếu yêu cầu đã bị hủy

                            DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString());
                            if (forecastTime.Date == date.Date)
                            {
                                double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15;
                                double humidity = double.Parse(forecast["main"]["humidity"].ToString());
                                double windSpeed = double.Parse(forecast["wind"]["speed"].ToString());
                                double pressure = double.Parse(forecast["main"]["pressure"].ToString());
                                string weatherDescription = forecast["weather"][0]["description"].ToString();
                                string iconCode = forecast["weather"][0]["icon"].ToString();

                                string weatherDescriptionInVietnamese = weatherDescriptions.ContainsKey(weatherDescription) ? weatherDescriptions[weatherDescription] : weatherDescription;

                                CreateWeatherPanelForHour(forecastTime, temperature, humidity, windSpeed, pressure, weatherDescriptionInVietnamese, iconCode, ref panelTop, ref panelLeft, panelWidth, panelHeight);
                            }
                        }

                        // Nếu không có dự báo cho ngày này, hiển thị thông báo
                        if (this.Controls.Count == 4)
                        {
                            Label noDataLabel = new Label
                            {
                                Text = "Không có dự báo thời tiết cho ngày này.",
                                AutoSize = true,
                                ForeColor = Color.Red,
                                Font = new Font("Arial", 12, FontStyle.Bold),
                                TextAlign = ContentAlignment.MiddleCenter,
                                Top = 60,
                                Left = (this.ClientSize.Width - 250) / 2
                            };
                            this.Controls.Add(noDataLabel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thành phố hoặc có lỗi xảy ra.");
                    }
                }
                catch (OperationCanceledException)
                {
                    // Xử lý khi yêu cầu bị hủy
                }
            }
        }

        // Tạo các bảng hiển thị dự báo thời tiết cho từng giờ
        private void CreateWeatherPanelForHour(DateTime forecastTime, double temperature, double humidity, double windSpeed, double pressure, string weatherDescription, string iconCode, ref int panelTop, ref int panelLeft, int panelWidth, int panelHeight)
        {
            PictureBox weatherIcon = new PictureBox
            {
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = $"https://openweathermap.org/img/wn/{iconCode}@2x.png",
                BackColor = Color.Transparent
            };

            Label weatherInfoLabel = new Label
            {
                Width = panelWidth - 20,
                Height = 100,
                Margin = new Padding(4),
                Text = $"{forecastTime:HH:mm}\nNhiệt độ: {temperature:F1}°C\nĐộ ẩm: {humidity}%\nGió: {windSpeed} m/s\nÁp suất: {pressure} hPa\nMô tả: {weatherDescription}",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Panel hourPanel = new Panel
            {
                Width = panelWidth,
                Height = panelHeight,
                AutoSize = true,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Top = panelTop,
                Left = panelLeft
            };

            hourPanel.Controls.Add(weatherIcon);
            hourPanel.Controls.Add(weatherInfoLabel);

            weatherIcon.Top = 10;
            weatherIcon.Left = (hourPanel.Width - weatherIcon.Width) / 2;
            weatherInfoLabel.Top = weatherIcon.Bottom + 10;
            weatherInfoLabel.Left = 10;

            this.Controls.Add(hourPanel);

            panelLeft += panelWidth + 10;

            // Nếu bảng dự báo vượt quá chiều rộng của form, chuyển sang hàng mới
            if (panelLeft + panelWidth > this.ClientSize.Width)
            {
                panelLeft = 20;
                panelTop += panelHeight + 20;
            }
        }

        // Sự kiện vẽ nền gradient cho Form
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.LightSkyBlue,
                Color.LightSteelBlue,
                LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        // Sự kiện thay đổi kích thước Form, cập nhật vị trí và kích thước các điều khiển
        private void Form2_Resize(object sender, EventArgs e)
        {
            cityNameLabel.Top = 10; // Đặt vị trí của nhãn tên thành phố (cityNameLabel) cách trên cùng 10 pixel
            cityNameLabel.Left = (this.ClientSize.Width - cityNameLabel.Width) / 2; // Đặt nhãn tên thành phố ở giữa form

            currentDateLabel.Top = cityNameLabel.Bottom + 10; // Đặt vị trí của nhãn hiển thị ngày hiện tại (currentDateLabel) cách nhãn tên thành phố 10 pixel
            currentDateLabel.Left = (this.ClientSize.Width - currentDateLabel.Width) / 2; // Đặt nhãn hiển thị ngày hiện tại ở giữa form

            nextDayButton.Top = this.ClientSize.Height - nextDayButton.Height - 50; // Đặt vị trí của nút "Ngày kế tiếp" cách đáy form 50 pixel
            nextDayButton.Left = this.ClientSize.Width / 2 + 10; // Đặt nút "Ngày kế tiếp" ở bên phải của trung tâm form 10 pixel

            previousDayButton.Top = this.ClientSize.Height - previousDayButton.Height - 50; // Đặt vị trí của nút "Ngày trước" cách đáy form 50 pixel
            previousDayButton.Left = this.ClientSize.Width / 2 - previousDayButton.Width - 10; // Đặt nút "Ngày trước" ở bên trái của trung tâm form 10 pixel

            backButton.Top = this.ClientSize.Height - backButton.Height - 10; // Đặt vị trí của nút "Trở lại" cách đáy form 10 pixel
            backButton.Left = (this.ClientSize.Width - backButton.Width) / 2; // Đặt nút "Trở lại" ở giữa form

            nextDayButton.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt phông chữ cho nút "Ngày kế tiếp" với kích thước 12 và kiểu chữ đậm
            previousDayButton.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt phông chữ cho nút "Ngày trước" với kích thước 12 và kiểu chữ đậm
            backButton.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt phông chữ cho nút "Trở lại" với kích thước 12 và kiểu chữ đậm

            nextDayButton.ForeColor = Color.White; // Đặt màu chữ của nút "Ngày kế tiếp" thành màu trắng
            previousDayButton.ForeColor = Color.White; // Đặt màu chữ của nút "Ngày trước" thành màu trắng
            backButton.ForeColor = Color.White; // Đặt màu chữ của nút "Trở lại" thành màu trắng

            nextDayButton.BackColor = Color.DodgerBlue; // Đặt màu nền của nút "Ngày kế tiếp" thành màu xanh DodgerBlue
            previousDayButton.BackColor = Color.DodgerBlue; // Đặt màu nền của nút "Ngày trước" thành màu xanh DodgerBlue
            backButton.BackColor = Color.DodgerBlue; // Đặt màu nền của nút "Trở lại" thành màu xanh DodgerBlue
        }

        // Xử lý sự kiện khi nhấn nút "Trở lại", đóng Form hiện tại
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
