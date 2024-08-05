using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public partial class Form2 : Form
    {
        private DateTime displayedDate;
        private DateTime endDate;
        private int currentDayIndex = 0;
        private string cityName;

        public Form2(string cityName)
        {
            InitializeComponent();
            this.cityName = cityName; // Nhận tên thành phố từ Form1
            displayedDate = DateTime.Today;
            endDate = displayedDate.AddDays(6); // 7 ngày liên tiếp từ ngày hôm nay
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cityNameLabel.Text = $"Thành phố: {cityName}";

            UpdateDateDisplay();
            UpdateWeatherList();
        }

        private void UpdateDateDisplay()
        {
            currentDateLabel.Text = $"Date: {displayedDate.ToString("dd / MMM / yyyy")} ({displayedDate.DayOfWeek})";
        }

        private async void UpdateWeatherList()
        {
            weatherListBox.Items.Clear();
            await GetWeatherForecast(displayedDate);
        }

        private void nextDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate < endDate)
            {
                displayedDate = displayedDate.AddDays(1);
                currentDayIndex++;
                UpdateDateDisplay();
                UpdateWeatherList();
            }
        }

        private void previousDayButton_Click(object sender, EventArgs e)
        {
            if (displayedDate > DateTime.Today)
            {
                displayedDate = displayedDate.AddDays(-1);
                currentDayIndex--;
                UpdateDateDisplay();
                UpdateWeatherList();
            }
        }

        private async Task GetWeatherForecast(DateTime date)
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

                    foreach (JObject forecast in forecastList)
                    {
                        DateTime forecastTime = DateTime.Parse(forecast["dt_txt"].ToString());
                        if (forecastTime.Date == date.Date)
                        {
                            double temperature = double.Parse(forecast["main"]["temp"].ToString()) - 273.15;
                            string weatherDescription = forecast["weather"][0]["description"].ToString();

                            weatherListBox.Items.Add($"{forecastTime.ToString("HH:mm")} - {temperature:F1}°C - {weatherDescription}");
                        }
                    }

                    if (weatherListBox.Items.Count == 0)
                    {
                        weatherListBox.Items.Add("Không có dự báo thời tiết cho ngày này.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thành phố hoặc có lỗi xảy ra.");
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // Đóng Form2 và hiển thị Form1
            this.Close();
        }
    }
}
