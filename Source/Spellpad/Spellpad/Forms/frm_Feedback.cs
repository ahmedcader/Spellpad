using AppLimit.CloudComputing.SharpBox;
using Spellpad.Classes;
using Spellpad.Classes.Ini;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Spellpad
{
    public partial class frm_Feedback : Form
    {
        IniFile ini_GlobalSettings;
        string stringToken;
        public frm_Feedback()
        {
            InitializeComponent();
            MessageBoxManager.Retry = "Copy";
            try
            {
                MessageBoxManager.Register();
            }
            catch (NotSupportedException)
            {
            }

            ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);

            if (string.IsNullOrWhiteSpace(txtbx_Feedback.Text))
                btn_SendFeedback.Enabled = false;
            else
                btn_SendFeedback.Enabled = true;

            ReadToken();
        }

        private void txtbx_Feedback_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_Feedback.Text))
                btn_SendFeedback.Enabled = false;
            else
                btn_SendFeedback.Enabled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {


            if (keyData == (Keys.Control | Keys.B))
            {
                DialogResult downloadExisits = MessageBox.Show(string.Format("Developer Purposes Only. The Feedback ID is used to organize each feedback sent from different computers. Loss of current feedback id will result in a new one generated.\n\n Your Feedback ID is:\n\n {0} \n\n You don't really need it unless I ask for it.", ini_GlobalSettings.Read("Program", "FeedbackID")), ProductName, MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);

                if (downloadExisits == DialogResult.Retry)
                {
                    Clipboard.SetText(ini_GlobalSettings.Read("Program", "FeedbackID"));
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ReadToken()
        {
            try
            {
                _Path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), string.Format("{0} - Feedback.txt", Variables.GetID(8)));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://dl.dropboxusercontent.com/u/82716142/Spellpad%20Update%20Files/Update/Files/SharpDropBox.Token");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                stringToken = sr.ReadToEnd();
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected Network error occurred. Feedback window will now close", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        string _Path;
        private void Upload()
        {
            try
            {
                using (StreamWriter sw = File.CreateText(_Path))
                    sw.Write(string.Format("{1} {2}" + Environment.NewLine + "{3}" + Environment.NewLine + Environment.NewLine + "{0}", txtbx_Feedback.Text, ProductName, ProductVersion, DateTime.Now.ToString("f")));

                CloudStorage oDBox = new CloudStorage();
                ICloudStorageConfiguration oDBoxConfig = CloudStorage.GetCloudConfigurationEasy(nSupportedCloudConfigurations.DropBox);
                ICloudStorageAccessToken oAccessToken = null;
                byte[] byteArray = Encoding.UTF8.GetBytes(stringToken);
                MemoryStream stream = new MemoryStream(byteArray);
                oAccessToken = oDBox.DeserializeSecurityToken(stream);
                var oStorageToken = oDBox.Open(oDBoxConfig, oAccessToken);
                var srcFile = _Path;
                var publicFolder = oDBox.GetRoot();
                oDBox.CreateFolder(Variables.Program_FeedbackID, publicFolder);
                var folder = oDBox.GetFolder(@"/" + Variables.Program_FeedbackID);
                oDBox.UploadFile(srcFile, folder);
                oDBox.Close();

                if (File.Exists(_Path))
                    File.Delete(_Path);

                btn_SendFeedback.Text = "Send";
                btn_SendFeedback.Enabled = true;
                txtbx_Feedback.Enabled = true;
                MessageBox.Show("Your feedback has been sent.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Unexpected Network error occurred. Feedback window will now close", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                btn_SendFeedback.Text = "Send";
                btn_SendFeedback.Enabled = true;
                txtbx_Feedback.Enabled = true;
            }
        }


        private void btn_SendFeedback_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_Feedback.Text))
                MessageBox.Show("Feedback field cannot be empty", "Empty Feedback", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Upload();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }
    }
}
