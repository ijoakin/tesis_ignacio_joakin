namespace WinForm
{
    partial class frmMachineLearning
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.MLChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MLChart)).BeginInit();
            this.SuspendLayout();
            // 
            // MLChart
            // 
            chartArea2.Name = "ChartArea1";
            this.MLChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.MLChart.Legends.Add(legend2);
            this.MLChart.Location = new System.Drawing.Point(12, 52);
            this.MLChart.Name = "MLChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.MLChart.Series.Add(series2);
            this.MLChart.Size = new System.Drawing.Size(1084, 593);
            this.MLChart.TabIndex = 0;
            this.MLChart.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 670);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 57);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate Graph";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMachineLearning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 762);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MLChart);
            this.Name = "frmMachineLearning";
            this.Text = "MachineLearning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.MLChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MLChart;
        private System.Windows.Forms.Button button1;
    }
}