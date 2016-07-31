using Spellpad.Classes;
using Spellpad.Classes.Ini;
using Spellpad.Forms.Spellpad_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Controls;

namespace Spellpad.Forms
{
    public partial class frm_FindReplace : Form
    {
        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
        private readonly frm_Main formMain;

        System.Windows.Controls.ComboBox _SearchHistoryBox = new System.Windows.Controls.ComboBox();
        System.Windows.Controls.ComboBox _ReplaceSearchHistoryBox = new System.Windows.Controls.ComboBox();
        System.Windows.Controls.ComboBox _ReplaceWithBox = new System.Windows.Controls.ComboBox();

        public void LoadBoxes()
        {
            _SearchHistoryBox.IsTextSearchCaseSensitive = true;
            _SearchHistoryBox.IsTextSearchEnabled = false;
            _SearchHistoryBox.UseLayoutRounding = true;
            _SearchHistoryBox.IsEditable = true;
            _SearchHistoryBox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(_SearchHistoryBox_TextChanged));
            this.elementHost1.Child = _SearchHistoryBox;

            _ReplaceSearchHistoryBox.IsTextSearchCaseSensitive = true;
            _ReplaceSearchHistoryBox.IsTextSearchEnabled = false;
            _ReplaceSearchHistoryBox.UseLayoutRounding = true;
            _ReplaceSearchHistoryBox.IsEditable = true;
            _ReplaceSearchHistoryBox.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(_ReplaceSearchHistoryBox_TextChanged));
            this.elementHost2.Child = _ReplaceSearchHistoryBox;

            _ReplaceWithBox.IsTextSearchCaseSensitive = true;
            _ReplaceWithBox.IsTextSearchEnabled = false;
            _ReplaceWithBox.UseLayoutRounding = true;
            _ReplaceWithBox.IsEditable = true;
            this.elementHost3.Child = _ReplaceWithBox;


