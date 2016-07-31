using Spellpad.Classes;
using Spellpad.Classes.Ini;
using Spellpad.Forms.Spellpad_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frm_RenameDictionary : Form
    {
        string oldDictFile;
        string oldDictName;
        string oldDictExt;

        private frm_Settings formEditDict;
        public frm_RenameDictionary(frm_Settings formSettings)
        {
            formEditDict = formSettings;
            InitializeComponent();

            if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
            {
                oldDictFile = Variables.DefaultDictionary;
                oldDictName = Path.GetFileNameWithoutExtension(Variables.DefaultDictionary);
                oldDictExt = Path.GetExtension(oldDictFile);
                this.Text = string.Format("Rename Dictionary: {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
            }
            else
            {
                oldDictFile = ini_GlobalSettings.Read("Custom Dictionaries", Variables.EditingDictionary);
                oldDictName = Path.GetFileNameWithoutExtension(oldDictFile);
                oldDictExt = Path.GetExtension(oldDictFile);
                this.Text = string.Format("Rename Dictionary: {0}", Path.GetFileNameWithoutExtension(Variables.EditingDictionary));
            }
        }

        public void ChangeDictionaryName(string NewName)
        {
            formEditDict.ChangeDictionaryName(NewName);
        }

        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
        private void btnRename_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_NewName.Text))
            {
                MessageBox.Show("Empty Dictionary name isn't a valid Dictionary name.", "Dictionary Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtbx_NewName.Text == oldDictName)
                {
                    MessageBox.Show("New Dictionary name can't be the same as the old Dictionary name.", "Dictionary Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (File.Exists(oldDictFile))
                    {
                        if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
                        {
                            string newDictFile = string.Format(@"{0}\{2}{1}", Path.GetDirectoryName(oldDictFile), oldDictExt, txtbx_NewName.Text);
                            File.Move(oldDictFile, newDictFile);
                            ini_GlobalSettings.Write("Spellcheck", "Default_Dictionary", newDictFile);
                            ini_GlobalSettings.DeleteKey("Custom Dictionaries", oldDictName);
                            ini_GlobalSettings.Write("Custom Dictionaries", txtbx_NewName.Text, newDictFile);
                            Variables.DefaultDictionary = ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary");
                            ChangeDictionaryName(txtbx_NewName.Text);
                            this.Close();
                        }
                        else
                        {
                            string newDictFile = string.Format(@"{0}\{2}{1}", Path.GetDirectoryName(oldDictFile), oldDictExt, txtbx_NewName.Text);
                            File.Move(oldDictFile, newDictFile);
                            ini_GlobalSettings.DeleteKey("Custom Dictionaries", oldDictName);
                            ini_GlobalSettings.Write("Custom Dictionaries", txtbx_NewName.Text, newDictFile);
                            ChangeDictionaryName(txtbx_NewName.Text);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
