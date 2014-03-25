namespace Mp4tag
{
    partial class FrmUpdateDownload
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
            this.grpProgress = new System.Windows.Forms.GroupBox();
            this.prbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.timClose = new System.Windows.Forms.Timer(this.components);
            this.grpProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProgress
            // 
            this.grpProgress.Controls.Add(this.lblProgress);
            this.grpProgress.Controls.Add(this.prbProgress);
            this.grpProgress.Location = new System.Drawing.Point(13, 13);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new System.Drawing.Size(323, 93);
            this.grpProgress.TabIndex = 0;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "[Progress]";
            // 
            // prbProgress
            // 
            this.prbProgress.Location = new System.Drawing.Point(17, 30);
            this.prbProgress.Name = "prbProgress";
            this.prbProgress.Size = new System.Drawing.Size(288, 23);
            this.prbProgress.TabIndex = 0;
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(17, 61);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(288, 23);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timClose
            // 
            this.timClose.Interval = 1000;
            this.timClose.Tick += new System.EventHandler(this.timClose_Tick);
            // 
            // FrmUpdateDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 118);
            this.Controls.Add(this.grpProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Downloader";
            this.Load += new System.EventHandler(this.FrmUpdateDownload_Load);
            this.Shown += new System.EventHandler(this.FrmUpdateDownload_Shown);
            this.grpProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpProgress;
        internal System.Windows.Forms.ProgressBar prbProgress;
        internal System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Timer timClose;


    }
}