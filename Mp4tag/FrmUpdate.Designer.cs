namespace Mp4tag
{
    partial class FrmUpdate
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
            this.grpUpdateInfo = new System.Windows.Forms.GroupBox();
            this.lblUpdateInfo = new System.Windows.Forms.Label();
            this.rtbReleaseNote = new System.Windows.Forms.RichTextBox();
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblReleaseNotes = new System.Windows.Forms.Label();
            this.grpUpdateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUpdateInfo
            // 
            this.grpUpdateInfo.Controls.Add(this.lblUpdateInfo);
            this.grpUpdateInfo.Location = new System.Drawing.Point(13, 13);
            this.grpUpdateInfo.Name = "grpUpdateInfo";
            this.grpUpdateInfo.Size = new System.Drawing.Size(505, 59);
            this.grpUpdateInfo.TabIndex = 0;
            this.grpUpdateInfo.TabStop = false;
            this.grpUpdateInfo.Text = "[Update Information]";
            // 
            // lblUpdateInfo
            // 
            this.lblUpdateInfo.AutoSize = true;
            this.lblUpdateInfo.Location = new System.Drawing.Point(6, 27);
            this.lblUpdateInfo.Name = "lblUpdateInfo";
            this.lblUpdateInfo.Size = new System.Drawing.Size(166, 13);
            this.lblUpdateInfo.TabIndex = 0;
            this.lblUpdateInfo.Text = "[A newer version has been found]";
            // 
            // rtbReleaseNote
            // 
            this.rtbReleaseNote.BackColor = System.Drawing.SystemColors.Window;
            this.rtbReleaseNote.Location = new System.Drawing.Point(13, 103);
            this.rtbReleaseNote.Name = "rtbReleaseNote";
            this.rtbReleaseNote.ReadOnly = true;
            this.rtbReleaseNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbReleaseNote.Size = new System.Drawing.Size(505, 297);
            this.rtbReleaseNote.TabIndex = 1;
            this.rtbReleaseNote.TabStop = false;
            this.rtbReleaseNote.Text = "";
            // 
            // btnInstall
            // 
            this.btnInstall.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnInstall.Location = new System.Drawing.Point(312, 413);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(100, 23);
            this.btnInstall.TabIndex = 2;
            this.btnInstall.Text = "[Install]";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(418, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblReleaseNotes
            // 
            this.lblReleaseNotes.AutoSize = true;
            this.lblReleaseNotes.Location = new System.Drawing.Point(13, 87);
            this.lblReleaseNotes.Name = "lblReleaseNotes";
            this.lblReleaseNotes.Size = new System.Drawing.Size(78, 13);
            this.lblReleaseNotes.TabIndex = 4;
            this.lblReleaseNotes.Text = "[Release Note]";
            // 
            // FrmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 448);
            this.Controls.Add(this.lblReleaseNotes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.rtbReleaseNote);
            this.Controls.Add(this.grpUpdateInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Updater";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.grpUpdateInfo.ResumeLayout(false);
            this.grpUpdateInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpUpdateInfo;
        internal System.Windows.Forms.Label lblUpdateInfo;
        internal System.Windows.Forms.RichTextBox rtbReleaseNote;
        internal System.Windows.Forms.Button btnInstall;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label lblReleaseNotes;



    }
}