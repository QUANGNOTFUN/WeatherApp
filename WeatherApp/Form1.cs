using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
            string cityName = cityTextBox.Text;
            if (!string.IsNullOrEmpty(cityName))
            {
                await GetWeatherForecast(cityName);
            }
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
                    DateTime endDay = today.AddDays(3);  // Ngày kết thúc
                    HashSet<DateTime> displayedDates = new HashSet<DateTime>();

                    foreach (JObject forecast in forecastList)
                    {
                        DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString());

                        // Kiểm tra xem dự đoán có nằm trong khoảng từ hôm nay đến ba ngày tới không
                        if (forecastTime.Date >= today && forecastTime.Date <= endDay)
                        {
                            if (!displayedDates.Contains(forecastTime.Date))
                            {
                                double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15;
                                string weatherDescription = forecast["weather"][0]["description"].ToString();

                                weatherListBox.Items.Add($"Ngày {forecastTime.ToShortDateString()}:");
                                weatherListBox.Items.Add($"Nhiệt độ: {temperature:F1}°C");
                                weatherListBox.Items.Add($"Mô tả thời tiết: {weatherDescription}");
                                weatherListBox.Items.Add("");

                                displayedDates.Add(forecastTime.Date);
                            }

                            // Dừng vòng lặp khi đã hiển thị đủ 4 ngày
                            if (displayedDates.Count >= 4)
                                break;
                        }
                    }

                    if (displayedDates.Count == 0)
                    {
                        weatherListBox.Items.Add("Không có dự đoán thời tiết nào.");
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
            string cityName = cityTextBox.Text;
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
