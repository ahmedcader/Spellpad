using Spellpad.Classes;
using Spellpad.Classes.Ini;
using Spellpad.Forms.Spellpad_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frm_EditRecents : Form
    {
        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);

        private frm_Settings formSettings;
        public frm_EditRecents(frm_Settings settings)
        {
            formSettings = settings;

            InitializeComponent();
            foreach (var recentItem in frm_Main.listWithRecents)
            {
                chkklb_RecentsMenu.Items.Add(recentItem);
            }

        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            if (Variables.Editor_WarnBeforeClear)
            {
                DialogResult clearConfirmRecents = MessageBox.Show("You're about to clear the recents file list. Continue?", "Clear Recents List", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (clearConfirmRecents == DialogResult.Yes)
                {
                    MruMenu mru = new MruMenu();
                    mru.ClearRecents(frm_Main.listWithRecents);
                    chkklb_RecentsMenu.Items.Clear();
                    foreach (var recentItem in frm_Main.listWithRecents)
                    {
                        chkklb_RecentsMenu.Items.Add(recentItem);
                    }
                    btn_RemoveSelected.Enabled = false;
                    btn_ClearAll.Enabled = false;
                    formSettings.DisableButtons();
                }
                else if (clearConfirmRecents == DialogResult.No)
                { }
            }
            else
            {
                MruMenu mru = new MruMenu();
                mru.ClearRecents(frm_Main.listWithRecents);
                chkklb_RecentsMenu.Items.Clear();
                foreach (var recentItem in frm_Main.listWithRecents)
                {
                    chkklb_RecentsMenu.Items.Add(recentItem);
                }
                btn_RemoveSelected.Enabled = false;
                btn_ClearAll.Enabled = false;
                formSettings.DisableButtons();
            }
        }

        private void chkklb_RecentsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(chkklb_RecentsMenu.SelectedIndex == -1))
            {
                if (chkklb_RecentsMenu.CheckedItems.Count > 0)
                    btn_RemoveSelected.Enabled = true;
                else
                    btn_RemoveSelected.Enabled = false;
            }
        }

        private void btn_RemoveSelected_Click(object sender, EventArgs e)
        {
            string removelistitem = chkklb_RecentsMenu.SelectedItem.ToString();
            foreach (Object checkedItem in chkklb_RecentsMenu.CheckedItems)
            {
                ini_GlobalSettings.DeleteKey("Recent List", checkedItem.ToString());
                frm_Main.listWithRecents.Remove(checkedItem.ToString());
            }
            chkklb_RecentsMenu.CheckedItems.OfType<string>().ToList().ForEach(chkklb_RecentsMenu.Items.Remove);
            btn_RemoveSelected.Enabled = false;

            if (chkklb_RecentsMenu.Items.Count > 0)
            {
                btn_ClearAll.Enabled = true;
                btn_RemoveSelected.Enabled = false;
            }
            else
            {
                btn_ClearAll.Enabled = false;
            }
            formSettings.DisableButtons();
        }
    }
}
