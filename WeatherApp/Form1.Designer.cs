namespace WeatherApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.detailsButton = new System.Windows.Forms.Button();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.Temp = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.Label();
            this.Dcr = new System.Windows.Forms.Label();
            this.humid = new System.Windows.Forms.Label();
            this.Prs = new System.Windows.Forms.Label();
            this.wind = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rain = new System.Windows.Forms.Label();
            this.gust = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(720, 52);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(77, 24);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Tìm";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 52);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4);
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Thành phố:";
            // 
            // detailsButton
            // 
            this.detailsButton.Location = new System.Drawing.Point(550, 466);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(118, 23);
            this.detailsButton.TabIndex = 7;
            this.detailsButton.Text = "Xem chi tiết";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(146, 169);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(208, 161);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 8;
            this.picIcon.TabStop = false;
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(458, 52);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(224, 24);
            this.cityComboBox.TabIndex = 9;
            // 
            // Temp
            // 
            this.Temp.AutoSize = true;
            this.Temp.BackColor = System.Drawing.Color.Transparent;
            this.Temp.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temp.Location = new System.Drawing.Point(372, 232);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(0, 37);
            this.Temp.TabIndex = 10;
            // 
            // hours
            // 
            this.hours.AutoSize = true;
            this.hours.BackColor = System.Drawing.Color.Transparent;
            this.hours.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hours.Location = new System.Drawing.Point(978, 18);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(0, 32);
            this.hours.TabIndex = 18;
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.BackColor = System.Drawing.Color.Transparent;
            this.day.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day.Location = new System.Drawing.Point(101, 18);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(0, 32);
            this.day.TabIndex = 20;
            // 
            // Dcr
            // 
            this.Dcr.AutoSize = true;
            this.Dcr.BackColor = System.Drawing.Color.Transparent;
            this.Dcr.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dcr.Location = new System.Drawing.Point(172, 368);
            this.Dcr.Name = "Dcr";
            this.Dcr.Size = new System.Drawing.Size(0, 25);
            this.Dcr.TabIndex = 21;
            // 
            // humid
            // 
            this.humid.AutoSize = true;
            this.humid.BackColor = System.Drawing.Color.Transparent;
            this.humid.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humid.Location = new System.Drawing.Point(657, 219);
            this.humid.Name = "humid";
            this.humid.Size = new System.Drawing.Size(0, 32);
            this.humid.TabIndex = 22;
            // 
            // Prs
            // 
            this.Prs.AutoSize = true;
            this.Prs.BackColor = System.Drawing.Color.Transparent;
            this.Prs.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prs.Location = new System.Drawing.Point(656, 269);
            this.Prs.Name = "Prs";
            this.Prs.Size = new System.Drawing.Size(0, 32);
            this.Prs.TabIndex = 23;
            // 
            // wind
            // 
            this.wind.AutoSize = true;
            this.wind.BackColor = System.Drawing.Color.Transparent;
            this.wind.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wind.Location = new System.Drawing.Point(655, 315);
            this.wind.Name = "wind";
            this.wind.Size = new System.Drawing.Size(0, 32);
            this.wind.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 32);
            this.label4.TabIndex = 25;
            this.label4.Text = "Thời tiết hiện tại";
            // 
            // rain
            // 
            this.rain.AutoSize = true;
            this.rain.BackColor = System.Drawing.Color.Transparent;
            this.rain.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rain.Location = new System.Drawing.Point(657, 168);
            this.rain.Name = "rain";
            this.rain.Size = new System.Drawing.Size(0, 32);
            this.rain.TabIndex = 26;
            // 
            // gust
            // 
            this.gust.AutoSize = true;
            this.gust.BackColor = System.Drawing.Color.Transparent;
            this.gust.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gust.Location = new System.Drawing.Point(655, 368);
            this.gust.Name = "gust";
            this.gust.Size = new System.Drawing.Size(0, 32);
            this.gust.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 807);
            this.Controls.Add(this.gust);
            this.Controls.Add(this.rain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wind);
            this.Controls.Add(this.Prs);
            this.Controls.Add(this.humid);
            this.Controls.Add(this.Dcr);
            this.Controls.Add(this.day);
            this.Controls.Add(this.hours);
            this.Controls.Add(this.Temp);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Tốc độ gió";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.ComboBox cityComboBox;
        private System.Windows.Forms.Label Temp;
        private System.Windows.Forms.Label hours;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Label Dcr;
        private System.Windows.Forms.Label humid;
        private System.Windows.Forms.Label Prs;
        private System.Windows.Forms.Label wind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rain;
        private System.Windows.Forms.Label gust;
    }
}
