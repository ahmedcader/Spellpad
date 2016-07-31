using Spellpad.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Spellpad.Forms.Spellpad_Forms;

namespace Spellpad.Forms
{
    public partial class frm_Downloading : Form
    {
        private readonly frm_Updates formDownloading;
        WebClient client;
        public frm_Downloading(frm_Updates _formDownloading)
        {
            InitializeComponent();
            formDownloading = _formDownloading;

            client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            //lbl_Progress.Text = "0%";
            lbl_OutOf.Text = string.Format("0 KB/{0}", Variables.BytesToString(Variables.GetServerFile(string.Format("https://dl.dropboxusercontent.com/u/82716142/Spellpad%20Update%20Files/Update/Revisions/{0}/Setup/Spellpad-SetupFiles/Spellpad%20Setup.exe", Variables.tempNewVersion))));
        }

        public void changeUpdateText()
        {
            formDownloading.ChangeUpdateText();
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (cancelled)
            {
                if (File.Exists(Variables.downloadLocation))
                {
                    File.Delete(Variables.downloadLocation);
                }
                Variables.updateAvailable = true;
                this.Close();
            }
            else
            {
                DialogResult installUpdateDialog = MessageBox.Show(string.Format("Successfully downloaded the latest update for {0}. Would you like to install it now?", ProductName, Variables.downloadLocation), "Install Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (installUpdateDialog == DialogResult.Yes)
                {
                    if (Variables.hasMadeChanges)
                    {
                        Variables.saveAndQuit = true;
                        Application.Exit();
                    }
                    else
                    {
                        Process.Start(Variables.downloadLocation);
                        Application.Exit();
                    }
                }
                else if (installUpdateDialog == DialogResult.No)
                {
                    changeUpdateText();
                    Variables.updateHasDownloaded = true;
                    this.Close();
                    formDownloading.Close();
                }
            }
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            //lbl_Progress.Text = string.Format("{0}%", pb_Download.Value);
            lbl_OutOf.Text = string.Format("{0}/{1}", Variables.BytesToString(e.BytesReceived), Variables.BytesToString(e.TotalBytesToReceive));

            pb_Download.Value = int.Parse(Math.Truncate(percentage).ToString());
        }

        private void frm_Downloading_Shown(object sender, EventArgs e)
        {
            client.DownloadFileAsync(new Uri(string.Format("https://dl.dropboxusercontent.com/u/82716142/Spellpad%20Update%20Files/Update/Revisions/{0}/Setup/Spellpad-SetupFiles/Spellpad%20Setup.exe", Variables.tempNewVersion)), Variables.downloadLocation);
        }
        bool cancelled;
        private void btn_CancelDownload_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
            cancelled = true;
        }
    }
}
