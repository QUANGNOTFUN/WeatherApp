using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Text;

namespace WeatherApp
{
    public partial class Form3 : Form
    {
        private string[] neighboringCities; // Danh sách các thành phố lân cận
        private string apiKey = "62800263f5dd019d92880a8782a73dab";
        private Label titleLabel;
        private string cityForm1;
        private Dictionary<string, List<string>> northernCitiesDictionary;
        private Dictionary<string, List<string>> centralCitiesDictionary;
        private Dictionary<string, List<string>> southernCitiesDictionary;
        private Dictionary<string, string> weatherDescriptions = new Dictionary<string, string>(); // Đảm bảo định nghĩa dictionary này

        public Form3(string city)
        {
            InitializeComponent();
            cityForm1 = city;
            InitializeNeighboringCities();
            InitializeWeatherDescriptions();
            InitializeTitleLabel();
            AddCityNeighbors(cityForm1);
            this.Load += Form3_Load;
        }
        private void AddCityNeighbors(string city)
        {
            if (northernCitiesDictionary.TryGetValue(city, out var neighborsN))
            {
                neighboringCities = new string[neighborsN.Count];
                for (int i = 0; i < neighborsN.Count; i++)
                {
                    neighboringCities[i] = neighborsN[i];
                }
            }
            else if (centralCitiesDictionary.TryGetValue(city, out var neighborsC))
            {
                neighboringCities = new string[neighborsC.Count];
                for (int i = 0; i < neighborsC.Count; i++)
                {
                    neighboringCities[i] = neighborsC[i];
                }
            }
            else if (southernCitiesDictionary.TryGetValue(city, out var neighborsS)) // Add `else if` and correct semicolon
            {
                neighboringCities = new string[neighborsS.Count];
                for (int i = 0; i < neighborsS.Count; i++)
                {
                    neighboringCities[i] = neighborsS[i];
                }
            }
            else
            {
                neighboringCities = new string[0]; // Handle case when city is not found in any dictionary
                MessageBox.Show("City not found in any of the dictionaries.", "Error");
            }
        }


