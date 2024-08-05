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
            this.label2 = new System.Windows.Forms.Label();
            this.currentDateLabel = new System.Windows.Forms.Label();
            this.weatherListBox = new System.Windows.Forms.ListBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // currentDateLabel
            // 
            this.currentDateLabel.AutoSize = true;
            this.currentDateLabel.Location = new System.Drawing.Point(272, 94);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(44, 16);
            this.currentDateLabel.TabIndex = 4;
            this.currentDateLabel.Text = "label1";
            // 
            // weatherListBox
            // 
            this.weatherListBox.FormattingEnabled = true;
            this.weatherListBox.ItemHeight = 16;
            this.weatherListBox.Location = new System.Drawing.Point(139, 240);
            this.weatherListBox.Name = "weatherListBox";
            this.weatherListBox.Size = new System.Drawing.Size(520, 452);
            this.weatherListBox.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 751);
            this.Controls.Add(this.weatherListBox);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextDayButton);
            this.Controls.Add(this.previousDayButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previousDayButton;
        private System.Windows.Forms.Button nextDayButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label currentDateLabel;
        private System.Windows.Forms.ListBox weatherListBox;
    }
}