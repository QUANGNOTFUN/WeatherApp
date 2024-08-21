using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private string selectedCity; // Biến lưu giá trị thành phố được chọn
        private ComboBox cityComboBox; // ComboBox để chọn thành phố

        public Form1()
        {
            InitializeComponent();

            // Đổi font chữ cho toàn bộ form mà không đổi FontWeight
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("Tahoma", control.Font.Size, control.Font.Style);
            }

            // Khởi tạo ComboBox
            cityComboBox = new ComboBox
            {
                Location = new Point(458, 52), // Điều chỉnh vị trí theo ý muốn
                Size = new Size(250, 40), // Điều chỉnh kích thước theo ý muốn
                Font = new Font("Microsoft Sans Serif", 14.4F),
                ForeColor = Color.FromArgb(33, 150, 243),
                BackColor = Color.FromArgb(248, 248, 248)
            };
            this.Controls.Add(cityComboBox);

            // Thiết lập tính năng tự động hoàn thành cho ComboBox
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(cities);
            cityComboBox.AutoCompleteCustomSource = autoComplete;
            cityComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cityComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Đăng ký sự kiện cho ComboBox
            cityComboBox.SelectedIndexChanged += CityComboBox_SelectedIndexChanged;

            // Đăng ký sự kiện Paint để vẽ gradient background
            this.Paint += Form1_Paint;
        }

        // combo box


        private async void searchButton_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string cityToSearch = cityComboBox.SelectedItem?.ToString();

            // Kiểm tra xem có giá trị thành phố không
            if (!string.IsNullOrEmpty(cityToSearch))
            {
                label2.Visible = true;
                label7.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label4.Visible = true;
                using (CancellationTokenSource cts = new CancellationTokenSource())
                {
                    try
                    {
                        await GetWeatherForecast(cityToSearch, cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Yêu cầu bị hủy.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thành phố từ danh sách.");
            }
        }

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
            {"moderate rain", "Mưa vừa"},
            {"overcast clouds", "Mây u ám"}
        };


        private string[] cities = new string[]
        {
            "An Giang", "Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu",
            "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Tỉnh Bình Phước",
            "Tỉnh Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng",
            "Tỉnh Ðắc Lắk", "Ðăc Nông", "Điện Biên Phủ", "Tỉnh Ðồng Nai", "Tỉnh Ðồng Tháp",
            "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh",
            "Tỉnh Hải Dương", "Hải Phòng", "Hau Giang", "Hòa Bình", "Hưng Yên",
            "Khánh Hòa", "Tỉnh Kiến Giang", "Kon Tum", "Lai Châu", "Da Lat",
            "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Tỉnh Nghệ An",
            "Ninh Bình", "Tỉnh Ninh Thuận", "Phú Thọ", "Tỉnh Phú Yên", "Tỉnh Quảng Bình",
            "Tỉnh Quảng Nam", "Quảng Ngãi", "Tỉnh Quảng Ninh", "Quảng Trị", "Sóc Trăng",
            "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa",
            "Huế", "Tỉnh Tiền Giang", "Thành phố Hồ Chí Minh", "Trà Vinh", "Tuyên Quang",
            "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
        };

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo Timer
            Create_DayAndHours();

            // Khởi tạo danh sách ban đầu cho ComboBox
            cityComboBox.Items.AddRange(cities);

                // Gọi phương thức để tìm kiếm thời tiết cho thành phố mặc định
                await SearchWeatherForDefaultCity();

            // Cập nhật ngày và giờ
            timer.Start(); // Bắt đầu Timer
        }

        private async Task SearchWeatherForDefaultCity()
        {
            string cityToSearch = cityComboBox.SelectedItem?.ToString();

            // Kiểm tra xem có giá trị thành phố không
            if (!string.IsNullOrEmpty(cityToSearch))
            {
                // Kiểm tra nếu yêu cầu đã bị hủy
                using (CancellationTokenSource cts = new CancellationTokenSource())
                {
                    try
                    {
                        await GetWeatherForecast(cityToSearch, cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        MessageBox.Show("Yêu cầu bị hủy.");
                    }
                }
            }
        }



        public void Create_DayAndHours()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;

            // chỉnh vị trí
            day.Location = new Point(10, 10);
            hours.Location = new Point(10, 40);
            
            // chỉnh màu
            day.ForeColor = Color.FromArgb(90, 118, 132);
            hours.ForeColor = Color.FromArgb(90, 118, 132);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật giờ trong Label
            day.Text = $"Ngày: {DateTime.Now.ToString("dd/MM/yyyy")}";
            hours.Text = $"Giờ: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật giá trị thành phố được chọn
            selectedCity = cityComboBox.SelectedItem?.ToString();

        }

        // chỉnh màu thuộc tính thời tiết
        private void SetLabelTextColor(Color color)
        {
            // màu
            Temp.ForeColor = color;
            Dcr.ForeColor = color;
            humid.ForeColor = color;
            Prs.ForeColor = color;
            wind.ForeColor = color;
            rain.ForeColor = color;
            gust.ForeColor = color;
            // size
            int size = 20;
            Temp.Font = new Font(Temp.Font.FontFamily, size);
            Dcr.Font = new Font(Dcr.Font.FontFamily, size);
            humid.Font = new Font(humid.Font.FontFamily, size);
            Prs.Font = new Font(Prs.Font.FontFamily, size);
            wind.Font = new Font(wind.Font.FontFamily, size);
            rain.Font = new Font(rain.Font.FontFamily, size);
            gust.Font = new Font(gust.Font.FontFamily, size);

        }


        private async Task GetWeatherForecast(string cityName, CancellationToken token)
        {
            string apiKey = "62800263f5dd019d92880a8782a73dab";
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={Uri.EscapeDataString(cityName)}&appid={apiKey}";

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

                        DateTime today = DateTime.Now.Date;
                        bool todayForecastFound = false;

                        foreach (JObject forecast in forecastList)
                        {
                            token.ThrowIfCancellationRequested(); // Kiểm tra nếu yêu cầu đã bị hủy

                            DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString());
                            if (forecastTime.Date == today)
                            {
                                double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15;
                                double humidity = double.Parse(forecast["main"]["humidity"].ToString());
                                double windSpeed = double.Parse(forecast["wind"]["speed"].ToString());
                                double pressure = double.Parse(forecast["main"]["pressure"].ToString());
                                double gustSpeed = forecast["wind"].SelectToken("gust") != null
                                    ? double.Parse(forecast["wind"]["gust"].ToString())
                                    : 0.0; // Giá trị gió giật, nếu có

                                // Lượng mưa
                                double rainAmount = forecast["rain"] != null
                                    ? (forecast["rain"]["3h"] != null
                                        ? double.Parse(forecast["rain"]["3h"].ToString())
                                        : 0.0)
                                    : 0.0;

                                string weatherDescription = forecast["weather"][0]["description"].ToString();
                                string weatherDescriptionInVietnamese = weatherDescriptions.ContainsKey(weatherDescription)
                                    ? weatherDescriptions[weatherDescription]
                                    : weatherDescription;
                                string weatherIconCode = forecast["weather"][0]["icon"].ToString();

                                // Cập nhật thông tin thời tiết vào Label
                                Temp.Text = $"{temperature:F1}°C";
                                Dcr.Text = $"{weatherDescriptionInVietnamese}";
                                humid.Text = $"{humidity:F1}%";
                                Prs.Text = $"{pressure} hPa";
                                wind.Text = $"{windSpeed:F1} m/s";
                                rain.Text = $"{rainAmount:F1} mm";
                                gust.Text = $"{gustSpeed:F1} m/s";

                                // Thay đổi màu chữ cho tất cả các Label
                                SetLabelTextColor(Color.FromArgb(70, 130, 180));

                                // Thiết lập vị trí của các Label
                                Temp.Location = new Point(300, 390);
                                Dcr.Location = new Point(120, 390);
                                humid.Location = new Point(750, 240); // Đặt vị trí cho humid
                                Prs.Location = new Point(750, 290);   // Đặt vị trí cho Prs
                                wind.Location = new Point(750, 340);  // Đặt vị trí cho wind
                                rain.Location = new Point(750, 390);  // Đặt vị trí cho rain
                                gust.Location = new Point(750, 440);  // Đặt vị trí cho gust

                                // Cập nhật hình ảnh thời tiết
                                string iconUrl = $"http://openweathermap.org/img/wn/{weatherIconCode}@4x.png";
                                using (HttpClient iconClient = new HttpClient())
                                {
                                    byte[] iconData = await iconClient.GetByteArrayAsync(iconUrl);
                                    using (MemoryStream ms = new MemoryStream(iconData))
                                    {
                                        Image originalImage = Image.FromStream(ms);
                                        Image resizedImage = new Bitmap(originalImage, new Size(220, 180)); // Thay đổi kích thước hình ảnh
                                        picIcon.Image = resizedImage;
                                    }
                                }

                                todayForecastFound = true;
                                break; // Ngừng vòng lặp khi đã hiển thị thông tin cho ngày hôm nay
                            }
                        }

                        // Nếu không có dự báo cho ngày hôm nay, hiển thị thông báo
                        if (!todayForecastFound)
                        {
                            Label noDataLabel = new Label
                            {
                                Text = "Không có dự báo thời tiết cho ngày hôm nay.",
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
                    MessageBox.Show("Yêu cầu bị hủy.");
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khác
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }


        // Phương thức vẽ gradient background
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Định nghĩa màu sắc cho gradient nền
            Color topLeftColor = Color.FromArgb(255, 140, 66); // Màu vàng ở góc trên bên trái
            Color middleColor = Color.FromArgb(237, 192, 44);     // Màu trung gian
            Color bottomRightColor = Color.FromArgb(252, 228, 150); // Màu ở góc dưới bên phải

            // Vẽ phần tư hình tròn màu vàng ở góc trên bên trái
            int sunRadius = 150; // Bán kính của phần tư hình tròn
            Rectangle sunRect = new Rectangle(0, 0, sunRadius * 2, sunRadius * 2);
            using (SolidBrush sunBrush = new SolidBrush(topLeftColor))
            {
                e.Graphics.FillPie(sunBrush, sunRect, 0, 90); // Vẽ phần tư hình tròn
            }

            // Tạo LinearGradientBrush cho gradient nền
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                topLeftColor,
                bottomRightColor,
                LinearGradientMode.ForwardDiagonal))
            {
                // Tạo một blend để sử dụng màu trung gian
                Blend blend = new Blend
                {
                    Factors = new float[] { 0.0f, 0.6f, 1.0f }, // Tỷ lệ màu sắc
                    Positions = new float[] { 0.0f, 0.3f, 1.0f } // Vị trí của các màu
                };
                brush.Blend = blend;
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedCity))
            {
                // Khởi tạo Form2 và truyền tên thành phố
                Form2 form2 = new Form2(selectedCity);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thành phố từ danh sách.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedCity))
            {
                // Tạo và mở Form3 với danh sách các thành phố lân cận
                Form3 form3 = new Form3(selectedCity);
                form3.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thành phố từ danh sách.");
            }
        }
    }
}