        private void InitializeNeighboringCities()
        {
            northernCitiesDictionary = new Dictionary<string, List<string>>
            {
                { "Hà Nội", new List<string> { "Vĩnh Phúc", "Hưng Yên", "Bắc Ninh", "Hà Nam", "Thái Nguyên" } },
                { "Bắc Giang", new List<string> { "Bắc Ninh", "Hưng Yên", "Thái Nguyên", "Vĩnh Phúc", "Tỉnh Quảng Ninh" } },
                { "Bắc Kạn", new List<string> { "Cao Bằng", "Tuyên Quang", "Thái Nguyên", "Bắc Giang" } },
                { "Hà Giang", new List<string> { "Tuyên Quang", "Cao Bằng", "Lào Cai", "Yên Bái", "Hà Nội" } },
                { "Hưng Yên", new List<string> { "Hà Nội", "Bắc Ninh", "Bắc Giang", "Hải Dương", "Hà Nam" } },
                { "Nam Định", new List<string> { "Hà Nam", "Thái Bình", "Hưng Yên", "Ninh Bình", "Thanh Hóa" } },
                { "Ninh Bình", new List<string> { "Nam Định", "Thanh Hóa", "Hà Nam", "Nghệ An", "Hòa Bình" } },
                { "Hà Nam", new List<string> { "Hà Nội", "Hưng Yên", "Thái Bình", "Nam Định", "Vĩnh Phúc" } },
                { "Tỉnh Quảng Ninh", new List<string> { "Hải Phòng", "Bắc Giang", "Bắc Kạn", "Lạng Sơn", "Hà Giang" } },
                { "Thái Nguyên", new List<string> { "Bắc Kạn", "Tuyên Quang", "Vĩnh Phúc", "Bắc Giang", "Hà Nội" } },
                { "Cao Bằng", new List<string> { "Bắc Kạn", "Tuyên Quang", "Lạng Sơn", "Hà Giang", "Thái Nguyên" } },
                { "Lai Châu", new List<string> { "Điện Biên Phủ", "Sơn La", "Yên Bái", "Lào Cai" } },
                { "Điện Biên Phủ", new List<string> { "Lai Châu", "Sơn La", "Yên Bái", "Cao Bằng", "Lào Cai" } },
                { "Sơn La", new List<string> { "Lai Châu", "Điện Biên Phủ", "Yên Bái", "Lào Cai", "Hòa Bình" } },
                { "Phú Thọ", new List<string> { "Vĩnh Phúc", "Hà Giang", "Tuyên Quang", "Hà Nội", "Yên Bái" } },
                { "Bắc Ninh", new List<string> { "Hà Nội", "Bắc Giang", "Hưng Yên", "Vĩnh Phúc", "Tỉnh Quảng Ninh" } },
                { "Hải Dương", new List<string> { "Hưng Yên", "Bắc Ninh", "Tỉnh Quảng Ninh", "Thái Bình", "Nam Định" } },
                { "Hải Phòng", new List<string> { "Tỉnh Quảng Ninh", "Hưng Yên", "Thái Bình", "Nam Định" } },
                { "Hòa Bình", new List<string> { "Sơn La", "Thanh Hóa", "Ninh Bình", "Hà Nội", "Hòa Bình" } },
                { "Lạng Sơn", new List<string> { "Cao Bằng", "Bắc Kạn", "Thái Nguyên", "Tỉnh Quảng Ninh", "Hà Giang", "Lào Cai" } },
                { "Lào Cai", new List<string> { "Lai Châu", "Sơn La", "Yên Bái", "Hà Giang", "Cao Bằng", "Lạng Sơn" } },
                { "Thái Bình", new List<string> { "Nam Định", "Hải Dương", "Hải Phòng", "Hưng Yên", "Thanh Hóa" } },
                { "Thanh Hóa", new List<string> { "Nghệ An", "Hà Tĩnh", "Nam Định", "Hòa Bình", "Ninh Bình" } },
                { "Tuyên Quang", new List<string> { "Cao Bằng", "Bắc Kạn", "Hà Giang", "Thái Nguyên", "Phú Thọ" } },
                { "Yên Bái", new List<string> { "Lai Châu", "Sơn La", "Hà Giang", "Tuyên Quang", "Phú Thọ", "Lào Cai" } }
            };

            centralCitiesDictionary = new Dictionary<string, List<string>>
            {
                { "Đà Nẵng", new List<string> { "Tỉnh Quảng Nam", "Quảng Ngãi", "Huế" } },
                { "Tỉnh Quảng Nam", new List<string> { "Đà Nẵng", "Quảng Ngãi", "Huế", "Kon Tum", "Gia Lai" } },
                { "Quảng Ngãi", new List<string> { "Tỉnh Quảng Nam", "Bình Định", "Kon Tum", "Gia Lai", "Tỉnh Phú Yên" } },
                { "Huế", new List<string> { "Tỉnh Quảng Nam", "Quảng Ngãi", "Đà Nẵng", "Quảng Trị", "Tỉnh Nghệ An" } },
                { "Kon Tum", new List<string> { "Gia Lai", "Tỉnh Ðắc Lắk", "Lâm Đồng", "Quảng Ngãi", "Tỉnh Phú Yên" } },
                { "Gia Lai", new List<string> { "Kon Tum", "Tỉnh Ðắc Lắk", "Tỉnh Phú Yên", "Bình Định", "Khánh Hòa" } },
                { "Khánh Hòa", new List<string> { "Ninh Thuận", "Lâm Đồng", "Tỉnh Ðắc Lắk", "Bình Định", "Tỉnh Phú Yên" } },
                { "Tỉnh Ðắc Lắk", new List<string> { "Lâm Đồng", "Ðăc Nông", "Gia Lai", "Bình Phước" } },
                { "Ðăc Nông", new List<string> { "Tỉnh Ðắc Lắk", "Lâm Đồng", "Bình Phước", "Gia Lai" } },
                { "Lâm Đồng", new List<string> { "Da Lat", "Khánh Hòa", "Tỉnh Ðắc Lắk", "Bình Phước", "Ninh Thuận" } },
                { "Da Lat", new List<string> { "Lâm Đồng", "Khánh Hòa", "Ninh Thuận" } },
                { "Tỉnh Phú Yên", new List<string> { "Quảng Ngãi", "Gia Lai", "Khánh Hòa", "Tỉnh Ðắc Lắk", "Ðăc Nông" } },
                { "Bình Định", new List<string> { "Quảng Ngãi", "Gia Lai", "Khánh Hòa", "Tỉnh Phú Yên" } },
                { "Quảng Trị", new List<string> { "Huế", "Hà Tĩnh", "Tỉnh Quảng Bình", "Lao Cai" } },
                { "Hà Tĩnh", new List<string> { "Huế", "Tỉnh Quảng Bình", "Lao Cai", "Tỉnh Nghệ An" } },
                { "Tỉnh Quảng Bình", new List<string> { "Quảng Trị", "Hà Tĩnh", "Lao Cai", "Tỉnh Nghệ An" } },
                { "Tỉnh Nghệ An", new List<string> { "Hà Tĩnh", "Tỉnh Quảng Bình", "Lao Cai", "Tỉnh Thanh Hóa" } }
            };

            southernCitiesDictionary = new Dictionary<string, List<string>>
            {
                { "Thành phố Hồ Chí Minh", new List<string> { "Bình Dương", "Tỉnh Ðồng Nai", "Long An", "Tỉnh Tiền Giang", "Vũng Tàu" } },
                { "Bình Dương", new List<string> { "Thành phố Hồ Chí Minh", "Tỉnh Bình Phước", "Tây Ninh", "Long An", "Tỉnh Ðồng Nai" } },
                { "Tỉnh Bình Phước", new List<string> { "Tỉnh Ðồng Nai", "Bình Dương", "Tây Ninh", "Gia Lai", "Kon Tum" } },
                { "Tây Ninh", new List<string> { "Bình Dương", "Long An", "Tỉnh Ðồng Nai", "Tỉnh Bình Phước", "Thành phố Hồ Chí Minh" } },
                { "Tỉnh Ðồng Nai", new List<string> { "Bình Dương", "Tỉnh Bình Phước", "Tây Ninh", "Long An", "Thành phố Hồ Chí Minh", "Vũng Tàu" } },
                { "Cần Thơ", new List<string> { "Hau Giang", "Sóc Trăng", "Vĩnh Long", "Bạc Liêu", "Tỉnh Kiến Giang" } },
                { "An Giang", new List<string> { "Cần Thơ", "Sóc Trăng", "Tỉnh Kiến Giang", "Hau Giang", "Vĩnh Long" } },
                { "Tỉnh Kiến Giang", new List<string> { "Cà Mau", "Bạc Liêu", "Hau Giang", "Sóc Trăng", "An Giang" } },
                { "Bạc Liêu", new List<string> { "Cà Mau", "Sóc Trăng", "Hau Giang", "Vĩnh Long", "Tỉnh Kiến Giang" } },
                { "Cà Mau", new List<string> { "Bạc Liêu", "Sóc Trăng", "Hau Giang", "Tỉnh Kiến Giang", "Vĩnh Long" } },
                { "Vũng Tàu", new List<string> { "Tỉnh Ðồng Nai", "Thành phố Hồ Chí Minh", "Tỉnh Bình Thuận" } },
                { "Bến Tre", new List<string> { "Tỉnh Tiền Giang", "Vĩnh Long", "Trà Vinh", "Thành phố Hồ Chí Minh" } },
                { "Sóc Trăng", new List<string> { "Bạc Liêu", "Cần Thơ", "Hau Giang", "Tỉnh Kiến Giang", "Trà Vinh" } },
                { "Trà Vinh", new List<string> { "Bến Tre", "Sóc Trăng", "Vĩnh Long" } },
                { "Hau Giang", new List<string> { "Cần Thơ", "Tỉnh Kiến Giang", "Sóc Trăng", "Vĩnh Long", "Bạc Liêu" } },
                { "Tỉnh Tiền Giang", new List<string> { "Long An", "Bến Tre", "Vĩnh Long", "Tỉnh Ðồng Tháp", "Thành phố Hồ Chí Minh" } },
                { "Tỉnh Ðồng Tháp", new List<string> { "Tỉnh Tiền Giang", "Vĩnh Long", "An Giang", "Bình Phước", "Cần Thơ" } },
                { "Tỉnh Bình Thuận", new List<string> { "Vũng Tàu", "Tỉnh Ninh Thuận", "Tỉnh Gia Lai", "Lâm Đồng" } },
                { "Long An", new List<string> { "Thành phố Hồ Chí Minh", "Bình Dương", "Tây Ninh", "Tỉnh Tiền Giang", "Tỉnh Ðồng Nai" } },
                { "Tỉnh Ninh Thuận", new List<string> { "Tỉnh Bình Thuận", "Khánh Hòa", "Lâm Đồng", "Tỉnh Gia Lai" } },
                { "Vĩnh Long", new List<string> { "Cần Thơ", "Bạc Liêu", "Sóc Trăng", "Bến Tre", "Trà Vinh", "Hau Giang", "Tỉnh Kiến Giang" } },
                { "Vĩnh Phúc", new List<string> { "Hà Nội", "Bắc Ninh", "Hà Giang", "Hưng Yên", "Thái Nguyên", "Tuyên Quang" } }
            };
        }

