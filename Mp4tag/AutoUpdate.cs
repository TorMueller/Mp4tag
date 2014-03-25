using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Mp4tag
{
    class AutoUpdate
    {
        private static string updateVersion;
        private static string tempUpdateFile;

        private static void updateInstallation()
        {
            tempUpdateFile = (System.Environment.GetEnvironmentVariable("TEMP") + "\\SetupMp4tag_" + updateVersion + ".exe");

            // Download is handled by dialog
            FrmUpdateDownload FrmUpdateDownload = new FrmUpdateDownload();
            FrmUpdateDownload.ShowDialog();

            if (FrmUpdateDownload.DialogResult == DialogResult.OK)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = tempUpdateFile;
                    process.Start();

                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Language.GetGlobalMessage("0001") + System.Environment.NewLine + System.Environment.NewLine + ex.ToString(), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void checkUpdate()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Properties.Resources.autoUpdateVersionUrl);
                webRequest.Proxy = WebRequest.DefaultWebProxy;
                webRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                webRequest.Timeout = 3000;

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                updateVersion = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.GetGlobalMessage("0002") + System.Environment.NewLine + System.Environment.NewLine + ex.ToString(), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (updateVersion == Regex.Replace(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(), @"(\d+\.\d+\.\d+)\.\d+", "$1"))
            {
                    return;
            }
             
            FrmUpdate FrmUpdate = new FrmUpdate();
            FrmUpdate.ShowDialog();
            if (FrmUpdate.DialogResult == DialogResult.OK)
            {
                updateInstallation();
            }
        }

        public static string GetReleaseNote()
        {
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Properties.Resources.autoUpdateReleaseNotesUrl);
                webRequest.Proxy = WebRequest.DefaultWebProxy;
                webRequest.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                webRequest.Timeout = 3000;

                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                
                return (reader.ReadToEnd());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Language.GetGlobalMessage("0003") + System.Environment.NewLine + System.Environment.NewLine + ex.ToString(), Language.GetGlobalMessage("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return "";
        }

        public static string GetUpdateVersion()
        {
            return updateVersion;
        }

        public static string GetTempFile()
        {
            return tempUpdateFile;
        }
    }
}
