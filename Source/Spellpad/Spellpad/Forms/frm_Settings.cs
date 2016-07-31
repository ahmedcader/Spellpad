using System;
using Spellpad.Classes;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Spellpad.Classes.Ini;
using System.IO;
using Ionic.Zip;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;

namespace Spellpad.Forms.Spellpad_Forms
{

    public partial class frm_Settings : Form
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        protected override void CreateHandle()
        {
            base.CreateHandle();
            SetWindowTheme(treeView1.Handle, "explorer", null);
        }

        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);

        string GUID = "{E4B9A575-60B6-4F8E-9388-F126473A8DE6}";
        string keyName = "ASpellpad";
        string keyNameXP = "ASpellpad";
        private void EditContextMenuRegistry()
        {

            if (chkbxDisableContextMenu.Checked)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("AssemblyRegister.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("AssemblyUnregister.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(startInfo);
                chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
            }
        }

        void checkAdmin()
        {
            if (IsAdministrator())
            {
                lblAdminNeed.Visible = false;
                chkbxDisableContextMenu.Visible = true;
            }
            else
            {
                lblAdminNeed.Visible = true;
                chkbxDisableContextMenu.Visible = false;
            }
        }


        private frm_Main formMain;
        public frm_Settings(frm_Main main)
        {
            formMain = main;

            InitializeComponent();

            OperatingSystem osInfo = Environment.OSVersion;
            if (osInfo.Platform == PlatformID.Win32NT)
            {
                switch (osInfo.Version.Major)
                {
                    case 5:
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                            case 1:
                            case 2:
                                var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"*\shell\" + keyNameXP);
                                if (key == null)
                                {
                                    chkbxDisableContextMenu.Checked = false;
                                    chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
                                }
                                else
                                {
                                    chkbxDisableContextMenu.Checked = true;
                                    chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
                                }
                                break;
                        }
                        break;

                    case 6:
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                            case 1:
                            case 2:
                                var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"*\shellex\ContextMenuHandlers\" + keyName);
                                if (key == null)
                                {
                                    chkbxDisableContextMenu.Checked = false;
                                    chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
                                }
                                else
                                {
                                    chkbxDisableContextMenu.Checked = true;
                                    chkbxDisableContextMenu.Text = "'Edit with Spellpad' context menu entry";
                                }
                                break;
                        }
                        break;
                }
            }



            CreateHandle();
            flowLayoutPanel1.AutoScroll = false;

            #region Color Settings
            Color editorBackColor = ColorTranslator.FromHtml(Variables.Editor_BackColor);
            pbcl_editorBackColor.BackColor = editorBackColor;

            Color editorForeColor = ColorTranslator.FromHtml(Variables.Editor_ForeColor);
            pbcl_editorForeColor.BackColor = editorForeColor;

            Color editorSelectionColor = ColorTranslator.FromHtml(Variables.Editor_SelectionColor);
            pbcl_selectionColor.BackColor = editorSelectionColor;
            #endregion

            checkAdmin();

            recentsCount.Value = Convert.ToInt32(Variables.Editor_RecentNumber);

            if (frm_Main.listWithRecents.Any())
            {
                btn_editRecentsList.Enabled = true;
                btn_ClearRecents.Enabled = true;
            }

            if (Variables.Editor_WarnBeforeClear)
                chkbx_warnClearRecents.Checked = true;
            else
                chkbx_warnClearRecents.Checked = false;

            #region Spellcheck Enabled/Disabled Setting
            if (Variables.Editor_SpellEnable)
                chkbx_EnableSpellcheck.Checked = true;
            else
                chkbx_EnableSpellcheck.Checked = false;
            #endregion

            #region LargeToolbar Visible Setting
            if (Variables.Editor_LargeToolbar)
                chkbx_LargeToolbar.Checked = true;
            else
                chkbx_LargeToolbar.Checked = false;
            #endregion

            #region Statusbar Visible Setting
            if (Variables.Editor_Statusbar)
                chkbx_StatusBar.Checked = true;
            else
                chkbx_StatusBar.Checked = false;
            #endregion

            #region WordWrapping On/Off Setting
            if (Variables.Editor_WordWrap)
                chkbx_TextWrapping.Checked = true;
            else
                chkbx_TextWrapping.Checked = false;
            #endregion

            #region Quickbar Visible Setting
            if (Variables.Editor_QuickBar)
                chkbx_QuickToolbar.Checked = true;
            else
                chkbx_QuickToolbar.Checked = false;
            #endregion

            #region Font Initalization
            foreach (FontFamily font in FontFamily.Families)
                cmb_Fonts.Items.Add(font.Name);

            string[] Sizes = { "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };
            cmb_Size.Items.AddRange(Sizes);

            cmb_Fonts.SelectedItem = Variables.Editor_Font;
            cmb_Size.SelectedItem = Variables.Editor_FontSize.ToString();
            #endregion

            #region Dictionary Settings
            txtbx_GlobalDicLocation.Text = Variables.Global_CustomDictionary;

            if (!Variables.List_AddedDictionaries.Contains(Variables.DefaultDictionary))
            {
                foreach (var item in Variables.List_RemovingDictionaries)
                    ini_GlobalSettings.DeleteKey("Custom Dictionaries", Path.GetFileNameWithoutExtension(item));
                groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
            }

            foreach (var dictName in IniFile.GetKeys(Variables.IniSettingsPath, "Custom Dictionaries").ToList())
            {
                string properDictName = ini_GlobalSettings.Read("Custom Dictionaries", dictName);
                Variables.List_AddedDictionaries.Add(properDictName);
                lstbx_customDictLocations.Items.Add(Path.GetFileNameWithoutExtension(properDictName));
            }

            if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
            {
                if (Variables.List_AddedDictionaries.Contains(Variables.DefaultDictionary))
                {
                    lstbx_customDictLocations.SetItemChecked(lstbx_customDictLocations.Items.IndexOf(Path.GetFileNameWithoutExtension(Variables.DefaultDictionary)), true);
                    lstbx_customDictLocations.SetSelected(lstbx_customDictLocations.Items.IndexOf(Path.GetFileNameWithoutExtension(Variables.DefaultDictionary)), true);
                    groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
                }
            }
            else
            {
                groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.Global_CustomDictionary));
            }

            #endregion

            foreach (var backupHistoryItem in IniFile.GetKeys(Variables.IniSettingsPath, "Backup History").ToList())
            {
                lstbx_BackupHistory.Items.Add(backupHistoryItem);
            }

            if (lstbx_BackupHistory.Items.Count != 0)
                btn_ClearHistoryBack.Enabled = true;
            else
                btn_ClearHistoryBack.Enabled = false;

            if (Variables.NeedSaveSettings)
                btn_Save.Enabled = true;
            else
                btn_Save.Enabled = false;

            if (Variables.mustRestoreDefault)
                btn_Default.Enabled = true;
            else
                btn_Default.Enabled = false;

        }

        private void btn_SelectGlobalDic_Click(object sender, EventArgs e)
        {
            #region Select Global .dic Location
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Lexicon Dictionary File|*.lex|Dictionary File|*.dic|Data File|*.dat|Text File|*.txt|Custom File|*.*";
            openFile.FilterIndex = 1;
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Variables.Global_CustomDictionary = openFile.FileName;
                txtbx_GlobalDicLocation.Text = Variables.Global_CustomDictionary;
                ini_GlobalSettings.Write("Spellcheck", "Global_CustomDictionary", Variables.Global_CustomDictionary);

                if (!(lstbx_customDictLocations.CheckedItems.Count > 0))
                {
                    Variables.Global_CustomDictionary = openFile.FileName;
                    groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.Global_CustomDictionary));
                    Variables.PutWordsInList();
                }
            }
            #endregion
        }

        private void btn_addCusDictLoc_Click(object sender, EventArgs e)
        {
            #region Add Custom Dictionaries
            OpenFileDialog openGlobalDictFile = new OpenFileDialog();
            openGlobalDictFile.Filter = "Lexicon Dictionary File|*.lex|Dictionary File|*.dic|Data File|*.dat|Text File|*.txt|Custom File|*.*";
            openGlobalDictFile.FilterIndex = 5;
            if (openGlobalDictFile.ShowDialog() == DialogResult.OK)
            {
                string customDictFileName = Path.GetFileNameWithoutExtension(openGlobalDictFile.FileName);
                string customDictPath = openGlobalDictFile.FileName;

                if (customDictPath == Variables.Global_CustomDictionary)
                {
                    DialogResult downloadExisits = MessageBox.Show("Select another dictionary which isn't being used as the Global Dictionary.", "Cannot Add Dictionary", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (downloadExisits == DialogResult.OK)
                    {
                        btn_addCusDictLoc.PerformClick();
                    }
                }
                else
                {
                    if (!lstbx_customDictLocations.Items.Contains(customDictFileName))
                    {
                        lstbx_customDictLocations.Items.Add(customDictFileName);
                        Variables.List_AddedDictionaries.Add(customDictPath);
                        ini_GlobalSettings.Write("Custom Dictionaries", customDictFileName, customDictPath);
                        Variables.PutWordsInList();
                        Variables.LoadWordsFromDictionaries();
                        Variables.InitializeDictionary(Variables._TextBox, Variables.Global_CustomDictionary);
                    }
                }
            }
            #endregion
        }

        private void lstbx_customDictLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(lstbx_customDictLocations.SelectedIndex == -1))
            {
                btn_removeCusDictLoc.Enabled = true;
                btn_editDict.Enabled = true;
                btn_RenameDict.Enabled = true;

                foreach (Object checkedItem in lstbx_customDictLocations.CheckedItems)
                {
                    Variables.DefaultDictionary = ini_GlobalSettings.Read("Custom Dictionaries", checkedItem.ToString());
                    ini_GlobalSettings.Write("Spellcheck", "Default_Dictionary", Variables.DefaultDictionary);
                    Variables.DefaultDictionary = ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary");
                    groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
                    Variables.PutWordsInList();
                }
            }
        }

        private void btn_removeCusDictLoc_Click(object sender, EventArgs e)
        {
            #region Remove Dictionary
            string removelistitem = lstbx_customDictLocations.SelectedItem.ToString();
            string fileWithExtension = ini_GlobalSettings.Read("Custom Dictionaries", lstbx_customDictLocations.SelectedItem.ToString());

            for (int n = lstbx_customDictLocations.Items.Count - 1; n >= 0; --n)
            {
                if (lstbx_customDictLocations.Items[n].ToString().Contains(removelistitem))
                {
                    groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.Global_CustomDictionary));
                    lstbx_customDictLocations.Items.RemoveAt(n);
                    Variables.List_AddedDictionaries.Remove(fileWithExtension);
                    ini_GlobalSettings.DeleteKey("Custom Dictionaries", Path.GetFileNameWithoutExtension(fileWithExtension));
                    ini_GlobalSettings.DeleteKey("Spellcheck", "Default_Dictionary");
                    Variables.DefaultDictionary = null;
                    lstbx_customDictLocations.SelectedIndex = -1;

                    btn_removeCusDictLoc.Enabled = false;
                    btn_editDict.Enabled = false;
                    btn_RenameDict.Enabled = false;

                    Variables.PutWordsInList();
                }
            }
            #endregion
        }

        public void ChangeDictionaryName(string NewName)
        {
            lstbx_customDictLocations.Items[lstbx_customDictLocations.SelectedIndex] = NewName;
            if (lstbx_customDictLocations.CheckedItems.Count != 0)
            {
                groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
            }
        }

        private frm_EditDictionary _EditDictionary;
        private void btn_editDict_Click(object sender, EventArgs e)
        {
            Variables.tabIndex = 0;
            Variables.isGlobalDict = false;
            Variables.EditingDictionary = lstbx_customDictLocations.SelectedItem.ToString();
            _EditDictionary = new frm_EditDictionary(this);
            _EditDictionary.ShowDialog();
        }

        private void btn_editGlobalDict_Click(object sender, EventArgs e)
        {
            Variables.isGlobalDict = true;
            Variables.EditingDictionary = "GlobalDictionary.dic";
            _EditDictionary = new frm_EditDictionary(this);
            _EditDictionary.ShowDialog();
        }


        private void pbcl_editorBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog editorBackColor = new ColorDialog();
            if (editorBackColor.ShowDialog() == DialogResult.OK)
            {
                pbcl_editorBackColor.BackColor = editorBackColor.Color;
                Variables.HasAlteredSettings = true;
                Variables.mustRestoreDefault = true;
                btn_Apply.Enabled = true;
                btn_Save.Enabled = true;
            }
        }

        private static string HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }


        private void pbcl_editorForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog editorForeColor = new ColorDialog();
            if (editorForeColor.ShowDialog() == DialogResult.OK)
            {
                pbcl_editorForeColor.BackColor = editorForeColor.Color;
                Variables.HasAlteredSettings = true;
                Variables.mustRestoreDefault = true;
                btn_Apply.Enabled = true;
                btn_Save.Enabled = true;
            }
        }

        private void pbcl_selectionColor_Click(object sender, EventArgs e)
        {
            ColorDialog editorSelectionColor = new ColorDialog();
            if (editorSelectionColor.ShowDialog() == DialogResult.OK)
            {
                pbcl_selectionColor.BackColor = editorSelectionColor.Color;
                Variables.HasAlteredSettings = true;
                Variables.mustRestoreDefault = true;
                btn_Apply.Enabled = true;
                btn_Save.Enabled = true;
            }
        }

        private void lstbx_customDictLocations_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < lstbx_customDictLocations.Items.Count; ++ix)
            {
                if (ix != e.Index) lstbx_customDictLocations.SetItemChecked(ix, false);
                if (lstbx_customDictLocations.GetItemChecked(ix))
                {
                    ini_GlobalSettings.DeleteKey("Spellcheck", "Default_Dictionary");
                    Variables.DefaultDictionary = null;
                    Variables.DefaultDictionary = ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary");
                    if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
                        groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.DefaultDictionary));
                    else
                        groupBox2.Text = String.Format("Selected Dictionary : {0}", Path.GetFileNameWithoutExtension(Variables.Global_CustomDictionary));
                    Variables.PutWordsInList();
                }
            }
        }

        private void btn_ClearRecents_Click(object sender, EventArgs e)
        {
            if (Variables.Editor_WarnBeforeClear)
            {
                DialogResult clearConfirmRecents = MessageBox.Show("You're about to clear the recents file list. Continue?", "Clear Recents List", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (clearConfirmRecents == DialogResult.Yes)
                {
                    MruMenu mru = new MruMenu();
                    mru.ClearRecents(frm_Main.listWithRecents);

                    if (!frm_Main.listWithRecents.Any())
                    {
                        btn_editRecentsList.Enabled = false;
                        btn_ClearRecents.Enabled = false;
                    }
                }
                else if (clearConfirmRecents == DialogResult.No)
                { }
            }
            else
            {
                MruMenu mru = new MruMenu();
                mru.ClearRecents(frm_Main.listWithRecents);

                if (!frm_Main.listWithRecents.Any())
                {
                    btn_editRecentsList.Enabled = false;
                    btn_ClearRecents.Enabled = false;
                }
            }

        }

        private void recentsCount_ValueChanged(object sender, EventArgs e)
        {
            if (recentsCount == this.ActiveControl)
            {
                Variables.HasAlteredSettings = true;
                btn_Apply.Enabled = true;
                btn_Save.Enabled = true;
            }
        }

        public void DisableButtons()
        {
            if (!frm_Main.listWithRecents.Any())
            {
                btn_editRecentsList.Enabled = false;
                btn_ClearRecents.Enabled = false;
            }
        }
        private void btn_editRecentsList_Click(object sender, EventArgs e)
        {
            var editRecents = new frm_EditRecents(this);
            editRecents.ShowDialog();
        }

        private void btn_ChooseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog chooseBackDir = new FolderBrowserDialog();
            chooseBackDir.ShowNewFolderButton = true;
            if (chooseBackDir.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(chooseBackDir.SelectedPath))
                {
                    txtbx_BackupSaveDir.Text = chooseBackDir.SelectedPath;
                    btn_CreateBackup.Enabled = true;
                }
            }
        }

        private void createZip()
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(Path.GetDirectoryName(Variables.IniSettingsPath), "Settings");
                zip.AddDirectory(Variables.DictionaryPath, "Dictionary");
                zip.Save(Path.Combine(txtbx_BackupSaveDir.Text, string.Format("{0} {1} Settings Backup.sbf", ProductName, ProductVersion)));
            }

            btn_ChooseDir.Enabled = true;
            lstbx_BackupHistory.Items.Add(DateTime.Now.ToString("f"));

            ini_GlobalSettings.Write("Backup History", DateTime.Now.ToString("f"), "");
            btn_ClearHistoryBack.Enabled = true;
        }

        private void btn_CreateBackup_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(txtbx_BackupSaveDir.Text, string.Format("{0} {1} Settings Backup.sbf", ProductName, ProductVersion))))
            {
                DialogResult replaceExistingBackup = MessageBox.Show("There is already a backup file in this directory. Do you want to replace it with the current one?", "Bakup Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (replaceExistingBackup == DialogResult.Yes)
                {
                    createZip();
                }
                else if (replaceExistingBackup == DialogResult.No)
                {
                    btn_ChooseDir.PerformClick();
                }
            }
            else
            {
                createZip();
            }
        }

        private void txtbx_BackupSaveDir_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(txtbx_BackupSaveDir.Text))
                btn_CreateBackup.Enabled = true;
            else
                btn_CreateBackup.Enabled = false;
        }

        private void btn_RestoreBackup_Click(object sender, EventArgs e)
        {
            OpenFileDialog openBackup = new OpenFileDialog();
            openBackup.Title = "Choose Backup File";
            openBackup.Filter = "Spellpad Backup File|*.sbf";
            if (openBackup.ShowDialog() == DialogResult.OK)
            {
                Variables.Unzip(openBackup.FileName, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName));

                DialogResult takeEffect = MessageBox.Show(string.Format("Dictionaries and Settings have been restored. For {0} to fully take effect, restart the program. Saving settings now will replace the restored setting. Do you want to restart {0} now?", ProductName), "Backup Restored", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (takeEffect == DialogResult.Yes)
                {
                    if (Variables.hasMadeChanges)
                    {
                        formMain._TriggerSave();
                        Application.Restart();
                    }
                    else
                    {
                        Application.Restart();
                    }
                }
                else if (takeEffect == DialogResult.No)
                { }

            }
        }

        private void btn_ClearHistoryBack_Click(object sender, EventArgs e)
        {
            foreach (var backupHistoryItem in IniFile.GetKeys(Variables.IniSettingsPath, "Backup History").ToList())
            {
                ini_GlobalSettings.DeleteKey("Backup History", backupHistoryItem);
            }
            lstbx_BackupHistory.Items.Clear();
            btn_ClearHistoryBack.Enabled = false;
        }
        private frm_RenameDictionary _RenameDictionary;
        private void btn_RenameDict_Click(object sender, EventArgs e)
        {
            _RenameDictionary = new frm_RenameDictionary(this);
            _RenameDictionary.ShowDialog();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            #region Apply Spellcheck Enabled
            Variables.Editor_SpellEnable = Convert.ToBoolean(chkbx_EnableSpellcheck.Checked.ToString());
            formMain.SpellCheckOnOff(Convert.ToBoolean(Variables.Editor_SpellEnable));
            #endregion

            #region Apply Font Name
            Variables.Editor_Font = cmb_Fonts.SelectedItem.ToString();
            Font font = new Font(new FontFamily(Variables.Editor_Font), Variables.Editor_FontSize);
            System.Windows.Media.FontFamily mfont = new System.Windows.Media.FontFamily(font.Name);
            formMain.ChangeFontName(mfont);
            #endregion

            #region Apply Font Size
            Variables.Editor_FontSize = Convert.ToInt32(cmb_Size.SelectedItem.ToString());
            formMain.ChangeFontSize(Variables.PointsToPixels(Variables.Editor_FontSize));
            #endregion

            #region Textbox Backcolor
            Variables.Editor_BackColor = HexConverter(pbcl_editorBackColor.BackColor);
            formMain.ChangeBackColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_BackColor)));
            #endregion

            #region Textbox FontColor
            Variables.Editor_ForeColor = HexConverter(pbcl_editorForeColor.BackColor);
            formMain.ChangeForeColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_ForeColor)));
            #endregion

            #region Textbox SelectionColor
            Variables.Editor_SelectionColor = HexConverter(pbcl_selectionColor.BackColor);
            formMain.ChangeSelectionColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_SelectionColor)));
            #endregion

            #region Apply QuickToolbar
            Variables.Editor_QuickBar = Convert.ToBoolean(chkbx_QuickToolbar.Checked.ToString());
            formMain.QuickbarVisible(Convert.ToBoolean(Variables.Editor_QuickBar));
            #endregion

            #region Apply WordWrap
            Variables.Editor_WordWrap = Convert.ToBoolean(chkbx_TextWrapping.Checked.ToString());
            formMain.WordWrapOnOff(Convert.ToBoolean(Variables.Editor_WordWrap));
            #endregion

            #region Apply StatusBar Visibility
            Variables.Editor_Statusbar = Convert.ToBoolean(chkbx_StatusBar.Checked.ToString());
            formMain.StatusBarOnOff(Convert.ToBoolean(Variables.Editor_Statusbar));
            #endregion

            #region Apply LargeToolbar
            Variables.Editor_LargeToolbar = Convert.ToBoolean(chkbx_LargeToolbar.Checked.ToString());
            formMain.LargeToolbar(Convert.ToBoolean(Variables.Editor_LargeToolbar));
            formMain.CheckEdits();
            #endregion

            #region Apply Warn Clear Recents
            Variables.Editor_WarnBeforeClear = Convert.ToBoolean(chkbx_warnClearRecents.Checked.ToString());
            #endregion

            #region Apply Recents Count
            Variables.Editor_RecentNumber = Convert.ToString(recentsCount.Value);
            #endregion

            btn_Apply.Enabled = false;
            btn_Save.Enabled = true;
            btn_Default.Enabled = true;
            Variables.NeedSaveSettings = true;
            Variables.mustRestoreDefault = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            #region Save and Apply Spellcheck
            Variables.Editor_SpellEnable = Convert.ToBoolean(chkbx_EnableSpellcheck.Checked.ToString());
            ini_GlobalSettings.Write("Editor", "Editor_Spellcheck", Variables.Editor_SpellEnable.ToString());
            formMain.SpellCheckOnOff(Convert.ToBoolean(Variables.Editor_SpellEnable));
            #endregion

            #region Save and Apply Font Size
            Variables.Editor_FontSize = int.Parse(cmb_Size.SelectedItem.ToString());
            ini_GlobalSettings.Write("Editor", "Editor_FontSize", Variables.Editor_FontSize.ToString());
            formMain.ChangeFontSize(Variables.PointsToPixels(Variables.Editor_FontSize));
            #endregion

            #region Save and Apply Font Name
            Variables.Editor_Font = cmb_Fonts.SelectedItem.ToString();
            ini_GlobalSettings.Write("Editor", "Editor_Font", Variables.Editor_Font);
            Font font = new Font(new FontFamily(Variables.Editor_Font), Variables.Editor_FontSize);
            System.Windows.Media.FontFamily mfont = new System.Windows.Media.FontFamily(font.Name);
            formMain.ChangeFontName(mfont);
            #endregion

            #region Save and Apply Textbox BackColor
            Variables.Editor_BackColor = HexConverter(pbcl_editorBackColor.BackColor);
            ini_GlobalSettings.Write("Editor", "Editor_BackColor", Variables.Editor_BackColor);
            formMain.ChangeBackColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_BackColor)));
            #endregion

            #region Save and Apply Textbox FontColor
            Variables.Editor_ForeColor = HexConverter(pbcl_editorForeColor.BackColor);
            ini_GlobalSettings.Write("Editor", "Editor_ForeColor", Variables.Editor_ForeColor);
            formMain.ChangeForeColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_ForeColor)));

            #endregion

            #region Save and Apply Textbox SelectionColor
            Variables.Editor_SelectionColor = HexConverter(pbcl_selectionColor.BackColor);
            ini_GlobalSettings.Write("Editor", "Editor_SelectionColor", Variables.Editor_SelectionColor);
            formMain.ChangeSelectionColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_SelectionColor)));
            #endregion

            #region Save and Apply Quicktoolbar Visibility
            ini_GlobalSettings.Write("Editor", "Editor_Quickbar", Variables.Editor_QuickBar.ToString());
            formMain.QuickbarVisible(Convert.ToBoolean(Variables.Editor_QuickBar));
            #endregion

            #region Save and Apply Wordwrap
            ini_GlobalSettings.Write("Editor", "Editor_WordWrap", Variables.Editor_WordWrap.ToString());
            formMain.WordWrapOnOff(Convert.ToBoolean(Variables.Editor_WordWrap));
            #endregion

            #region Save and Apply Statusbar Visibility
            ini_GlobalSettings.Write("Editor", "Editor_Statusbar", Variables.Editor_Statusbar.ToString());
            formMain.StatusBarOnOff(Convert.ToBoolean(Variables.Editor_Statusbar));
            #endregion

            #region Save and Apply LargeToolbar
            ini_GlobalSettings.Write("Editor", "Editor_LargeToolbar", Variables.Editor_LargeToolbar.ToString());
            formMain.LargeToolbar(Convert.ToBoolean(Variables.Editor_LargeToolbar));
            formMain.CheckEdits();
            #endregion

            #region Save and Apply Warn Clear Recents
            Variables.Editor_WarnBeforeClear = Convert.ToBoolean(chkbx_warnClearRecents.Checked.ToString());
            ini_GlobalSettings.Write("Editor", "Editor_WarnClearRecents", Variables.Editor_WarnBeforeClear.ToString());
            Variables.Editor_WarnBeforeClear = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_WarnClearRecents"));
            #endregion

            #region Save and Apply Recents Count
            Variables.Editor_RecentNumber = Convert.ToString(recentsCount.Value);
            ini_GlobalSettings.Write("Editor", "Editor_RecentNumber", Variables.Editor_RecentNumber);
            #endregion

            btn_Save.Enabled = false;
            btn_Apply.Enabled = false;
            Variables.HasAlteredSettings = false;
            Variables.NeedSaveSettings = false;
            Variables.mustRestoreDefault = true;
            this.Close();
        }

        private void btn_Default_Click(object sender, EventArgs e)
        {
            Variables.Editor_Font = "Microsoft Sans Serif";
            ini_GlobalSettings.Write("Editor", "Editor_Font", Variables.Editor_Font);
            cmb_Fonts.SelectedItem = Variables.Editor_Font;
            Font font = new Font(new FontFamily(Variables.Editor_Font), Variables.Editor_FontSize);
            System.Windows.Media.FontFamily mfont = new System.Windows.Media.FontFamily(font.Name);
            formMain.ChangeFontName(mfont);

            Variables.Editor_FontSize = 14;
            ini_GlobalSettings.Write("Editor", "Editor_Font", Variables.Editor_Font);
            cmb_Size.SelectedItem = Convert.ToString(Variables.Editor_FontSize);
            formMain.ChangeFontSize(Variables.PointsToPixels(Variables.Editor_FontSize));

            ini_GlobalSettings.Write("Editor", "Editor_BackColor", "#FFF3D7");
            Variables.Editor_BackColor = ini_GlobalSettings.Read("Editor", "Editor_BackColor");
            pbcl_editorBackColor.BackColor = ColorTranslator.FromHtml(Variables.Editor_BackColor);
            formMain.ChangeBackColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_BackColor)));

            Variables.Editor_ForeColor = "#000000";
            ini_GlobalSettings.Write("Editor", "Editor_ForeColor", Variables.Editor_ForeColor);
            pbcl_editorForeColor.BackColor = ColorTranslator.FromHtml(Variables.Editor_ForeColor);
            formMain.ChangeForeColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_ForeColor)));

            Variables.Editor_SelectionColor = "#FF3399FF";
            ini_GlobalSettings.Write("Editor", "Editor_SelectionColor", Variables.Editor_SelectionColor);
            pbcl_selectionColor.BackColor = ColorTranslator.FromHtml(Variables.Editor_SelectionColor);
            formMain.ChangeSelectionColor((System.Windows.Media.SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_SelectionColor)));

            Variables.Editor_QuickBar = true;
            ini_GlobalSettings.Write("Editor", "Editor_Quickbar", Convert.ToBoolean(Variables.Editor_QuickBar).ToString());
            chkbx_QuickToolbar.Checked = Variables.Editor_QuickBar;
            formMain.QuickbarVisible(Variables.Editor_QuickBar);

            Variables.Editor_WordWrap = true;
            ini_GlobalSettings.Write("Editor", "Editor_WordWrap", Convert.ToBoolean(Variables.Editor_WordWrap).ToString());
            chkbx_TextWrapping.Checked = Variables.Editor_WordWrap;
            formMain.WordWrapOnOff(Variables.Editor_WordWrap);

            Variables.Editor_Statusbar = true;
            ini_GlobalSettings.Write("Editor", "Editor_Statusbar", Convert.ToBoolean(Variables.Editor_Statusbar).ToString());
            chkbx_StatusBar.Checked = Variables.Editor_Statusbar;
            formMain.StatusBarOnOff(Variables.Editor_Statusbar);

            Variables.Editor_LargeToolbar = true;
            ini_GlobalSettings.Write("Editor", "Editor_LargeToolbar", Convert.ToBoolean(Variables.Editor_LargeToolbar).ToString());
            chkbx_LargeToolbar.Checked = Variables.Editor_LargeToolbar;
            formMain.LargeToolbar(Variables.Editor_LargeToolbar);

            Variables.Editor_WarnBeforeClear = true;
            ini_GlobalSettings.Write("Editor", "Editor_WarnClearRecents", Convert.ToBoolean(Variables.Editor_WarnBeforeClear).ToString());
            chkbx_warnClearRecents.Checked = Variables.Editor_WarnBeforeClear;

            Variables.Editor_RecentNumber = "5";
            ini_GlobalSettings.Write("Editor", "Editor_RecentNumber", Variables.Editor_RecentNumber.ToString());
            recentsCount.Value = int.Parse(Variables.Editor_RecentNumber);

            Variables.Editor_SpellEnable = true;
            ini_GlobalSettings.Write("Editor", "Editor_Spellcheck", Convert.ToBoolean(Variables.Editor_SpellEnable).ToString());
            chkbx_EnableSpellcheck.Checked = Variables.Editor_SpellEnable;
            formMain.SpellCheckOnOff(Variables.Editor_SpellEnable);

            btn_Default.Enabled = false;
            btn_Save.Enabled = false;
            btn_Apply.Enabled = false;
            Variables.HasAlteredSettings = false;
            Variables.NeedSaveSettings = false;
            Variables.mustRestoreDefault = false;
        }

        private void cmb_Fonts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
            btn_Save.Enabled = true;
        }

        private void cmb_Size_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
            btn_Save.Enabled = true;
        }

        private void frm_Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmb_Fonts.SelectedItem = Variables.Editor_Font;
            cmb_Size.SelectedItem = Variables.Editor_FontSize;
        }

        private void chkbx_QuickToolbar_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chkbx_TextWrapping_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chkbx_StatusBar_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chkbx_LargeToolbar_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chkbx_warnClearRecents_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chkbx_EnableSpellcheck_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        private void chb_ShowSuggestions_Click(object sender, EventArgs e)
        {
            Variables.HasAlteredSettings = true;
            btn_Apply.Enabled = true;
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Editor")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;

            }
            if (treeView1.SelectedNode.Text == "Appearance")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (treeView1.SelectedNode.Text == "Recents List")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (treeView1.SelectedNode.Text == "Global Dictionary")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (treeView1.SelectedNode.Text == "Custom Dictionaries")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = true;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            if (treeView1.SelectedNode.Text == "Backup Options")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = true;
                panel7.Visible = false;
            }
            if (treeView1.SelectedNode.Text == "Context Menu")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
            }
        }

        private void chkbxDisableContextMenu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkbxDisableContextMenu_Click(object sender, EventArgs e)
        {
            EditContextMenuRegistry();
        }
    }
}
