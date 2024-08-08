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
            // Khởi tạo ComboBox
            cityComboBox = new ComboBox();
            cityComboBox.Location = new Point(458, 52); // Điều chỉnh vị trí theo ý muốn
            cityComboBox.Size = new Size(224, 24); // Điều chỉnh kích thước theo ý muốn
            cityComboBox.Font = new Font("Microsoft Sans Serif", 13.8F); // Thiết lập font
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

        private async void searchButton_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox
            string cityToSearch = cityComboBox.SelectedItem?.ToString();

            // Kiểm tra xem có giá trị thành phố không
            if (!string.IsNullOrEmpty(cityToSearch))
            {
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
            {"overcast clouds", "Mây u ám"}
            // Thêm các mô tả khác nếu cần
        };

        private string[] cities = new string[]
        {
            "An Giang", "Bà Rịa - Vũng Tàu", "Bắc Giang", "Bắc Kạn", "Bạc Liêu",
            "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước",
            "Bình Thuận", "Cà Mau", "Cần Thơ", "Cao Bằng", "Đà Nẵng",
            "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp",
            "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh",
            "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hưng Yên",
            "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu", "Lâm Đồng",
            "Lạng Sơn", "Lào Cai", "Long An", "Nam Định", "Nghệ An",
            "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên", "Quảng Bình",
            "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị", "Sóc Trăng",
            "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa",
            "Thừa Thiên Huế", "Tiền Giang", "TP. Hồ Chí Minh", "Trà Vinh", "Tuyên Quang",
            "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo danh sách ban đầu cho ComboBox
            cityComboBox.Items.AddRange(cities);

            // Khởi tạo Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Cập nhật mỗi giây
            timer.Tick += Timer_Tick;
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật giá trị thành phố được chọn
            selectedCity = cityComboBox.SelectedItem?.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật giờ trong Label
            hours.Text = $"Giờ: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private async Task GetWeatherForecast(string cityName, CancellationToken token)
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
                                Dcr.Text = $" {weatherDescriptionInVietnamese}";
                                humid.Text = $" {humidity:F1}%";
                                Prs.Text = $" {pressure} hPa";
                                wind.Text = $"{windSpeed:F1} m/s";
                                rain.Text = $"Lượng mưa: {rainAmount:F1} mm";
                                gust.Text = $" {gustSpeed:F1} m/s";

                                // Cập nhật ngày và giờ
                                day.Text = $"Ngày: {DateTime.Now.ToString("dd/MM/yyyy")}";
                                timer.Start(); // Bắt đầu Timer

                                // Cập nhật hình ảnh thời tiết
                                string iconUrl = $"http://openweathermap.org/img/wn/{weatherIconCode}@2x.png";
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

        // Phương thức vẽ gradient background
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.LightSkyBlue, // Màu bắt đầu gradient
                Color.SkyBlue,     // Màu kết thúc gradient
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
