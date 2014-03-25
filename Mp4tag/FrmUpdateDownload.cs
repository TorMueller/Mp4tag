using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Mp4tag
{
    public partial class FrmUpdateDownload : Form
    {
        public FrmUpdateDownload()
        {
            InitializeComponent();
        }

        private string downloaded;
        private string of;
        private string complete;

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = (int)Math.Ceiling(bytesIn / totalBytes * 100);
            lblProgress.Text = downloaded + " " + e.BytesReceived + " " + of + " " + e.TotalBytesToReceive;
            prbProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            prbProgress.Value = prbProgress.Maximum;
            lblProgress.Text = complete;

            timClose.Start();
        }

        private void FrmUpdateDownload_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Mp4tag;

            Language.Populate(this);
            downloaded = Language.GetFormText(this, "downloaded");
            of = Language.GetFormText(this, "of");
            complete = Language.GetFormText(this, "complete");
        }

        private void FrmUpdateDownload_Shown(object sender, EventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Proxy = WebRequest.DefaultWebProxy;
                webClient.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                webClient.DownloadFileAsync(new Uri(Properties.Resources.autoUpdateSetupUrl), AutoUpdate.GetTempFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Language.GetFormMessage(this, "0001") + System.Environment.NewLine + System.Environment.NewLine + ex.ToString(), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void timClose_Tick(object sender, EventArgs e)
        {
            timClose.Stop();
            this.DialogResult = DialogResult.OK;
        }
    }
}
