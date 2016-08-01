using Newtonsoft.Json;
using Spellpad.Classes;
using Spellpad.Classes.Ini;
using Spellpad.Forms.Spellpad_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frm_Updates : Form
    {
        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
        BackgroundWorker bg_checkUpdate;
        string SettingsPath;
        private readonly frm_Main formMain;

        public frm_Updates(frm_Main main)
        {
            InitializeComponent();
            formMain = main;
            tmrChange.Enabled = true;
            string sPath = string.Format(@"{0}\Update Information.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings"));
            SettingsPath = sPath;

            if (File.Exists(SettingsPath))
            {
                if (formMain.getUpdateInformation().AutoUpdateChecked == null)
                {
                    formMain.getUpdateInformation().AutoUpdateChecked = "false";
                }
                else
                {
                    chkbx_CheckUpdate.Checked = Convert.ToBoolean(formMain.getUpdateInformation().AutoUpdateChecked);
                }
                if (formMain.getUpdateInformation().AutUpdateCheckInterval == null)
                {
                    formMain.getUpdateInformation().AutoUpdateChecked = "30 Seconds";
                }
                else
                {
                    cmb_CheckEveryCollection.SelectedItem = formMain.getUpdateInformation().AutUpdateCheckInterval;
                }
                if (formMain.getUpdateInformation().LastCheckedUpdate == null)
                {
                    formMain.getUpdateInformation().AutoUpdateChecked = "Not yet checked for updates.";
                }
                else
                {
                    lbl_LastChecked.Text = string.Format("Last Checked on {0}.", formMain.getUpdateInformation().LastCheckedUpdate);
                }
            }
            else if (!File.Exists(string.Format(@"{0}\Update Information.txt", SettingsPath)))
            {
                formMain.getUpdateInformation().AutoUpdateChecked = "false";
                formMain.getUpdateInformation().AutUpdateCheckInterval = "30 Seconds";
                formMain.getUpdateInformation().LastCheckedUpdate = "Not yet checked for updates.";

                string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsPath)))
                {
                    writer.Write(jsonOutput);
                }
            }

            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            var ci = new CultureInfo(currentCulture.ToString());

            InitializeBackGroundWorker();
            CheckForIllegalCrossThreadCalls = false;

            lbl_Status.Text = string.Format("You have the latest version of {0}.", ProductName);
            lbl_LastCheckedVersion.Text = string.Format("{0}.", ProductVersion);
            lbl_LastCheckedVersion.ForeColor = Color.Black;
            lbl_currentText.Text = "Current version:";

            if (Variables.updateAvailable)
            {
                btn_Check.Text = "Download";
                lbl_Status.Text = string.Format("A newer version of {0} is available.", ProductName);
                lbl_LastCheckedVersion.Text = string.Format("{0}.", Variables.tempNewVersion, formMain.getUpdateInformation().LastCheckedUpdate);
                lbl_LastCheckedVersion.ForeColor = Color.DarkGreen;
                lbl_currentText.Text = "New version:";
                lbl_LastChecked.Text = string.Format("Last Checked on {0}.\nReady to download.", formMain.getUpdateInformation().LastCheckedUpdate);
            }

            if (Variables.updateHasDownloaded)
            {
                btn_Check.Text = "Install Update";
                lbl_Status.Text = string.Format("The latest update for {0} has been downloaded.", ProductName);
                lbl_LastCheckedVersion.Text = string.Format("{0}.", ProductVersion);
                lbl_currentText.Text = "Current version:";
                lbl_LastCheckedVersion.ForeColor = Color.Black;
                lbl_LastChecked.Text = string.Format("Last Checked on {0}.\nReady to install.", formMain.getUpdateInformation().LastCheckedUpdate);
            }

            if (chkbx_CheckUpdate.Checked)
            {
                label1.Visible = true;
                cmb_CheckEveryCollection.Visible = true;
                Size = new Size(494, 252);
            }
            else
            {
                label1.Visible = false;
                cmb_CheckEveryCollection.Visible = false;
                Size = new Size(494, 210);
            }
        }

        private void tmrChange_Tick(object sender, EventArgs e)
        {
            if (Variables.updateAvailable)
            {
                ChangeToUpdateReady();
                formMain.getSystemUpdateTimer().Enabled = false;
                tmrChange.Enabled = false;
            }
        }

        public void triggerSave()
        {
            formMain._TriggerSave();
        }

        private void searchUpdate()
        {
            btn_Check.Text = "Checking...";
            btn_Check.Enabled = false;
        }

        private void stopSearch()
        {
            btn_Check.Text = "Check";
            btn_Check.Enabled = true;
        }

        private void InitializeBackGroundWorker()
        {
            bg_checkUpdate = new BackgroundWorker();
            bg_checkUpdate.WorkerSupportsCancellation = true;
            bg_checkUpdate.WorkerReportsProgress = true;
            bg_checkUpdate.DoWork += new DoWorkEventHandler(bg_checkUpdate_DoWork);
            bg_checkUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_checkUpdate_RunWorkerCompleted);
        }

        private void bg_checkUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkbx_CheckUpdate.Checked)
            {
                if (Variables.updateAvailable)
                {
                    formMain.getSystemUpdateTimer().Enabled = false;
                }
                else
                {
                    formMain.getSystemUpdateTimer().Enabled = true;
                }
            }
        }

        private void bg_checkUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForUpdates();
        }

        private void CheckForUpdates()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            var ci = new CultureInfo(currentCulture.ToString());

            try
            {
                HttpWebRequest update_versionRequest = (HttpWebRequest)WebRequest.Create("https://dl.dropboxusercontent.com/u/82716142/Spellpad/Update/Main_Update.txt");
                HttpWebResponse update_versionResponse = (HttpWebResponse)update_versionRequest.GetResponse();
                StreamReader update_versionReader = new StreamReader(update_versionResponse.GetResponseStream());
                string NewVersion = update_versionReader.ReadToEnd();
                string currentversion = Application.ProductVersion;
                Variables.tempNewVersion = NewVersion;
                if (NewVersion.Contains(currentversion))
                {
                    Variables.updateAvailable = false;
                    formMain.getUpdateInformation().LastCheckedUpdate = string.Format("{0} at {1}", DateTime.Now.ToString("D", ci), DateTime.Now.ToString("t", ci));

                    lbl_Status.Text = string.Format("You have the latest version of {0}.", ProductName);
                    lbl_LastCheckedVersion.Text = string.Format("{0}.", ProductVersion);
                    lbl_currentText.Text = "Current version:";
                    lbl_LastCheckedVersion.ForeColor = Color.Black;
                    lbl_LastChecked.Text = string.Format("Last Checked on {0}.\nCheck again later.", formMain.getUpdateInformation().LastCheckedUpdate);
                    stopSearch();
                    bg_checkUpdate.CancelAsync();

                    string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
                    using (StreamWriter writer = new StreamWriter(SettingsPath))
                    {
                        writer.Write(jsonOutput);
                    }
                }
                else
                {
                    Variables.updateAvailable = true;
                    formMain.getUpdateInformation().LastCheckedUpdate = string.Format("{0} at {1}", DateTime.Now.ToString("D", ci), DateTime.Now.ToString("t", ci));
                    lbl_Status.Text = string.Format("A newer version of {0} is available.", ProductName);
                    lbl_LastCheckedVersion.Text = string.Format("{0}.", Variables.tempNewVersion);
                    lbl_LastCheckedVersion.ForeColor = Color.DarkGreen;
                    lbl_currentText.Text = "New version:";
                    lbl_LastChecked.Text = string.Format("Last Checked on {0}.\nReady to download.", formMain.getUpdateInformation().LastCheckedUpdate);
                    stopSearch();
                    btn_Check.Text = "Download";
                    formMain.showUpdateAvailability();
                    bg_checkUpdate.CancelAsync();

                    string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
                    using (StreamWriter writer = new StreamWriter(SettingsPath))
                    {
                        writer.Write(jsonOutput);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Updater couldn't check for updates properly due to an unkown error. Auto update will be disabled till the next startup.", ProductName), "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }
        }

        public void performCheck()
        {
            btn_Check.PerformClick();
        }

        private frm_Downloading _DownloadingDialog;
        private void btn_CheckUpdate_Click(object sender, EventArgs e)
        {
            if (btn_Check.Text == "Check")
            {
                if (chkbx_CheckUpdate.Checked)
                {
                    if (formMain.getSystemUpdateTimer().Enabled)
                    {
                        formMain.getSystemUpdateTimer().Enabled = false;
                        bg_checkUpdate.RunWorkerAsync();
                        searchUpdate();
                    }
                }
                else
                {
                    bg_checkUpdate.RunWorkerAsync();
                    searchUpdate();
                }

            }
            else if (btn_Check.Text == "Download")
            {
                #region Currently No way of Downloading Updates Through Spellpad, Keep Disabled. LEGACY
                //FolderBrowserDialog chooseDownloadLocation = new FolderBrowserDialog();
                //chooseDownloadLocation.Description = "Choose a location to save your update file.";
                //chooseDownloadLocation.ShowNewFolderButton = true;
                //if (chooseDownloadLocation.ShowDialog() == DialogResult.OK)
                //{
                //    if (File.Exists(chooseDownloadLocation.SelectedPath + @"\Spellpad Setup.exe"))
                //    {
                //        DialogResult downloadExisits = MessageBox.Show(string.Format("{0} detected another setup file in the same directory. Continuing to do so will overwrite the existing setup file in that directory. Continue?", ProductName), "Setup Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                //        if (downloadExisits == DialogResult.Yes)
                //        {
                //            ini_GlobalSettings.Write("Program", "Update_Location", chooseDownloadLocation.SelectedPath + @"\Spellpad Setup.exe");
                //            Variables.downloadLocation = ini_GlobalSettings.Read("Program", "Update_Location");

                //            formMain.getUpdateInformation().UpdateLocation = chooseDownloadLocation.SelectedPath + @"\Spellpad Setup.exe";
                //            Variables.downloadLocation = formMain.getUpdateInformation().UpdateLocation;

                //            string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
                //            using (StreamWriter writer = new StreamWriter(SettingsPath))
                //            {
                //                writer.Write(jsonOutput);
                //            }

                //            frm_GetSpellpad GetSpellpad = new frm_GetSpellpad();
                //            GetSpellpad.ShowDialog();

                //            _DownloadingDialog = new frm_Downloading(this);
                //            _DownloadingDialog.ShowDialog(this);
                //        }
                //        else if (downloadExisits == DialogResult.No)
                //        {
                //            btn_Check.PerformClick();
                //        }
                //    }
                //    else
                //    {
                //        ini_GlobalSettings.Write("Program", "Update_Location", chooseDownloadLocation.SelectedPath + @"\Spellpad Setup.exe");
                //        Variables.downloadLocation = ini_GlobalSettings.Read("Program", "Update_Location");

                //        formMain.getUpdateInformation().UpdateLocation = chooseDownloadLocation.SelectedPath + @"\Spellpad Setup.exe";
                //        Variables.downloadLocation = formMain.getUpdateInformation().UpdateLocation;

                //        string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
                //        using (StreamWriter writer = new StreamWriter(SettingsPath))
                //        {
                //            writer.Write(jsonOutput);
                //        }

                //        frm_GetSpellpad GetSpellpad = new frm_GetSpellpad();
                //        GetSpellpad.ShowDialog();

                //        _DownloadingDialog = new frm_Downloading(this);
                //        _DownloadingDialog.ShowDialog(this);
                //    }
                //} 
                #endregion

                frm_GetSpellpad GetSpellpad = new frm_GetSpellpad();
                GetSpellpad.ShowDialog();

            }
            else if (btn_Check.Text == "Install Update")
            {
                if (Variables.hasMadeChanges)
                {
                    Variables.fromInstallMenu = true;
                    Variables.saveAndQuit = true;
                    Application.Exit();
                }
                else
                {
                    Process.Start(Variables.downloadLocation);
                    Application.Exit();
                }
            }
        }

        private void chkbx_CheckUpdate_CheckedChanged(object sender, EventArgs e)
        {

            formMain.getUpdateInformation().AutoUpdateChecked = chkbx_CheckUpdate.Checked.ToString();

            string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(SettingsPath))
            {
                writer.Write(jsonOutput);
            }

            if (chkbx_CheckUpdate.Checked)
            {
                label1.Visible = true;
                cmb_CheckEveryCollection.Visible = true;
                Size = new Size(494, 252);
                formMain.getSystemUpdateTimer().Enabled = true;
            }
            else
            {
                label1.Visible = false;
                cmb_CheckEveryCollection.Visible = false;
                Size = new Size(494, 210);
                formMain.getSystemUpdateTimer().Enabled = false;
            }
        }

        private void frm_Updates_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void ChangeUpdateText()
        {
            formMain.ChangeUpdateAvailableText();
        }

        private void frm_Updates_Shown(object sender, EventArgs e)
        {
            if (Variables.triggerSaveDialog)
            {
                btn_Check.PerformClick();
                Variables.triggerSaveDialog = false;
            }
        }

        private void cmb_CheckEveryCollection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            formMain.getUpdateInformation().AutUpdateCheckInterval = cmb_CheckEveryCollection.SelectedItem.ToString();
            string jsonOutput = JsonConvert.SerializeObject(formMain.getUpdateInformation(), Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(SettingsPath))
            {
                writer.Write(jsonOutput);
            }
        }

        void ChangeToUpdateReady()
        {
            btn_Check.Text = "Download";
            lbl_Status.Text = string.Format("A newer version of {0} is available.", ProductName);
            lbl_LastCheckedVersion.Text = string.Format("{0}.", Variables.tempNewVersion, formMain.getUpdateInformation().LastCheckedUpdate);
            lbl_LastCheckedVersion.ForeColor = Color.DarkGreen;
            lbl_currentText.Text = "New version:";
            lbl_LastChecked.Text = string.Format("Last Checked on {0}.\nReady to download.", formMain.getUpdateInformation().LastCheckedUpdate);
        }


    }
}
