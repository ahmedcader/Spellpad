using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frmWhatsNew : Form
    {
        public frmWhatsNew()
        {
            InitializeComponent();

            try
            {
                HttpWebRequest update_versionRequest = (HttpWebRequest)WebRequest.Create(string.Format("https://dl.dropboxusercontent.com/u/82716142/Spellpad%20Update%20Files/Update/Revisions/{0}/WhatsNew.txt", ProductVersion));
                HttpWebResponse update_versionResponse = (HttpWebResponse)update_versionRequest.GetResponse();
                StreamReader update_versionReader = new StreamReader(update_versionResponse.GetResponseStream());
                textBox1.AppendText(update_versionReader.ReadToEnd());
                textBox1.ReadOnly = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected Network error occured. Window will now close", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
    }
}
