﻿namespace WeatherApp
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
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.detailsButton = new System.Windows.Forms.Button();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.Temp = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.Label();
            this.Dcr = new System.Windows.Forms.Label();
            this.humid = new System.Windows.Forms.Label();
            this.Prs = new System.Windows.Forms.Label();
            this.wind = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rain = new System.Windows.Forms.Label();
            this.gust = new System.Windows.Forms.Label();
            this.hours = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.DarkOrange;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(746, 46);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.searchButton.Name = "searchButton";
            this.searchButton.Padding = new System.Windows.Forms.Padding(5);
            this.searchButton.Size = new System.Drawing.Size(179, 46);
            this.searchButton.TabIndex = 4;
            this.searchButton.Tag = "2";
            this.searchButton.Text = "Tìm kiếm";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(281, 36);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4);
            this.label1.Size = new System.Drawing.Size(212, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Địa điểm:";
            // 
            // detailsButton
            // 
            this.detailsButton.BackColor = System.Drawing.Color.DarkOrange;
            this.detailsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.detailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detailsButton.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsButton.ForeColor = System.Drawing.Color.White;
            this.detailsButton.Location = new System.Drawing.Point(607, 542);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Padding = new System.Windows.Forms.Padding(5);
            this.detailsButton.Size = new System.Drawing.Size(203, 46);
            this.detailsButton.TabIndex = 7;
            this.detailsButton.Tag = "3";
            this.detailsButton.Text = "Xem chi tiết";
            this.detailsButton.UseVisualStyleBackColor = false;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picIcon.Location = new System.Drawing.Point(34, 96);
            this.picIcon.Margin = new System.Windows.Forms.Padding(0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(462, 382);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 8;
            this.picIcon.TabStop = false;
            // 
            // Temp
            // 
            this.Temp.AutoSize = true;
            this.Temp.BackColor = System.Drawing.Color.Transparent;
            this.Temp.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Temp.ForeColor = System.Drawing.Color.Coral;
            this.Temp.Location = new System.Drawing.Point(341, 330);
            this.Temp.Name = "Temp";
            this.Temp.Size = new System.Drawing.Size(0, 45);
            this.Temp.TabIndex = 10;
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.BackColor = System.Drawing.Color.Transparent;
            this.day.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day.Location = new System.Drawing.Point(113, 18);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(0, 32);
            this.day.TabIndex = 20;
            // 
            // Dcr
            // 
            this.Dcr.AutoSize = true;
            this.Dcr.BackColor = System.Drawing.Color.Transparent;
            this.Dcr.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dcr.ForeColor = System.Drawing.Color.DarkGreen;
            this.Dcr.Location = new System.Drawing.Point(127, 330);
            this.Dcr.Name = "Dcr";
            this.Dcr.Size = new System.Drawing.Size(0, 45);
            this.Dcr.TabIndex = 21;
            // 
            // humid
            // 
            this.humid.AutoSize = true;
            this.humid.BackColor = System.Drawing.Color.Transparent;
            this.humid.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humid.ForeColor = System.Drawing.Color.Blue;
            this.humid.Location = new System.Drawing.Point(787, 240);
            this.humid.Name = "humid";
            this.humid.Size = new System.Drawing.Size(0, 38);
            this.humid.TabIndex = 22;
            // 
            // Prs
            // 
            this.Prs.AutoSize = true;
            this.Prs.BackColor = System.Drawing.Color.Transparent;
            this.Prs.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prs.ForeColor = System.Drawing.Color.Blue;
            this.Prs.Location = new System.Drawing.Point(781, 294);
            this.Prs.Name = "Prs";
            this.Prs.Size = new System.Drawing.Size(0, 38);
            this.Prs.TabIndex = 23;
            // 
            // wind
            // 
            this.wind.AutoSize = true;
            this.wind.BackColor = System.Drawing.Color.Transparent;
            this.wind.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wind.ForeColor = System.Drawing.Color.Blue;
            this.wind.Location = new System.Drawing.Point(782, 343);
            this.wind.Name = "wind";
            this.wind.Size = new System.Drawing.Size(0, 38);
            this.wind.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label4.Location = new System.Drawing.Point(340, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(493, 53);
            this.label4.TabIndex = 25;
            this.label4.Text = "THỜI TIẾT HIỆN TẠI";
            // 
            // rain
            // 
            this.rain.AutoSize = true;
            this.rain.BackColor = System.Drawing.Color.Transparent;
            this.rain.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rain.ForeColor = System.Drawing.Color.Blue;
            this.rain.Location = new System.Drawing.Point(787, 190);
            this.rain.Name = "rain";
            this.rain.Size = new System.Drawing.Size(0, 38);
            this.rain.TabIndex = 26;
            // 
            // gust
            // 
            this.gust.AutoSize = true;
            this.gust.BackColor = System.Drawing.Color.Transparent;
            this.gust.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gust.ForeColor = System.Drawing.Color.Blue;
            this.gust.Location = new System.Drawing.Point(788, 397);
            this.gust.Name = "gust";
            this.gust.Size = new System.Drawing.Size(0, 32);
            this.gust.TabIndex = 27;
            // 
            // hours
            // 
            this.hours.AutoSize = true;
            this.hours.BackColor = System.Drawing.Color.Transparent;
            this.hours.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hours.ForeColor = System.Drawing.Color.Beige;
            this.hours.Location = new System.Drawing.Point(837, 18);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(0, 32);
            this.hours.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label2.Location = new System.Drawing.Point(468, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 38);
            this.label2.TabIndex = 28;
            this.label2.Text = "Lượng mưa";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label3.Location = new System.Drawing.Point(468, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 38);
            this.label3.TabIndex = 29;
            this.label3.Text = "Áp suất khí quyển";
            this.label3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Location = new System.Drawing.Point(468, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 38);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tốc độ gió";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label6.Location = new System.Drawing.Point(468, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 38);
            this.label6.TabIndex = 31;
            this.label6.Text = "Gió giật";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.Location = new System.Drawing.Point(468, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 38);
            this.label7.TabIndex = 32;
            this.label7.Text = "Độ ẩm";
            this.label7.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1113, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 33;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(338, 542);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(5);
            this.button3.Size = new System.Drawing.Size(203, 46);
            this.button3.TabIndex = 34;
            this.button3.Tag = "3";
            this.button3.Text = "Xem lân cận";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Century", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(1200, 600);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.CityComboBox_SelectedIndexChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button detailsButton;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label Temp;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.Label Dcr;
        private System.Windows.Forms.Label humid;
        private System.Windows.Forms.Label Prs;
        private System.Windows.Forms.Label wind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rain;
        private System.Windows.Forms.Label gust;
        private System.Windows.Forms.Label hours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}
