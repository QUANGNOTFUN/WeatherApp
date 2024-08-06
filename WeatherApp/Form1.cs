using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void searchButton_Click(object sender, EventArgs e)
        {
            // Lấy tên thành phố được chọn từ ComboBox
            string selectedCity = cityComboBox.SelectedItem?.ToString(); ;
            if (!string.IsNullOrEmpty(selectedCity))
            {
                await GetWeatherForecast(selectedCity);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thành phố từ danh sách.");
            }
        }

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
        }

        private async Task GetWeatherForecast(string cityName)
        {
            string apiKey = "62800263f5dd019d92880a8782a73dab";
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={cityName}&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject forecastData = JObject.Parse(responseBody);
                    JArray forecastList = (JArray)forecastData["list"];

                    weatherListBox.Items.Clear();
                    DateTime today = DateTime.Now.Date;
                    bool todayForecastFound = false;

                    foreach (JObject forecast in forecastList)
                    {
                        DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString());

                        // Kiểm tra xem dự đoán có phải là hôm nay không
                        if (forecastTime.Date == today)
                        {
                            double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15;
                            string weatherDescription = forecast["weather"][0]["description"].ToString();
                            string weatherIconCode = forecast["weather"][0]["icon"].ToString();
                            double humidity = double.Parse(forecast["main"]["humidity"].ToString());
                            double pressure = double.Parse(forecast["main"]["pressure"].ToString());
                            double windSpeed = double.Parse(forecast["wind"]["speed"].ToString());

                            // Cập nhật thông tin thời tiết cho ngày hôm nay
                            weatherListBox.Items.Add($"Ngày hôm nay:");
                            weatherListBox.Items.Add($"Nhiệt độ: {temperature:F1}°C");
                            weatherListBox.Items.Add($"Mô tả thời tiết: {weatherDescription}");
                            weatherListBox.Items.Add($"Độ ẩm: {humidity:F1}%");
                            weatherListBox.Items.Add($"Áp suất khí quyển: {pressure} hPa");
                            weatherListBox.Items.Add($"Tốc độ gió: {windSpeed:F1} m/s");

                            // Cập nhật hình ảnh thời tiết
                            string iconUrl = $"http://openweathermap.org/img/wn/{weatherIconCode}.png";
                            using (HttpClient iconClient = new HttpClient())
                            {
                                byte[] iconData = await iconClient.GetByteArrayAsync(iconUrl);
                                using (MemoryStream ms = new MemoryStream(iconData))
                                {
                                    picIcon.Image = Image.FromStream(ms);
                                }
                            }

                            todayForecastFound = true;
                            break; // Ngừng vòng lặp khi đã hiển thị thông tin cho ngày hôm nay
                        }
                    }

                    if (!todayForecastFound)
                    {
                        weatherListBox.Items.Add("Không có dự đoán thời tiết cho ngày hôm nay.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thành phố hoặc có lỗi xảy ra.");
                }
            }
        }

        private void detailsButton_Click(object sender, EventArgs e)
        {
            string cityName = cityComboBox.SelectedItem?.ToString(); ;
            if (!string.IsNullOrEmpty(cityName))
            {
                // Khởi tạo Form2 và truyền tên thành phố
                Form2 form2 = new Form2(cityName);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên thành phố.");
            }
        }
    }
}
