using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Mp4tag
{
    public partial class FrmUpdate : Form
    {
        public FrmUpdate()
        {
            InitializeComponent();
        }

        private string installed;

        private void FrmUpdate_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Mp4tag;

            Language.Populate(this);
            installed = Language.GetFormText(this, "installed");

            lblUpdateInfo.Text = lblUpdateInfo.Text + " " + AutoUpdate.GetUpdateVersion() + " (" + installed + ": " + Regex.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), @"(\d+\.\d+\.\d+)\.\d+", "$1") + ")";
            rtbReleaseNote.Rtf = AutoUpdate.GetReleaseNote();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
