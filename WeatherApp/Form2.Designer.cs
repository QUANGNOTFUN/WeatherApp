namespace WeatherApp
{
    partial class Form2
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
            this.previousDayButton = new System.Windows.Forms.Button();
            this.nextDayButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.cityNameLabel = new System.Windows.Forms.Label();
            this.weatherFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // previousDayButton
            // 
            this.previousDayButton.Location = new System.Drawing.Point(139, 87);
            this.previousDayButton.Name = "previousDayButton";
            this.previousDayButton.Size = new System.Drawing.Size(75, 23);
            this.previousDayButton.TabIndex = 0;
            this.previousDayButton.Text = "Pre day";
            this.previousDayButton.UseVisualStyleBackColor = true;
            this.previousDayButton.Click += new System.EventHandler(this.previousDayButton_Click);
            // 
            // nextDayButton
            // 
            this.nextDayButton.Location = new System.Drawing.Point(584, 94);
            this.nextDayButton.Name = "nextDayButton";
            this.nextDayButton.Size = new System.Drawing.Size(75, 23);
            this.nextDayButton.TabIndex = 1;
            this.nextDayButton.Text = "Next day";
            this.nextDayButton.UseVisualStyleBackColor = true;
            this.nextDayButton.Click += new System.EventHandler(this.nextDayButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(31, 23);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Location = new System.Drawing.Point(259, 93);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(44, 16);
            this.currentDateLabel.TabIndex = 9;
            this.currentDateLabel.Text = "label1";
            // 
            // cityNameLabel
            // 
            this.cityNameLabel.AutoSize = true;
            this.cityNameLabel.Location = new System.Drawing.Point(315, 29);
            this.cityNameLabel.Name = "cityNameLabel";
            this.cityNameLabel.Size = new System.Drawing.Size(44, 16);
            this.cityNameLabel.TabIndex = 10;
            this.cityNameLabel.Text = "label2";
            // 
            // weatherFlowLayoutPanel
            // 
            this.weatherFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.weatherFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.weatherFlowLayoutPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.weatherFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherFlowLayoutPanel.Location = new System.Drawing.Point(90, 337);
            this.weatherFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.weatherFlowLayoutPanel.Name = "weatherFlowLayoutPanel";
            this.weatherFlowLayoutPanel.Size = new System.Drawing.Size(1000, 427);
            this.weatherFlowLayoutPanel.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1182, 807);
            this.Controls.Add(this.weatherFlowLayoutPanel);
            this.Controls.Add(this.cityNameLabel);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.nextDayButton);
            this.Controls.Add(this.previousDayButton);
            this.MaximumSize = new System.Drawing.Size(1200, 854);
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previousDayButton;
        private System.Windows.Forms.Button nextDayButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.Label cityNameLabel;
        private System.Windows.Forms.FlowLayoutPanel weatherFlowLayoutPanel;
    }
}