            System.Windows.Media.TextOptions.SetTextFormattingMode(_SearchHistoryBox, System.Windows.Media.TextFormattingMode.Display);
            System.Windows.Media.TextOptions.SetTextFormattingMode(_ReplaceSearchHistoryBox, System.Windows.Media.TextFormattingMode.Display);
            System.Windows.Media.TextOptions.SetTextFormattingMode(_ReplaceWithBox, System.Windows.Media.TextFormattingMode.Display);

        }

        public frm_FindReplace(frm_Main main)
        {
            InitializeComponent();
            formMain = main;

            LoadBoxes();

            #region Initialize Line Count
            if (Variables._TextBox.LineCount > 1)
                lbl_LineCountTotal.Text = String.Format("The current document contains {0} lines in total.", Variables._TextBox.LineCount.ToString("N0"));
            else
                lbl_LineCountTotal.Text = String.Format("The current document contains {0} line in total.", Variables._TextBox.LineCount.ToString("N0"));
            #endregion

            #region Initialize Match Case Checkbox
            if (Variables.Editor_MatchCaseFindings)
            {
                chkbx_MatchCase.Checked = true;
                chkbx_matchCaseRep.Checked = true;
            }
            else
            {
                chkbx_MatchCase.Checked = false;
                chkbx_matchCaseRep.Checked = false;
            }
            #endregion

            #region Load Saved Search
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_SavedSearch")))
            {
                _SearchHistoryBox.Text = ini_GlobalSettings.Read("Editor", "Editor_SavedSearch");
                _ReplaceSearchHistoryBox.Text = ini_GlobalSettings.Read("Editor", "Editor_SavedSearch");
            }
            #endregion


            tab_SearchRepGo.SelectedIndex = Variables.tabIndex;

            #region Check if Search Empty
            if (string.IsNullOrWhiteSpace(_SearchHistoryBox.Text))
            {
                btn_FindNext.Enabled = false;
                btn_FindPrevious.Enabled = false;
            }
            else
            {
                btn_FindNext.Enabled = true;
                btn_FindPrevious.Enabled = true;
            }

            #endregion

            #region Load Search History
            foreach (var word in Variables.List_SearchHistory)
            {
                _SearchHistoryBox.Items.Add(word);
                _ReplaceSearchHistoryBox.Items.Add(word);
            }
            #endregion

            #region Load Replace History
            foreach (var word in Variables.List_ReplaceHistory)
            {
                _ReplaceWithBox.Items.Add(word);
            }
            #endregion

            Variables.alreadyOpenedFind = true;
            tmr_CheckFocus.Start();
        }

        private void _SearchHistoryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ReplaceSearchHistoryBox.Text = _SearchHistoryBox.Text;

            ini_GlobalSettings.Write("Editor", "Editor_SavedSearch", _SearchHistoryBox.Text);
            if (string.IsNullOrWhiteSpace(_SearchHistoryBox.Text))
            {
                btn_FindNext.Enabled = false;
                btn_FindPrevious.Enabled = false;
            }
            else
            {
                btn_FindNext.Enabled = true;
                btn_FindPrevious.Enabled = true;
            }
        }

        private void _ReplaceSearchHistoryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _SearchHistoryBox.Text = _ReplaceSearchHistoryBox.Text;
            ini_GlobalSettings.Write("Editor", "Editor_SavedSearch", _SearchHistoryBox.Text);

            if (string.IsNullOrWhiteSpace(_SearchHistoryBox.Text))
            {
                btn_FindNextRep.Enabled = false;
            }
            else
            {
                btn_FindNextRep.Enabled = true;
            }
        }

        public void FocusGoTo()
        {
            txtbx_GoTo.Focus();
            txtbx_GoTo.Select(txtbx_GoTo.Text.Length, 0);
        }

        public void ShowFirst()
        {
            lbl_searchStatus.Text = string.Format("Found the first occurrence of '{0}' in the document.\nReached the beginning of the document.", _SearchHistoryBox.Text);
            lbl_searchStatus.ForeColor = Color.DarkGreen;
            tmr_RefreshStatus.Stop();
            tmr_RefreshStatus.Start();
        }

        public void ShowLast()
        {
            lbl_searchStatus.Text = string.Format("Found the last occurrence of '{0}' in the document.\nReached the end of the document.", _SearchHistoryBox.Text);
            lbl_searchStatus.ForeColor = Color.DarkGreen;
            tmr_RefreshStatus.Stop();
            tmr_RefreshStatus.Start();
        }
        public void ShowNone()
        {
            lbl_searchStatus.Text = string.Format("Couldn't find '{0}' in the document.", _SearchHistoryBox.Text);
            lbl_searchStatus.ForeColor = Color.Red;
            tmr_RefreshStatus.Stop();
            tmr_RefreshStatus.Start();
        }

        public void PerformNextClick()
        {
            btn_FindNext.PerformClick();
        }

        string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, "Settings");
        private void HISTORY_writetoFile(string path, List<string> items_List)
        {

            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var item in items_List)
                {
                    sw.WriteLine(item);
                }
            }
        }

        private void btn_FindNext_Click(object sender, EventArgs e)
        {
            if (!_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | !_ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
            {
                Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                _ReplaceSearchHistoryBox.Items.Insert(0, _ReplaceSearchHistoryBox.Text);
                _SearchHistoryBox.Items.Insert(0, _SearchHistoryBox.Text);

                File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in Variables.List_SearchHistory)
                    {
                        sw.WriteLine(item);
                    }
                }
                formMain.MoveToNextMatch(Variables._TextBox, true, Convert.ToBoolean(chkbx_MatchCase.Checked.ToString()), _SearchHistoryBox.Text);
                int row = Variables._TextBox.GetLineIndexFromCharacterIndex(Variables._TextBox.CaretIndex);
                Variables._TextBox.ScrollToLine(row);
            }
            else if (_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | _ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
            {
                string strToFind = _SearchHistoryBox.Text;

                Variables.List_SearchHistory.Remove(_SearchHistoryBox.Text);
                Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                _ReplaceSearchHistoryBox.Items.Clear();
                _SearchHistoryBox.Items.Clear();

                foreach (var item in Variables.List_SearchHistory)
                {
                    _SearchHistoryBox.Items.Add(item);
                    _ReplaceSearchHistoryBox.Items.Add(item);
                }

                _SearchHistoryBox.Text = strToFind;
                _ReplaceSearchHistoryBox.Text = strToFind;

                File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in Variables.List_SearchHistory)
                    {
                        sw.WriteLine(item);
                    }
                }
                formMain.MoveToNextMatch(Variables._TextBox, true, Convert.ToBoolean(chkbx_MatchCase.Checked.ToString()), _SearchHistoryBox.Text);
                int row = Variables._TextBox.GetLineIndexFromCharacterIndex(Variables._TextBox.CaretIndex);
                Variables._TextBox.ScrollToLine(row);
            }
        }

        private void btn_FindPrevious_Click(object sender, EventArgs e)
        {
            if (!_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text))
            {
                Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                _SearchHistoryBox.Items.Insert(0, _SearchHistoryBox.Text);

                File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in Variables.List_SearchHistory)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            else if (_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text))
            {
                string strToFind = _SearchHistoryBox.Text;

                Variables.List_SearchHistory.Remove(_SearchHistoryBox.Text);
                Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);
                _SearchHistoryBox.Items.Clear();

                foreach (var item in Variables.List_SearchHistory)
                {
                    _SearchHistoryBox.Items.Add(item);
                }

                _SearchHistoryBox.Text = strToFind;

                File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var item in Variables.List_SearchHistory)
                    {
                        sw.WriteLine(item);
                    }
                }

                formMain.MoveToNextMatch(Variables._TextBox, false, Convert.ToBoolean(chkbx_MatchCase.Checked.ToString()), _SearchHistoryBox.Text);
                int row = Variables._TextBox.GetLineIndexFromCharacterIndex(Variables._TextBox.CaretIndex);
                Variables._TextBox.ScrollToLine(row);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbx_GoTo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_GoTo.Text))
                btn_GoTo.Enabled = false;
            else
                btn_GoTo.Enabled = true;
        }

        private void btn_GoTo_Click(object sender, EventArgs e)
        {
            #region GoTo Line
            try
            {
                Variables.MoveCaretToLine(Variables._TextBox, Convert.ToInt32(txtbx_GoTo.Text));
                Variables._TextBox.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't go to Line: " + txtbx_GoTo.Text + " because it doesn't exist.", "Error");
            }
            #endregion
        }

        private void txtbx_GoTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region Only Numbers in GoTo
            if (e.KeyChar != 8)
            {
                if (e.KeyChar < 48 | e.KeyChar > 57)
                {
                    totp_OnlyNumbers.Show("Only numbers are acceptable in this field.", txtbx_GoTo, new Point(0, 45));
                    e.Handled = true;
                }
                else
                {
                    totp_OnlyNumbers.Hide(txtbx_GoTo);
                }
            }
            #endregion
        }

        private void lnklbl_ClearSearchHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Clear All Search History
            File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), String.Empty);
            _SearchHistoryBox.Items.Clear();
            _SearchHistoryBox.Text = string.Empty;

            _ReplaceSearchHistoryBox.Text = string.Empty;
            _ReplaceSearchHistoryBox.Items.Clear();

            foreach (var searchedItem in IniFile.GetKeys(Variables.IniSettingsPath, "Search History").ToList())
            {
                ini_GlobalSettings.DeleteKey("Search History", searchedItem);
            }

            _SearchHistoryBox.Text = "";
            _ReplaceSearchHistoryBox.Text = "";

            Variables.List_SearchHistory.Clear();

            ini_GlobalSettings.DeleteKey("Editor", "Editor_SavedSearch");
            #endregion
        }

        private void chkbx_MatchCase_CheckedChanged(object sender, EventArgs e)
        {
            Variables.Editor_MatchCaseFindings = Convert.ToBoolean(chkbx_MatchCase.Checked.ToString());
            ini_GlobalSettings.Write("Editor", "Editor_MatchCase", Variables.Editor_MatchCaseFindings.ToString());
            chkbx_matchCaseRep.Checked = chkbx_MatchCase.Checked;
        }

        private void chkbx_matchCaseRep_CheckedChanged(object sender, EventArgs e)
        {
            Variables.Editor_MatchCaseFindings = Convert.ToBoolean(chkbx_matchCaseRep.Checked.ToString());
            ini_GlobalSettings.Write("Editor", "Editor_MatchCase", Variables.Editor_MatchCaseFindings.ToString());
            chkbx_MatchCase.Checked = chkbx_matchCaseRep.Checked;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_searchStatus.Text = "";
            tmr_RefreshStatus.Stop();
        }

        private void lnklbl_ClearReplaceHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            #region Clear All Replace History
            _ReplaceWithBox.Text = "";

            if (File.Exists(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder)))
            {
                File.Delete(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder));
                Variables.List_ReplaceHistory.Clear();
                _ReplaceWithBox.Items.Clear();
            }  

            #endregion
        }
        private Regex GetRegExpression()
        {
            Regex result = default(Regex);
            String regExString = default(String);
            // Get what the user entered
            if (tab_SearchRepGo.SelectedIndex == 0)
            {
                regExString = _SearchHistoryBox.Text;
            }
            else if (tab_SearchRepGo.SelectedIndex == 1)
            {
                regExString = _ReplaceSearchHistoryBox.Text;
            }

            Regex baseRegex = new Regex("[\\\\.$^{\\[(|)*+?]");
            regExString = baseRegex.Replace(regExString, "\\$0");

            if (chkbx_matchCaseRep.Checked)
            {
                result = new Regex(regExString);
            }
            else
            {
                result = new Regex(regExString, RegexOptions.IgnoreCase);
            }

            return result;
        }

        public void setFocusSearch()
        {
            if (tab_SearchRepGo.SelectedIndex == 0)
            {
                var textBox = (_SearchHistoryBox.Template.FindName("PART_EditableTextBox", _SearchHistoryBox) as System.Windows.Controls.TextBox);
                if (textBox != null)
                {
                    if (textBox.Focus())
                    {
                        tmr_CheckFocus.Stop();
                    }
                    else
                    {
                        textBox.Focus();
                        textBox.CaretIndex = textBox.Text.Length;
                    }

                }
            }
            else if (tab_SearchRepGo.SelectedIndex == 1)
            {
                var textBox = (_ReplaceSearchHistoryBox.Template.FindName("PART_EditableTextBox", _ReplaceSearchHistoryBox) as System.Windows.Controls.TextBox);
                if (textBox != null)
                {
                    if (textBox.Focus())
                    {
                        tmr_CheckFocus.Stop();
                    }
                    else
                    {
                        textBox.Focus();
                        textBox.CaretIndex = textBox.Text.Length;
                    }

                }
            }
            else if (tab_SearchRepGo.SelectedIndex == 2)
            {
                if (txtbx_GoTo.Focus())
                {
                    tmr_CheckFocus.Stop();
                }
                else
                {
                    txtbx_GoTo.Focus();
                    txtbx_GoTo.SelectionStart = txtbx_GoTo.Text.Length - 1;
                }
            }

        }

        private void btn_ReplaceAll_Click(object sender, EventArgs e)
        {
            Regex regCount = GetRegExpression();
            Regex replaceRegex = GetRegExpression();
            String replacedString = default(String);
            //' get the current SelectionStart
            int selectedPos = Variables._TextBox.SelectionStart;

            //' get the replaced string
            dynamic aCount = regCount.Matches(Variables._TextBox.Text).Count;
            //Dim txtbxText As String = TheTextBox.Text
            //txtbxText = txtbxText.Replace(txtbx_Find.Text, txtbx_Replace.Text)

            replacedString = replaceRegex.Replace(Variables._TextBox.Text, _ReplaceWithBox.Text);
            //' Is the text changed?
            if (Variables._TextBox.Text != replacedString)
            {
                // then replace it
                Variables._TextBox.Text = replacedString;

                tmr_RefreshStatus.Start();
                // restore the SelectionStart
                Variables._TextBox.SelectionStart = selectedPos;
                lnklbl_UndoReplacements.Visible = true;
                Variables._TextBox.Select(Variables._TextBox.Text.Length, 0);
                Variables._TextBox.ScrollToEnd();
                Variables._TextBox.Focus();
                if (aCount < 2)
                {
                    lbl_searchStatus.Text = string.Format("{0} replacement successfully made.", aCount);
                    lbl_searchStatus.ForeColor = Color.DarkGreen;
                    tmr_RefreshStatus.Start();
                }
                else if (aCount > 2)
                {
                    lbl_searchStatus.Text = string.Format("{0} replacements successfully made.", aCount);
                    lbl_searchStatus.ForeColor = Color.DarkGreen;
                    tmr_RefreshStatus.Start();
                }

                if (!_ReplaceWithBox.Items.Contains(_ReplaceWithBox.Text))
                {
                    _ReplaceWithBox.Items.Insert(0, _ReplaceWithBox.Text);
                    Variables.List_ReplaceHistory.Insert(0, _ReplaceWithBox.Text);


                    File.WriteAllText(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_ReplaceHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                if (!_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | !_ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
                {

                    Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                    _ReplaceSearchHistoryBox.Items.Insert(0, _ReplaceSearchHistoryBox.Text);
                    _SearchHistoryBox.Items.Insert(0, _SearchHistoryBox.Text);

                    File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_SearchHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                if (_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | _ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
                {
                    string strToFind = _SearchHistoryBox.Text;

                    Variables.List_SearchHistory.Remove(_SearchHistoryBox.Text);
                    Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                    _ReplaceSearchHistoryBox.Items.Clear();
                    _SearchHistoryBox.Items.Clear();

                    foreach (var item in Variables.List_SearchHistory)
                    {
                        _SearchHistoryBox.Items.Add(item);
                        _ReplaceSearchHistoryBox.Items.Add(item);
                    }

                    _SearchHistoryBox.Text = strToFind;
                    _ReplaceSearchHistoryBox.Text = strToFind;

                    File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_SearchHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                else if (_ReplaceWithBox.Items.Contains(_ReplaceWithBox.Text))
                {
                    string strToFind = _ReplaceWithBox.Text;

                    Variables.List_ReplaceHistory.Remove(_ReplaceWithBox.Text);
                    Variables.List_ReplaceHistory.Insert(0, _ReplaceWithBox.Text);

                    _ReplaceWithBox.Items.Clear();

                    foreach (var item in Variables.List_ReplaceHistory)
                    {
                        _ReplaceWithBox.Items.Add(item);
                    }

                    _ReplaceWithBox.Text = strToFind;

                    File.WriteAllText(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_ReplaceHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }

            }
            else
            {
                lbl_searchStatus.Text = string.Format("Couldn't find '{0}' in the document to replace with '{1}'.", _ReplaceSearchHistoryBox.Text, _ReplaceWithBox.Text);
                lbl_searchStatus.ForeColor = Color.Red;
                tmr_RefreshStatus.Stop();
                tmr_RefreshStatus.Start();
            }
        }

        private void lnklbl_UndoReplacements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Variables._TextBox.Undo();
            lbl_searchStatus.Text = string.Format("Replaces reverted. From '{1}' to '{0}'.", _ReplaceSearchHistoryBox.Text, _ReplaceWithBox.Text);
            lbl_searchStatus.ForeColor = Color.DarkGreen;
            tmr_RefreshStatus.Stop();
            tmr_RefreshStatus.Start();
            lnklbl_UndoReplacements.Visible = false;
        }

        bool isSuccess;

        private Regex regex;
        private Match match;
        private void btn_Replace_Click(object sender, EventArgs e)
        {
            Regex regexTemp = GetRegExpression();
            Match matchTemp = regexTemp.Match(Variables._TextBox.SelectedText);

            if (matchTemp.Success)
            {
                if (matchTemp.Value == Variables._TextBox.SelectedText)
                {
                    Variables._TextBox.SelectedText = _ReplaceWithBox.Text;
                }
            }

            regex = GetRegExpression();
            match = regex.Match(Variables._TextBox.Text);

            //' found a match?
            if (match.Success)
            {
                formMain.MoveToNextMatch(Variables._TextBox, true, Convert.ToBoolean(chkbx_matchCaseRep.Checked.ToString()), _ReplaceSearchHistoryBox.Text);
                isSuccess = true;

                if (!_ReplaceWithBox.Items.Contains(_ReplaceWithBox.Text))
                {
                    _ReplaceWithBox.Items.Insert(0, _ReplaceWithBox.Text);
                    Variables.List_ReplaceHistory.Insert(0, _ReplaceWithBox.Text);

                    File.WriteAllText(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_ReplaceHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                else if (!_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | !_ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
                {
                    Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                    _ReplaceSearchHistoryBox.Items.Insert(0, _ReplaceSearchHistoryBox.Text);
                    _SearchHistoryBox.Items.Insert(0, _SearchHistoryBox.Text);

                    File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_SearchHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                else if (_ReplaceWithBox.Items.Contains(_ReplaceWithBox.Text))
                {
                    string strToFind = _ReplaceWithBox.Text;

                    Variables.List_ReplaceHistory.Remove(_ReplaceWithBox.Text);
                    Variables.List_ReplaceHistory.Insert(0, _ReplaceWithBox.Text);

                    _ReplaceWithBox.Items.Clear();

                    foreach (var item in Variables.List_ReplaceHistory)
                    {
                        _ReplaceWithBox.Items.Add(item);
                    }

                    _ReplaceWithBox.Text = strToFind;

                    File.WriteAllText(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_ReplaceHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }

                else if (_SearchHistoryBox.Items.Contains(_SearchHistoryBox.Text) | _ReplaceSearchHistoryBox.Items.Contains(_ReplaceSearchHistoryBox.Text))
                {
                    string strToFind = _SearchHistoryBox.Text;

                    Variables.List_SearchHistory.Remove(_SearchHistoryBox.Text);
                    Variables.List_SearchHistory.Insert(0, _SearchHistoryBox.Text);

                    _ReplaceSearchHistoryBox.Items.Clear();
                    _SearchHistoryBox.Items.Clear();

                    foreach (var item in Variables.List_SearchHistory)
                    {
                        _SearchHistoryBox.Items.Add(item);
                        _ReplaceSearchHistoryBox.Items.Add(item);
                    }

                    _SearchHistoryBox.Text = strToFind;
                    _ReplaceSearchHistoryBox.Text = strToFind;

                    File.WriteAllText(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), string.Empty);
                    using (FileStream fs = new FileStream(string.Format(@"{0}\SearchHistory.txt", SettingsFolder), FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in Variables.List_SearchHistory)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }

            else if (match.Success == false)
            {
                if (isSuccess == false)
                {
                    lbl_searchStatus.Text = string.Format("Couldn't find '{0}' in the document to replace with '{1}'.", _ReplaceSearchHistoryBox.Text, _ReplaceWithBox.Text);
                    lbl_searchStatus.ForeColor = Color.Red;
                    tmr_RefreshStatus.Stop();
                    tmr_RefreshStatus.Start();
                }
                else
                {
                    lbl_searchStatus.Text = string.Format("Successfully replaced  all '{0}' occurrences with '{1}'.", _ReplaceSearchHistoryBox.Text, _ReplaceWithBox.Text);
                    lbl_searchStatus.ForeColor = Color.DarkGreen;
                    tmr_RefreshStatus.Stop();
                    tmr_RefreshStatus.Start();
                    isSuccess = false;
                }
            }
        }

        private void frm_FindReplace_Activated(object sender, EventArgs e)
        {
            formMain.findOpen = true;
        }

        private void frm_FindReplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            formMain.findOpen = false;
            Variables._TextBox.IsReadOnlyCaretVisible = false;
            Variables._TextBox.IsReadOnly = false;
        }


        private void frm_FindReplace_FormClosed(object sender, FormClosedEventArgs e)
        {
            Variables.alreadyOpenedFind = false;
        }

        private void tmr_CheckFocus_Tick(object sender, EventArgs e)
        {
            setFocusSearch();
        }
    }
}
