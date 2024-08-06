using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private DateTime displayedDate; // Ngày hiện tại được hiển thị
        private DateTime endDate; // Ngày kết thúc của khoảng thời gian dự báo
        private int currentDayIndex = 0; // Chỉ số ngày hiện tại
        private string cityName; // Tên thành phố

        // Khởi tạo Form2 với tên thành phố
        public Form2(string cityName)
        {
            InitializeComponent();
            this.cityName = cityName; // Nhận tên thành phố từ Form1
            displayedDate = DateTime.Today; // Ngày bắt đầu là ngày hiện tại
            endDate = displayedDate.AddDays(6); // 7 ngày liên tiếp từ ngày hôm nay
        }

        // Hàm được gọi khi Form2 được tải xong
        private void Form2_Load(object sender, EventArgs e)
        {
            cityNameLabel.Text = $"Thành phố: {cityName}"; // Hiển thị tên thành phố

            UpdateDateDisplay(); // Cập nhật hiển thị ngày hiện tại
            UpdateWeatherList(); // Cập nhật danh sách dự báo thời tiết
        }

        // Cập nhật nhãn hiển thị ngày hiện tại
        private void UpdateDateDisplay()
        {
            currentDateLabel.Text = $"Date: {displayedDate.ToString("dd / MMM / yyyy")} ({displayedDate.DayOfWeek})";
        }

        // Cập nhật danh sách dự báo thời tiết
        private async void UpdateWeatherList()
        {
            weatherFlowLayoutPanel.Controls.Clear(); // Xóa tất cả các điều khiển cũ
            await GetWeatherForecast(displayedDate); // Lấy dự báo thời tiết cho ngày hiện tại
        }

        // Xử lý sự kiện khi nhấn nút "Ngày tiếp theo"
        private void nextDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate < endDate) // Nếu ngày hiện tại nhỏ hơn ngày kết thúc
            {
                displayedDate = displayedDate.AddDays(1); // Tăng ngày hiện tại lên 1 ngày
                currentDayIndex++; // Tăng chỉ số ngày hiện tại
                UpdateDateDisplay(); // Cập nhật hiển thị ngày hiện tại
                UpdateWeatherList(); // Cập nhật danh sách dự báo thời tiết
            }
        }

        // Xử lý sự kiện khi nhấn nút "Ngày trước"
        private void previousDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate > DateTime.Today) // Nếu ngày hiện tại lớn hơn ngày hôm nay
            {
                displayedDate = displayedDate.AddDays(-1); // Giảm ngày hiện tại đi 1 ngày
                currentDayIndex--; // Giảm chỉ số ngày hiện tại
                UpdateDateDisplay(); // Cập nhật hiển thị ngày hiện tại
                UpdateWeatherList(); // Cập nhật danh sách dự báo thời tiết
            }
        }

        // Lấy dự báo thời tiết từ API và cập nhật giao diện
        private async Task GetWeatherForecast(DateTime date)
        {
            string apiKey = "62800263f5dd019d92880a8782a73dab"; // Khóa API của OpenWeatherMap
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}"; // URL của API

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url); // Gửi yêu cầu GET
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync(); // Đọc nội dung phản hồi
                    JObject forecastData = JObject.Parse(responseBody); // Phân tích JSON
                    JArray forecastList = (JArray)forecastData["list"]; // Danh sách dự đoán thời tiết

                    // Tạo một nhóm dữ liệu dự đoán theo giờ
                    foreach (JObject forecast in forecastList)
                    {
                        DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString()); // Thời gian dự đoán
                        if (forecastTime.Date == date.Date) // Nếu dự đoán là cho ngày hiện tại
                        {
                            double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15; // Chuyển đổi từ Kelvin sang Celsius
                            string weatherDescription = forecast["weather"][0]["description"].ToString(); // Mô tả thời tiết
                            string iconCode = forecast["weather"][0]["icon"].ToString(); // Lấy mã icon

                            // Tạo URL cho biểu tượng thời tiết
                            string iconUrl = $"https://openweathermap.org/img/wn/{iconCode}.png";

                            // Tạo và thêm khung giờ vào FlowLayoutPanel
                            CreateWeatherPanelForHour(forecastTime, temperature, weatherDescription, iconUrl);
                        }
                    }

                    // Nếu không có dữ liệu dự đoán cho ngày hiện tại
                    if (weatherFlowLayoutPanel.Controls.Count == 0)
                    {
                        Label noDataLabel = new Label
                        {
                            Text = "Không có dự báo thời tiết cho ngày này.",
                            AutoSize = true,
                            ForeColor = Color.Red
                        };
                        weatherFlowLayoutPanel.Controls.Add(noDataLabel); // Thêm thông báo không có dữ liệu vào FlowLayoutPanel
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thành phố hoặc có lỗi xảy ra."); // Hiển thị thông báo lỗi
                }
            }
        }

        // Tạo một FlowLayoutPanel cho mỗi khung giờ và thêm vào weatherFlowLayoutPanel
        private async void CreateWeatherPanelForHour(DateTime forecastTime, double temperature, string weatherDescription, string iconUrl)
        {
            // Tạo PictureBox cho biểu tượng thời tiết
            PictureBox weatherIconBox = new PictureBox
            {
                Size = new Size(50, 50), // Kích thước của biểu tượng
                SizeMode = PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.None // Căn giữa hình ảnh
            };

            // Tạo Label cho thông tin thời tiết
            Label weatherInfoLabel = new Label
            {
                Width = 170,
                Height = 80,
                Margin = new Padding(4),
                Text = $"{forecastTime.ToString("HH:mm")}\nNhiệt độ: {temperature:F1}°C\nMô tả: {weatherDescription}",
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightBlue
            };

            // Tạo FlowLayoutPanel cho mỗi khung giờ
            FlowLayoutPanel hourPanel = new FlowLayoutPanel
            {
                Width = 180, // Chiều rộng của mỗi panel
                Height = 160,
                Margin = new Padding(5, 5, 0, 5),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BorderStyle= BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(173, 216, 230)
            };

            // Thêm PictureBox và Label vào FlowLayoutPanel
            hourPanel.Controls.Add(weatherIconBox);
            hourPanel.Controls.Add(weatherInfoLabel);

            // Thêm FlowLayoutPanel vào weatherFlowLayoutPanel
            weatherFlowLayoutPanel.Controls.Add(hourPanel);

            // Tải hình ảnh từ URL
            try
            {
                using (HttpClient imageClient = new HttpClient())
                {
                    var imageBytes = await imageClient.GetByteArrayAsync(iconUrl); // Tải hình ảnh từ URL
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        weatherIconBox.Image = Image.FromStream(ms); // Gán hình ảnh cho PictureBox
                    }
                }
            }
            catch (Exception)
            {
                weatherIconBox.Image = null; // Hiển thị hình ảnh mặc định nếu có lỗi
            }
        }

        // Xử lý sự kiện khi nhấn nút "Quay lại"
        private void backButton_Click(object sender, EventArgs e)
        {
            // Đóng Form2 và hiển thị Form1
            this.Close();
        }
    }
}
