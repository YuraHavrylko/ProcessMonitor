namespace ProcessMonitor
{
    partial class Monitor
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
            this.ProcessList = new System.Windows.Forms.DataGridView();
            this.ProcessLog = new System.Windows.Forms.RichTextBox();
            this.btmRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessList)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessList.Location = new System.Drawing.Point(12, 37);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(464, 336);
            this.ProcessList.TabIndex = 0;
            // 
            // ProcessLog
            // 
            this.ProcessLog.Location = new System.Drawing.Point(12, 379);
            this.ProcessLog.Name = "ProcessLog";
            this.ProcessLog.Size = new System.Drawing.Size(464, 79);
            this.ProcessLog.TabIndex = 1;
            this.ProcessLog.Text = "";
            // 
            // btmRefresh
            // 
            this.btmRefresh.Location = new System.Drawing.Point(13, 13);
            this.btmRefresh.Name = "btmRefresh";
            this.btmRefresh.Size = new System.Drawing.Size(75, 23);
            this.btmRefresh.TabIndex = 2;
            this.btmRefresh.Text = "Refresh";
            this.btmRefresh.UseVisualStyleBackColor = true;
            this.btmRefresh.Click += new System.EventHandler(this.btmRefresh_Click);
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 470);
            this.Controls.Add(this.btmRefresh);
            this.Controls.Add(this.ProcessLog);
            this.Controls.Add(this.ProcessList);
            this.Name = "Monitor";
            this.Text = "Process Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.ProcessList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProcessList;
        private System.Windows.Forms.RichTextBox ProcessLog;
        private System.Windows.Forms.Button btmRefresh;
    }
}