        private void InitializeWeatherDescriptions()
        {
            weatherDescriptions = new Dictionary<string, string>
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
        }

        private void InitializeTitleLabel()
        {
            // Create the titleLabel
            Label titleLabel = new Label
            {
                Text = "Thời tiết các tỉnh gần: " + cityForm1,
                Font = new Font("Tahoma", 30, FontStyle.Bold),
                ForeColor = Color.FromArgb(75, 75, 75),
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true // AutoSize ensures the Label resizes to fit the text
            };

            // Calculate the position to center the titleLabel
            titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 2, 30);

            // Optionally, handle form resizing to keep the label centered
            this.Resize += (sender, e) =>
            {
                titleLabel.Location = new Point((this.ClientSize.Width - titleLabel.Width) / 2, 10);
            };

            // Thêm titleLabel vào danh sách điều khiển của form
            this.Controls.Add(titleLabel);
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            var screenSize = Screen.PrimaryScreen.WorkingArea.Size;
            this.Size = new Size((int)(screenSize.Width * 0.7), (int)(600));
            this.StartPosition = FormStartPosition.Manual;

            this.DoubleBuffered = true;
            await LoadWeatherForNeighboringCities(); // Tải dữ liệu thời tiết khi form được tải
        }

        private async Task LoadWeatherForNeighboringCities()
        {
            // Xóa tất cả các panel thời tiết cũ khỏi form
            var controlsToRemove = this.Controls.OfType<Panel>().ToList();
            foreach (var control in controlsToRemove)
            {
                this.Controls.Remove(control);
                control.Dispose();
            }

            int panelTop = 100;
            int panelLeft = 20;
            int panelWidth = (this.ClientSize.Width / 3) - 30; // Điều chỉnh chiều rộng panel
            int panelHeight = 150;

            bool found = false; // Khởi tạo biến found

            // Kiểm tra xem thành phố đã chọn có trong danh sách không
            foreach (string city in neighboringCities)
            {
                // Gọi hàm để lấy dự báo thời tiết cho từng thành phố
                (int newPanelTop, int newPanelLeft) = await GetWeatherForecast(city, panelTop, panelLeft, panelWidth, panelHeight);

                // Cập nhật vị trí cho panel tiếp theo
                panelTop = newPanelTop;
                panelLeft = newPanelLeft;

                // Đặt found thành true nếu có thành phố lân cận được xử lý
                found = true;
            }

            // Kiểm tra nếu không có thành phố lân cận nào được tìm thấy
            if (!found)
            {
                MessageBox.Show($"Không tìm thấy thành phố lân cận cho {cityForm1}.");
            }
        }


