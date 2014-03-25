using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mp4tag
{
    public partial class FrmMediaType : Form
    {
        public FrmMediaType()
        {
            InitializeComponent();
        }

        private void FrmMediaType_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Mp4tag;

            Language.Populate(this);

            rdoMediaType0.Text = Metadata.GetMediaType(0);
            rdoMediaType6.Text = Metadata.GetMediaType(6);
            rdoMediaType9.Text = Metadata.GetMediaType(9);
            rdoMediaType10.Text = Metadata.GetMediaType(10);
        }

        private void FrmMediaType_Shown(object sender, EventArgs e)
        {
            this.Text = FrmMain.GetFileName();
        }
    }
}
