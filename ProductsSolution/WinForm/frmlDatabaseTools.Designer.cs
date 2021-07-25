namespace WinForm
{
    partial class frmlDatabaseTools
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.lstCommands = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.txtCountSearches = new System.Windows.Forms.TextBox();
            this.txtSaleCount = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 715);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "Simulate Sales";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstCommands
            // 
            this.lstCommands.BackColor = System.Drawing.Color.Black;
            this.lstCommands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCommands.ForeColor = System.Drawing.Color.Lime;
            this.lstCommands.FormattingEnabled = true;
            this.lstCommands.ItemHeight = 25;
            this.lstCommands.Location = new System.Drawing.Point(12, 22);
            this.lstCommands.Name = "lstCommands";
            this.lstCommands.ScrollAlwaysVisible = true;
            this.lstCommands.Size = new System.Drawing.Size(1237, 679);
            this.lstCommands.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(560, 715);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Simulate Searches";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(201, 715);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 45);
            this.button3.TabIndex = 4;
            this.button3.Text = "Initial SalePoint Stock Data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtCountSearches
            // 
            this.txtCountSearches.Location = new System.Drawing.Point(560, 778);
            this.txtCountSearches.Name = "txtCountSearches";
            this.txtCountSearches.Size = new System.Drawing.Size(73, 22);
            this.txtCountSearches.TabIndex = 5;
            this.txtCountSearches.Text = "100";
            // 
            // txtSaleCount
            // 
            this.txtSaleCount.Location = new System.Drawing.Point(382, 778);
            this.txtSaleCount.Name = "txtSaleCount";
            this.txtSaleCount.Size = new System.Drawing.Size(73, 22);
            this.txtSaleCount.TabIndex = 6;
            this.txtSaleCount.Text = "100";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(25, 715);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 45);
            this.button4.TabIndex = 7;
            this.button4.Text = "Create Initial Data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmlDatabaseTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1261, 912);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtSaleCount);
            this.Controls.Add(this.txtCountSearches);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lstCommands);
            this.Controls.Add(this.button1);
            this.Name = "frmlDatabaseTools";
            this.Text = "DatabaseTools";
            this.Load += new System.EventHandler(this.frmlDatabaseTools_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstCommands;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCountSearches;
        private System.Windows.Forms.TextBox txtSaleCount;
        private System.Windows.Forms.Button button4;
    }
}