        private async Task<(int, int)> GetWeatherForecast(string cityName, int panelTop, int panelLeft, int panelWidth, int panelHeight)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(cityName)}&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject weatherData = JObject.Parse(responseBody);

                        string city = weatherData["name"].ToString();
                        double temperature = double.Parse(weatherData["main"]["temp"].ToString()) - 273.15;
                        string weatherDescription = weatherData["weather"][0]["description"].ToString();
                        string iconCode = weatherData["weather"][0]["icon"].ToString();

                        // Chuyển đổi mô tả thời tiết sang tiếng Việt
                        string translatedDescription = weatherDescriptions.ContainsKey(weatherDescription)
                            ? weatherDescriptions[weatherDescription]
                            : weatherDescription;

                        CreateWeatherPanelForCity(city, temperature, translatedDescription, iconCode, ref panelTop, ref panelLeft, panelWidth, panelHeight);

                        return (panelTop, panelLeft);
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy thông tin thời tiết cho {cityName}.");
                        return (panelTop, panelLeft);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi lấy thông tin thời tiết cho {cityName}: {ex.Message}");
                    return (panelTop, panelLeft);
                }
            }
        }

        private void CreateWeatherPanelForCity(string cityName, double temperature, string weatherDescription, string iconCode, ref int panelTop, ref int panelLeft, int panelWidth, int panelHeight)
        {
            PictureBox weatherIcon = new PictureBox
            {
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = $"https://openweathermap.org/img/wn/{iconCode}@4x.png",
                BackColor = Color.Transparent
            };

            Label weatherInfoLabel = new Label
            {
                Width = panelWidth - 20,
                AutoSize = true,
                Margin = new Padding(4),
                Padding = new Padding(4),
                Text = $"{cityName}\nNhiệt độ: {temperature:F1}°C\nMô tả: {weatherDescription}",
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(75, 75, 75),
                Font = new Font("Tahoma", 14, FontStyle.Bold)
            };

            Panel cityPanel = new Panel
            {
                Width = panelWidth,
                Height = panelHeight,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
                Padding = new Padding(10),
                Top = panelTop,
                Left = panelLeft
            };

            cityPanel.Controls.Add(weatherInfoLabel);
            cityPanel.Controls.Add(weatherIcon);

            weatherInfoLabel.Top = 20;
            weatherInfoLabel.Left = 100;
            weatherIcon.Top = 10;
            weatherIcon.Left = 5;

            this.Controls.Add(cityPanel);

            panelLeft += panelWidth + 10;

            // Nếu panel vượt quá chiều rộng của form, di chuyển sang hàng mới
            if (panelLeft + panelWidth > this.ClientSize.Width)
            {
                panelLeft = 20;
                panelTop += panelHeight + 20;
            }
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            // Định nghĩa màu sắc cho gradient nền
            Color topLeftColor = Color.FromArgb(85, 181, 255); // Màu vàng ở góc trên bên trái
            Color middleColor = Color.FromArgb(237, 192, 44);     // Màu trung gian
            Color bottomRightColor = Color.FromArgb(153, 225, 255); // Màu ở góc dưới bên phải

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

                // Vẽ gradient nền
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Vẽ các hiệu ứng khác nếu cần
        }
    }
}
