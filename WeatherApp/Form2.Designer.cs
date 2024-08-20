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
            this.previousDayButton.Location = new System.Drawing.Point(245, 78);
            this.previousDayButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.previousDayButton.Name = "previousDayButton";
            this.previousDayButton.Size = new System.Drawing.Size(75, 23);
            this.previousDayButton.TabIndex = 0;
            this.previousDayButton.Text = "Pre day";
            this.previousDayButton.UseVisualStyleBackColor = true;
            this.previousDayButton.Click += new System.EventHandler(this.previousDayButton_Click);
            // 
            // nextDayButton
            // 
            this.nextDayButton.Location = new System.Drawing.Point(649, 78);
            this.nextDayButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.backButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.currentDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDateLabel.Location = new System.Drawing.Point(507, 78);
            this.currentDateLabel.Name = "currentDateLabel";
            this.currentDateLabel.Size = new System.Drawing.Size(79, 29);
            this.currentDateLabel.TabIndex = 9;
            this.currentDateLabel.Text = "label1";
            // 
            // cityNameLabel
            // 
            this.cityNameLabel.AutoSize = true;
            this.cityNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityNameLabel.Location = new System.Drawing.Point(507, 30);
            this.cityNameLabel.Name = "cityNameLabel";
            this.cityNameLabel.Size = new System.Drawing.Size(79, 29);
            this.cityNameLabel.TabIndex = 10;
            this.cityNameLabel.Text = "label2";
            // 
            // weatherFlowLayoutPanel
            // 
            this.weatherFlowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.weatherFlowLayoutPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.weatherFlowLayoutPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherFlowLayoutPanel.Location = new System.Drawing.Point(83, 355);
            this.weatherFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.weatherFlowLayoutPanel.Name = "weatherFlowLayoutPanel";
            this.weatherFlowLayoutPanel.Size = new System.Drawing.Size(834, 215);
            this.weatherFlowLayoutPanel.TabIndex = 12;
            this.weatherFlowLayoutPanel.WrapContents = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 629);
            this.Controls.Add(this.weatherFlowLayoutPanel);
            this.Controls.Add(this.cityNameLabel);
            this.Controls.Add(this.currentDateLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.nextDayButton);
            this.Controls.Add(this.previousDayButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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