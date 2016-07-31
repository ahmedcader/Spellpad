using Spellpad.Classes;
using Spellpad.Classes.Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms.Spellpad_Forms
{
    public partial class frm_EditDictionary : Form
    {
        string tempDictPath;
        private frm_Settings formSettings;
        public frm_EditDictionary(frm_Settings settings)
        {
            formSettings = settings;
            InitializeComponent();

            if (!Variables.isGlobalDict)
            {
                this.Text = Variables.EditingDictionary;
                IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
                tempDictPath = ini_GlobalSettings.Read("Custom Dictionaries", Variables.EditingDictionary);
            }
            else
            {
                IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
                tempDictPath = ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary");
                this.Text = Path.GetFileNameWithoutExtension(tempDictPath);
            }

            try
            {
                string[] lines = File.ReadLines(tempDictPath).ToArray();
                foreach (string word in lines)
                {
                    lstbx_DictWords.Items.Add(word);
                }

                if (lstbx_DictWords.Items.Count != 0)
                    btn_DelAllWords.Enabled = true;
                else
                    btn_DelAllWords.Enabled = false;


            }
            catch (FileNotFoundException)
            {
                var myFile = File.Create(tempDictPath);
                myFile.Close();
            }
        }

        private void txtbx_addWord_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbx_addWord.Text))
                btn_AddWord.Enabled = true;
            else
                btn_AddWord.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lstbx_DictWords.SelectedIndex == -1))
                btn_delWord.Enabled = true;
        }

        private void btn_delWord_Click(object sender, EventArgs e)
        {
            lstbx_DictWords.Items.Remove(lstbx_DictWords.SelectedItem);
            btn_delWord.Enabled = false;
            if (lstbx_DictWords.Items.Count != 0)
                btn_DelAllWords.Enabled = true;
            else
                btn_DelAllWords.Enabled = false;
        }

        private void btn_AddWord_Click(object sender, EventArgs e)
        {
            if (!lstbx_DictWords.Items.Contains(txtbx_addWord.Text))
            {
                lstbx_DictWords.Items.Add(txtbx_addWord.Text);
                txtbx_addWord.Text = "";
                txtbx_addWord.Focus();
                txtbx_addWord.Select();
            }
            if (lstbx_DictWords.Items.Count != 0)
                btn_DelAllWords.Enabled = true;
            else
                btn_DelAllWords.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstbx_DictWords.Items.Clear();
            btn_delWord.Enabled = false;
            if (lstbx_DictWords.Items.Count != 0)
                btn_DelAllWords.Enabled = true;
            else
                btn_DelAllWords.Enabled = false;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            StreamWriter SaveFile = new System.IO.StreamWriter(tempDictPath);
            SaveFile.Flush();
            foreach (var item in lstbx_DictWords.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }

            SaveFile.Close();

            Variables.InitializeDictionary(Variables._TextBox, Variables.Global_CustomDictionary);
            this.Close();
        }
    }
}
