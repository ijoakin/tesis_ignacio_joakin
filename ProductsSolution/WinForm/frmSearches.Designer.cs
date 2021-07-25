namespace WinForm
{
    partial class frmSearches
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
            this.searchesdataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchesdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchesdataGridView
            // 
            this.searchesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchesdataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchesdataGridView.Location = new System.Drawing.Point(0, 0);
            this.searchesdataGridView.Name = "searchesdataGridView";
            this.searchesdataGridView.RowHeadersWidth = 51;
            this.searchesdataGridView.RowTemplate.Height = 24;
            this.searchesdataGridView.Size = new System.Drawing.Size(1098, 700);
            this.searchesdataGridView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 723);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Searches";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSearches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 892);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchesdataGridView);
            this.Name = "frmSearches";
            this.Text = "Searches";
            ((System.ComponentModel.ISupportInitialize)(this.searchesdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView searchesdataGridView;
        private System.Windows.Forms.Button button1;
    }
}