namespace Mp4tag
{
    partial class FrmMediaType
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
            this.grpMediaType = new System.Windows.Forms.GroupBox();
            this.rdoMediaType0 = new System.Windows.Forms.RadioButton();
            this.rdoMediaType6 = new System.Windows.Forms.RadioButton();
            this.rdoMediaType10 = new System.Windows.Forms.RadioButton();
            this.rdoMediaType9 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpMediaType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMediaType
            // 
            this.grpMediaType.Controls.Add(this.rdoMediaType0);
            this.grpMediaType.Controls.Add(this.rdoMediaType6);
            this.grpMediaType.Controls.Add(this.rdoMediaType10);
            this.grpMediaType.Controls.Add(this.rdoMediaType9);
            this.grpMediaType.Location = new System.Drawing.Point(12, 12);
            this.grpMediaType.Name = "grpMediaType";
            this.grpMediaType.Size = new System.Drawing.Size(240, 82);
            this.grpMediaType.TabIndex = 0;
            this.grpMediaType.TabStop = false;
            this.grpMediaType.Text = "[Media Type]";
            // 
            // rdoMediaType0
            // 
            this.rdoMediaType0.AutoSize = true;
            this.rdoMediaType0.Location = new System.Drawing.Point(132, 51);
            this.rdoMediaType0.Name = "rdoMediaType0";
            this.rdoMediaType0.Size = new System.Drawing.Size(96, 17);
            this.rdoMediaType0.TabIndex = 3;
            this.rdoMediaType0.TabStop = true;
            this.rdoMediaType0.Text = "[Media Type 0]";
            this.rdoMediaType0.UseVisualStyleBackColor = true;
            // 
            // rdoMediaType6
            // 
            this.rdoMediaType6.AutoSize = true;
            this.rdoMediaType6.Location = new System.Drawing.Point(132, 27);
            this.rdoMediaType6.Name = "rdoMediaType6";
            this.rdoMediaType6.Size = new System.Drawing.Size(96, 17);
            this.rdoMediaType6.TabIndex = 2;
            this.rdoMediaType6.TabStop = true;
            this.rdoMediaType6.Text = "[Media Type 6]";
            this.rdoMediaType6.UseVisualStyleBackColor = true;
            // 
            // rdoMediaType10
            // 
            this.rdoMediaType10.AutoSize = true;
            this.rdoMediaType10.Location = new System.Drawing.Point(7, 51);
            this.rdoMediaType10.Name = "rdoMediaType10";
            this.rdoMediaType10.Size = new System.Drawing.Size(102, 17);
            this.rdoMediaType10.TabIndex = 1;
            this.rdoMediaType10.TabStop = true;
            this.rdoMediaType10.Text = "[Media Type 10]";
            this.rdoMediaType10.UseVisualStyleBackColor = true;
            // 
            // rdoMediaType9
            // 
            this.rdoMediaType9.AutoSize = true;
            this.rdoMediaType9.Location = new System.Drawing.Point(7, 27);
            this.rdoMediaType9.Name = "rdoMediaType9";
            this.rdoMediaType9.Size = new System.Drawing.Size(96, 17);
            this.rdoMediaType9.TabIndex = 0;
            this.rdoMediaType9.TabStop = true;
            this.rdoMediaType9.Text = "[Media Type 9]";
            this.rdoMediaType9.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(17, 104);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "[OK]";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(147, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmMediaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 139);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpMediaType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMediaType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmMediaType_Load);
            this.Shown += new System.EventHandler(this.FrmMediaType_Shown);
            this.grpMediaType.ResumeLayout(false);
            this.grpMediaType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.RadioButton rdoMediaType9;
        internal System.Windows.Forms.RadioButton rdoMediaType0;
        internal System.Windows.Forms.RadioButton rdoMediaType6;
        internal System.Windows.Forms.RadioButton rdoMediaType10;
        internal System.Windows.Forms.GroupBox grpMediaType;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Button btnCancel;
    }
}