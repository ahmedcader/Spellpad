using Spellpad.Classes;
using Spellpad.Classes.Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using System.Threading;
using System.Net;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Timers;
using System.Runtime.InteropServices;

namespace Spellpad.Forms.Spellpad_Forms
{


    public partial class frm_Main : Form
    {
        bool windowInitialized;
        Rectangle rectangle;

        IniFile ini_GlobalSettings;
        MruMenu mru;

        #region Public Properties

        public void SpellCheckOnOff(bool _bool)
        {
            Variables._TextBox.SpellCheck.IsEnabled = _bool;
        }

        public void StatusBarOnOff(bool _bool)
        {
            _StatusBar.Visible = _bool;
            if (_bool)
                m_StatusBar.Checked = true;
            else
                m_StatusBar.Checked = false;
        }

        public void WordWrapOnOff(bool _bool)
        {
            if (_bool)
            {
                Variables._TextBox.TextWrapping = TextWrapping.Wrap;
                m_WordWrap.Checked = true;
            }
            else
            {
                Variables._TextBox.TextWrapping = TextWrapping.NoWrap;
                m_WordWrap.Checked = false;
            }
        }

        public void QuickbarVisible(bool _bool)
        {
            mainToolbar.Visible = _bool;
            if (_bool)
                m_QuickBar.Checked = true;
            else
                m_QuickBar.Checked = false;
        }

        public void LargeToolbar(bool _bool)
        {
            ChangeToolStrip(_bool);
        }
        public void ChangeFontName(System.Windows.Media.FontFamily fm)
        {
            Variables._TextBox.FontFamily = fm;
        }

        public void ChangeFontSize(double size)
        {
            Variables._TextBox.FontSize = size;
        }

        public void ChangeForeColor(System.Windows.Media.Brush brushColor)
        {
            Variables._TextBox.Foreground = brushColor;
        }

        public void ChangeSelectionColor(System.Windows.Media.Brush brushColor)
        {
            Variables._TextBox.SelectionBrush = brushColor;
        }

        public void ChangeBackColor(System.Windows.Media.Brush brushColor)
        {
            Variables._TextBox.Background = brushColor;
        }

        #endregion

        #region Change ToolStrip
        private void ChangeToolStrip(bool isLarge)
        {
            System.Drawing.Size button_SmallSize = new System.Drawing.Size(20, 20);
            System.Drawing.Size seperator_SmallSize = new System.Drawing.Size(6, 20);

            System.Drawing.Size button_BigSize = new System.Drawing.Size(36, 36);
            System.Drawing.Size seperator_BigSize = new System.Drawing.Size(6, 39);

            if (!isLarge)
            {
                mainToolbar.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
                ts_New.Image = Spellpad.Properties.Resources.page_add_s;
                ts_New.Size = button_SmallSize;

                ts_Open.Image = Spellpad.Properties.Resources.folder_page_s;
                ts_Open.Size = button_SmallSize;

                ts_s1.Size = seperator_SmallSize;

                ts_Save.Image = Spellpad.Properties.Resources.page_save_s;
                ts_Save.Size = button_SmallSize;

                ts_SaveAs.Image = Spellpad.Properties.Resources.page_saveas_s;
                ts_SaveAs.Size = button_SmallSize;

                ts_s2.Size = seperator_SmallSize;

                ts_Cut.Image = Spellpad.Properties.Resources.cut_s;
                ts_Cut.Size = button_SmallSize;

                ts_Copy.Image = Spellpad.Properties.Resources.page_copy_s;
                ts_Copy.Size = button_SmallSize;

                ts_Paste.Image = Spellpad.Properties.Resources.page_paste_s;
                ts_Paste.Size = button_SmallSize;

                ts_s3.Size = seperator_SmallSize;

                ts_Undo.Image = Spellpad.Properties.Resources.arrow_undo_s;
                ts_Undo.Size = button_SmallSize;

                ts_Redo.Image = Spellpad.Properties.Resources.arrow_redo_s;
                ts_Redo.Size = button_SmallSize;

                ts_s4.Size = seperator_SmallSize;

                ts_Find.Image = Spellpad.Properties.Resources.find_s;
                ts_Find.Size = button_SmallSize;

                ts_Replace.Image = Spellpad.Properties.Resources.replace_s;
                ts_Replace.Size = button_SmallSize;
            }
            else
            {
                mainToolbar.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
                ts_New.Image = Spellpad.Properties.Resources.page_add;
                ts_New.Size = button_BigSize;

                ts_Open.Image = Spellpad.Properties.Resources.folder_page;
                ts_Open.Size = button_BigSize;

                ts_s1.Size = seperator_BigSize;

                ts_Save.Image = Spellpad.Properties.Resources.page_save;
                ts_Save.Size = button_BigSize;

                ts_SaveAs.Image = Spellpad.Properties.Resources.page_saveas;
                ts_SaveAs.Size = button_BigSize;

                ts_s2.Size = seperator_BigSize;

                ts_Cut.Image = Spellpad.Properties.Resources.cut;
                ts_Cut.Size = button_BigSize;

                ts_Copy.Image = Spellpad.Properties.Resources.page_copy;
                ts_Copy.Size = button_BigSize;

                ts_Paste.Image = Spellpad.Properties.Resources.page_paste;
                ts_Paste.Size = button_BigSize;

                ts_s3.Size = seperator_BigSize;

                ts_Undo.Image = Spellpad.Properties.Resources.arrow_undo;
                ts_Undo.Size = button_BigSize;

                ts_Redo.Image = Spellpad.Properties.Resources.arrow_redo;
                ts_Redo.Size = button_BigSize;

                ts_s4.Size = seperator_BigSize;

                ts_Find.Image = Spellpad.Properties.Resources.find;
                ts_Find.Size = button_BigSize;

                ts_Replace.Image = Spellpad.Properties.Resources.replace;
                ts_Replace.Size = button_BigSize;
            }

        }

        #endregion

        #region Track Window Functions
        private bool IsVisibleOnAnyScreen(Rectangle rect)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.IntersectsWith(rect))
                {
                    return true;
                }
            }

            return false;
        }

        private void TrackWindowState()
        {
            if (!windowInitialized) { return; }

            if (WindowState == FormWindowState.Normal)
            {
                ini_GlobalSettings.Write("Program Window", "Window_Location", string.Format("{0}, {1}, {2}, {3}", this.DesktopBounds.X, this.DesktopBounds.Y, this.DesktopBounds.Width, this.DesktopBounds.Height));
            }
        }
        #endregion

        UpdateInformation updateInfo;

        public UpdateInformation getUpdateInformation()
        {
            return updateInfo;
        }

        public frm_Main()
        {
            float dx, dy;

            Graphics g = this.CreateGraphics();
            try
            {
                dx = g.DpiX;
                dy = g.DpiY;

                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\Wow6432Node\\Spellpad");
                key.SetValue("ContextMenuIconSize", dx.ToString());
                key.Close();

            }
            finally
            {
                g.Dispose();
            }

            updateInfo = new UpdateInformation();
            string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");
            string DictionaryFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Dictionary");

            Variables.IniSettingsPath = Path.Combine(SettingsFolder, "Settings.ini");
            Variables.DictionaryPath = DictionaryFolder;

            #region Folder Creation
            Variables.CreateFolder(SettingsFolder);
            Variables.CreateFolder(DictionaryFolder);
            #endregion

            if (File.Exists(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
            {
                UpdateInformation updateInformation = JsonConvert.DeserializeObject<UpdateInformation>(File.ReadAllText(string.Format(@"{0}\Update Information.txt", SettingsFolder)));
                updateInfo = updateInformation;

                if (updateInfo.AutoUpdateChecked == null)
                    updateInfo.AutoUpdateChecked = "false";
                if (updateInfo.AutUpdateCheckInterval == null)
                    updateInfo.AutUpdateCheckInterval = "30 Seconds";
                if (updateInfo.LastCheckedUpdate == null)
                    updateInfo.LastCheckedUpdate = "Not yet checked for updates.";
                if (updateInfo.UpdateLocation == null)
                    updateInfo.UpdateLocation = null;

                string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                {
                    writer.Write(jsonOutput);
                }
            }
            else if (!File.Exists(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
            {
                updateInfo.AutoUpdateChecked = "false";
                updateInfo.AutUpdateCheckInterval = "30 Seconds";
                updateInfo.LastCheckedUpdate = "Not yet checked for updates.";
                updateInfo.UpdateLocation = null;
                string jsonOutput = JsonConvert.SerializeObject(getUpdateInformation(), Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                {
                    writer.Write(jsonOutput);
                }
            }

            ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
            mru = new MruMenu();


            #region List Assignment
            Variables.List_AddedDictionaries = new List<string>();
            Variables.List_WordsFromDictionaries = new List<string>();
            Variables.List_RemovingDictionaries = new List<string>();
            Variables.List_SearchHistory = new List<string>();
            Variables.List_ReplaceHistory = new List<string>();
            Variables.currentDict = new List<string>();
            #endregion

            #region File Checking
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary")))
            {
                if (File.Exists(ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary")))
                {
                    Variables.Global_CustomDictionary = ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary");
                }
                else
                {
                    ini_GlobalSettings.Write("Spellcheck", "Global_CustomDictionary", string.Format(@"{0}\Global Dictionary.lex", Variables.DictionaryPath));
                    Variables.Global_CustomDictionary = ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary");
                    var globalDictionaryFile = File.Create(Variables.Global_CustomDictionary);
                    globalDictionaryFile.Close();
                }
            }
            else
            {
                ini_GlobalSettings.Write("Spellcheck", "Global_CustomDictionary", string.Format(@"{0}\Global Dictionary.lex", Variables.DictionaryPath));
                Variables.Global_CustomDictionary = ini_GlobalSettings.Read("Spellcheck", "Global_CustomDictionary");
                var globalDictionaryFile = File.Create(Variables.Global_CustomDictionary);
                globalDictionaryFile.Close();
            }


            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary")))
            {
                if (File.Exists(ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary")))
                {
                    Variables.DefaultDictionary = ini_GlobalSettings.Read("Spellcheck", "Default_Dictionary");
                }
                else
                {
                    ini_GlobalSettings.DeleteKey("Spellcheck", "Default_Dictionary");
                }
            }

            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_RecentNumber")))
            {
                Variables.Editor_RecentNumber = ini_GlobalSettings.Read("Editor", "Editor_RecentNumber");
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_RecentNumber", "8");
                Variables.Editor_RecentNumber = ini_GlobalSettings.Read("Editor", "Editor_RecentNumber");
            }

            #endregion

            #region Loading Words To Dictionary
            foreach (var dictName in IniFile.GetKeys(Variables.IniSettingsPath, "Custom Dictionaries").ToList())
            {
                string properDictName = ini_GlobalSettings.Read("Custom Dictionaries", dictName);
                if (File.Exists(properDictName))
                    Variables.List_AddedDictionaries.Add(properDictName);
                else
                    Variables.List_RemovingDictionaries.Add(properDictName);
            }
            Variables.LoadWordsFromDictionaries();

            #endregion

            #region Initialize TextBox
            System.Windows.Controls.TextBox richTextBox = new System.Windows.Controls.TextBox();
            Variables._TextBox = richTextBox;
            Variables._TextBox.UseLayoutRounding = true;
            TextOptions.SetTextFormattingMode(Variables._TextBox, TextFormattingMode.Display);
            Variables._TextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            Variables._TextBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            Variables._TextBox.AcceptsReturn = true;
            Variables._TextBox.SpellCheck.IsEnabled = true;
            Variables.InitializeDictionary(Variables._TextBox, Variables.Global_CustomDictionary);
            Variables._TextBox.TextChanged += _TextBox_TextChanged;
            Variables._TextBox.PreviewKeyDown += _TextBox_PreviewKeyDown;
            Variables._TextBox.PreviewMouseDown += _TextBox_PreviewMouseDown;
            Variables._TextBox.SelectionChanged += _TextBox_SelectionChanged;
            System.Windows.Controls.ContextMenu cmt = new System.Windows.Controls.ContextMenu();
            richTextBox.ContextMenuOpening += richTextBox1_ContextMenuOpening;
            richTextBox.ContextMenu = cmt;
            #endregion

            #region Load Search History
            try
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                StreamReader file = new StreamReader(string.Format(@"{0}\SearchHistory.txt", SettingsFolder));
                while ((line = file.ReadLine()) != null)
                {
                    Variables.List_SearchHistory.Add(line);
                    counter++;
                }

                file.Close();

            }
            catch (Exception)
            {

            }
            #endregion

            #region Load Replace History
            try
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                StreamReader file = new StreamReader(string.Format(@"{0}\ReplaceHistory.txt", SettingsFolder));
                while ((line = file.ReadLine()) != null)
                {
                    Variables.List_ReplaceHistory.Add(line);
                    counter++;
                }

                file.Close();

            }
            catch (Exception)
            {


            }
            #endregion

            InitializeComponent();


            this.elementHost1.Child = Variables._TextBox;

            #region Load UpdateAvailableLocal
            if (!string.IsNullOrWhiteSpace(updateInfo.UpdateLocation))
            {
                if (File.Exists(updateInfo.UpdateLocation))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(updateInfo.UpdateLocation);
                    string Updateversion = versionInfo.ProductVersion;

                    var version1 = new Version(Updateversion);
                    var version2 = new Version(ProductVersion);

                    var result = version2.CompareTo(version1);
                    Debug.WriteLine(result);
                    if (result == 0)
                    {
                        Variables.updateHasDownloaded = false;
                        updateInfo.UpdateLocation = null;

                        string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                        using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                        {
                            writer.Write(jsonOutput);
                        }
                    }
                    else if (result == 1)
                    {
                        Variables.updateHasDownloaded = false;
                        updateInfo.UpdateLocation = null;

                        string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                        using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                        {
                            writer.Write(jsonOutput);
                        }
                    }
                    else if (result == -1)
                    {
                        Variables.updateHasDownloaded = true;
                        ts_UpdAvl.Visible = true;
                        ts_UpdAvl.Text = "Install Update";
                    }
                }
                else
                {
                    updateInfo.UpdateLocation = null;
                    string jsonOutput = JsonConvert.SerializeObject(getUpdateInformation(), Formatting.Indented);
                    using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                    {
                        writer.Write(jsonOutput);
                    }
                }
            }
            else
            {
                updateInfo.UpdateLocation = null;
                string jsonOutput = JsonConvert.SerializeObject(getUpdateInformation(), Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                {
                    writer.Write(jsonOutput);
                }
            }
            #endregion

            #region Curly Quotes
            try
            {
                string curlyValue = Registry.GetValue(string.Format("HKEY_LOCAL_MACHINE\\Software\\WOW6432Node\\{0}", ProductName), "CurlyQuotes", null).ToString();
                if (curlyValue == "0")
                {
                    btn_SpecialReplace.Visible = false;
                }
                else if (curlyValue == "1")
                {
                    btn_SpecialReplace.Visible = true;
                }
            }
            catch (Exception)
            {

            }

            #endregion

            #region Load Window Position

            RectangleConverter r = new RectangleConverter();
            string rectangleAsString = r.ConvertToString(ini_GlobalSettings.Read("Program Window", "Window_Location"));
            if (string.IsNullOrWhiteSpace(rectangleAsString))
            {
                string x = string.Format("{0}, {1}, 650, 600", (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
                ini_GlobalSettings.Write("Program Window", "Window_Location", x);
            }
            else
            {
                string[] xyz = rectangleAsString.Split(',');
                rectangle = new Rectangle(Convert.ToInt32(xyz[0]), Convert.ToInt32(xyz[1]), Convert.ToInt32(xyz[2]), Convert.ToInt32(xyz[3]));
            }


            // this is the default
            this.WindowState = FormWindowState.Normal;
            this.StartPosition = FormStartPosition.CenterScreen;

            // check if the saved bounds are nonzero and visible on any screen
            if (rectangle != Rectangle.Empty &&
                IsVisibleOnAnyScreen(rectangle))
            {
                // first set the bounds
                this.StartPosition = FormStartPosition.Manual;
                this.DesktopBounds = rectangle;

                if (string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Program Window", "Window_State")))
                    this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), "Normal");
                else
                    this.WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState), ini_GlobalSettings.Read("Program Window", "Window_State"));
            }
            else
            {
                // this resets the upper left corner of the window to windows standards
                this.StartPosition = FormStartPosition.CenterScreen;

                // we can still apply the saved size
                // msorens: added gatekeeper, otherwise first time appears as just a title bar!
                if (rectangle != Rectangle.Empty)
                {
                    this.Size = rectangle.Size;
                }
            }
            windowInitialized = true;
            #endregion

            LoadRecentList();
            CheckEdits();

            #region Setting Initializations

            #region WarnClearRecents Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_WarnClearRecents")))
            {
                Variables.Editor_WarnBeforeClear = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_WarnClearRecents"));
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_WarnClearRecents", "True");
                Variables.Editor_WarnBeforeClear = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_WarnClearRecents"));
            }
            #endregion

            #region Load FeedbackID
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Program", "FeedbackID")))
            {

                Variables.Program_FeedbackID = ini_GlobalSettings.Read("Program", "FeedbackID");
            }
            else
            {
                ini_GlobalSettings.Write("Program", "FeedbackID", Variables.GetID(8));
                Variables.Program_FeedbackID = ini_GlobalSettings.Read("Program", "FeedbackID");
            }
            #endregion

            #region Editor Backcolor Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_BackColor")))
            {
                Variables.Editor_BackColor = ini_GlobalSettings.Read("Editor", "Editor_BackColor");
                ChangeBackColor((SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_BackColor)));
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_BackColor", "#FFF3D7");
                Variables.Editor_BackColor = ini_GlobalSettings.Read("Editor", "Editor_BackColor");
                ChangeBackColor((SolidColorBrush)(new System.Windows.Media.BrushConverter().ConvertFrom(Variables.Editor_BackColor)));
            }
            #endregion

            #region Editor Forecolor Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_ForeColor")))
            {
                Variables.Editor_ForeColor = ini_GlobalSettings.Read("Editor", "Editor_ForeColor");
                ChangeForeColor((SolidColorBrush)(new BrushConverter().ConvertFrom(Variables.Editor_ForeColor)));
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_ForeColor", ((SolidColorBrush)richTextBox.Foreground).Color.ToString());
                Variables.Editor_ForeColor = ini_GlobalSettings.Read("Editor", "Editor_ForeColor");
            }
            #endregion

            #region Editor Selectioncolor Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_SelectionColor")))
            {
                Variables.Editor_SelectionColor = ini_GlobalSettings.Read("Editor", "Editor_SelectionColor");
                ChangeSelectionColor((SolidColorBrush)(new BrushConverter().ConvertFrom(Variables.Editor_SelectionColor)));
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_SelectionColor", ((SolidColorBrush)richTextBox.SelectionBrush).Color.ToString());
                Variables.Editor_SelectionColor = ini_GlobalSettings.Read("Editor", "Editor_SelectionColor");
            }
            #endregion

            #region Editor Search Fnding Match
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_MatchCase")))
            {
                Variables.Editor_MatchCaseFindings = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_MatchCase"));
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_MatchCase", "False");
                Variables.Editor_MatchCaseFindings = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_MatchCase"));
            }
            #endregion

            #region Editor Spellcheck Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_Spellcheck")))
            {
                Variables.Editor_SpellEnable = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Spellcheck"));
                richTextBox.SpellCheck.IsEnabled = Convert.ToBoolean(Variables.Editor_SpellEnable);
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_Spellcheck", "True");
                Variables.Editor_SpellEnable = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Spellcheck"));
                richTextBox.SpellCheck.IsEnabled = Convert.ToBoolean(Variables.Editor_SpellEnable);
            }
            #endregion

            #region Editor Font and Size Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_Font")))
            {
                Variables.Editor_Font = ini_GlobalSettings.Read("Editor", "Editor_Font");
                richTextBox.FontFamily = new System.Windows.Media.FontFamily(Variables.Editor_Font);
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_Font", richTextBox.FontFamily.ToString());
                Variables.Editor_Font = ini_GlobalSettings.Read("Editor", "Editor_Font");
                richTextBox.FontFamily = new System.Windows.Media.FontFamily(Variables.Editor_Font);
            }

            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_FontSize")))
            {
                Variables.Editor_FontSize = int.Parse(ini_GlobalSettings.Read("Editor", "Editor_FontSize"));
                richTextBox.FontSize = Variables.PointsToPixels(Variables.Editor_FontSize);
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_FontSize", Convert.ToInt32(richTextBox.FontSize).ToString());
                Variables.Editor_FontSize = int.Parse(ini_GlobalSettings.Read("Editor", "Editor_FontSize"));
                richTextBox.FontSize = Variables.PointsToPixels(Variables.Editor_FontSize);
            }
            #endregion

            #region Editor Statusbar Visibility Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_Statusbar")))
            {
                Variables.Editor_Statusbar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Statusbar"));
                m_StatusBar.Checked = Variables.Editor_Statusbar;
                _StatusBar.Visible = Variables.Editor_Statusbar;
            }
            else
            {
                m_StatusBar.Checked = true;
                ini_GlobalSettings.Write("Editor", "Editor_Statusbar", m_StatusBar.Checked.ToString());
                Variables.Editor_Statusbar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Statusbar"));
                _StatusBar.Visible = Variables.Editor_Statusbar;
            }
            #endregion

            #region Editor Quickbar Visibility Setting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_Quickbar")))
            {
                Variables.Editor_QuickBar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Quickbar"));
                m_QuickBar.Checked = Variables.Editor_QuickBar;
                mainToolbar.Visible = Variables.Editor_QuickBar;
            }
            else
            {
                m_QuickBar.Checked = true;
                ini_GlobalSettings.Write("Editor", "Editor_Quickbar", m_QuickBar.Checked.ToString());
                Variables.Editor_QuickBar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_Quickbar"));
                mainToolbar.Visible = Variables.Editor_QuickBar;
            }
            #endregion

            #region Editor WordWrapSetting
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_WordWrap")))
            {
                Variables.Editor_WordWrap = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_WordWrap"));

                if (Variables.Editor_WordWrap)
                {
                    m_WordWrap.Checked = Variables.Editor_WordWrap;
                    Variables._TextBox.TextWrapping = TextWrapping.Wrap;
                }
                else
                {
                    m_WordWrap.Checked = Variables.Editor_WordWrap;
                    Variables._TextBox.TextWrapping = TextWrapping.NoWrap;
                }
            }
            else
            {
                m_WordWrap.Checked = true;
                ini_GlobalSettings.Write("Editor", "Editor_WordWrap", m_WordWrap.Checked.ToString());
                Variables.Editor_WordWrap = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_WordWrap"));
                Variables._TextBox.TextWrapping = TextWrapping.Wrap;
            }
            #endregion

            #region Editor LargeToolbar
            if (!string.IsNullOrWhiteSpace(ini_GlobalSettings.Read("Editor", "Editor_LargeToolbar")))
            {
                Variables.Editor_LargeToolbar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_LargeToolbar"));
                ChangeToolStrip(Variables.Editor_LargeToolbar);
            }
            else
            {
                ini_GlobalSettings.Write("Editor", "Editor_LargeToolbar", "True");
                Variables.Editor_LargeToolbar = Convert.ToBoolean(ini_GlobalSettings.Read("Editor", "Editor_LargeToolbar"));
                ChangeToolStrip(Variables.Editor_LargeToolbar);

            }
            #endregion

            #endregion

            if (!Variables.List_AddedDictionaries.Contains(Variables.DefaultDictionary))
            {
                foreach (var item in Variables.List_RemovingDictionaries)
                    ini_GlobalSettings.DeleteKey("Custom Dictionaries", Path.GetFileNameWithoutExtension(item));
            }

            Variables.PutWordsInList();

            createUpdateTimer();

            if (updateInfo.AutoUpdateChecked == "True")
            {
                getSystemUpdateTimer().Enabled = true;
            }
            else
            {
                getSystemUpdateTimer().Enabled = false;
            }

            #region Load File using Open
            if (Variables.openThroughCommandLine)
                OpenCommandLineDocument();
            else
                NewDocument();
            #endregion


        }

        private void _TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (findOpen)
            {
                Variables._TextBox.IsReadOnlyCaretVisible = false;
                Variables._TextBox.IsReadOnly = false;
                findOpen = false;
            }
        }

        private void _TextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

            CheckEdits();
            if (findOpen)
            {
                if (e.Key == Key.Enter)
                {
                    Variables._TextBox.IsReadOnlyCaretVisible = true;
                    Variables._TextBox.IsReadOnly = true;
                    _FindDialog.PerformNextClick();
                    e.Handled = true;
                }
            }
        }

        private void LoadTimes()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            var ci = new CultureInfo(currentCulture.ToString());
            m_TimeDate.DropDownItems.Clear();
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("MMMM dd, yyyy", ci), null, new EventHandler(timeDate_Click));
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("HHHH:mm", ci), null, new EventHandler(timeDate_Click));
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("h:mm tt", ci), null, new EventHandler(timeDate_Click));
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("dddd, MMMM dd, yyyy", ci), null, new EventHandler(timeDate_Click));
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("MMMM dd", ci), null, new EventHandler(timeDate_Click));
            m_TimeDate.DropDownItems.Add(DateTime.Now.ToString("dddd", ci), null, new EventHandler(timeDate_Click));
        }

        private void timeDate_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Text = Variables._TextBox.Text.Insert(Variables._TextBox.SelectionStart, (sender as ToolStripMenuItem).Text.ToString() + " ");
            Variables._TextBox.CaretIndex = Variables._TextBox.Text.LastIndexOf((sender as ToolStripMenuItem).Text.ToString() + " ");
            Variables._TextBox.CaretIndex = Variables._TextBox.Text.LastIndexOf((sender as ToolStripMenuItem).Text.ToString() + " ") + (sender as ToolStripMenuItem).Text.Length + " ".Length;
        }

        public static List<string> listWithRecents = new List<string>();
        private void clearRecent_Click(object sender, EventArgs e)
        {
            if (Variables.Editor_WarnBeforeClear)
            {
                DialogResult clearConfirmRecents = System.Windows.Forms.MessageBox.Show("You're about to clear the recents file list. Continue?", "Clear Recents List", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (clearConfirmRecents == DialogResult.Yes)
                {
                    mru.ClearRecents(listWithRecents);
                }
                else if (clearConfirmRecents == DialogResult.No)
                { }
            }
            else
            {
                mru.ClearRecents(listWithRecents);
            }
        }

        private void openRecent(string fullPath)
        {
            mru.PlaceOnTop(listWithRecents, fullPath);
            Variables.FilePath = fullPath;

            using (StreamReader sr = new StreamReader(Variables.FilePath, Encoding.Default, true))
            {
                Variables._TextBox.Text = sr.ReadToEnd();
            }

            this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
            Variables.hasMadeChanges = false;
            lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
            lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
            UpdateCharacters();

            m_Save.Enabled = false;
            ts_Save.Enabled = false;

            m_CloseDocument.Enabled = true;
            Variables.ClearUndo();
        }

        private void recentListItem_Click(object sender, EventArgs e)
        {
            string fullPath = (sender as ToolStripMenuItem).Tag.ToString();
            if (File.Exists(fullPath))
            {
                if (Variables.hasMadeChanges)
                {
                    DialogResult saveChangesDialog = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (saveChangesDialog == DialogResult.Yes)
                    {
                        SaveDocument();

                    }
                    else if (saveChangesDialog == DialogResult.No)
                    {
                        openRecent(fullPath);
                    }
                    else { }
                }
                else
                {
                    openRecent(fullPath);
                }
            }
            else
            {
                DialogResult removeRecent = System.Windows.Forms.MessageBox.Show(string.Format("The file '{0}' in '{1}' doesn't exist. Do you want to remove it from the recents list?", Path.GetFileName(fullPath), Path.GetDirectoryName(fullPath)), "Remove from Recents", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (removeRecent == DialogResult.Yes)
                {
                    ini_GlobalSettings.DeleteKey("Recent List", fullPath);
                    OpenToolStripMenuItem.Owner.Hide();
                    listWithRecents.Clear();
                    LoadRecentList();
                }
                else if (removeRecent == DialogResult.No)
                {

                }
            }
        }

        private void LoadRecentList()
        {
            OpenToolStripMenuItem.DropDownItems.Clear();
            listWithRecents = mru.getRecentItems(IniFile.GetKeys(Variables.IniSettingsPath, "Recent List").ToList());

            ToolStripMenuItem openToolstripItem = new ToolStripMenuItem("Open...", new Bitmap(Spellpad.Properties.Resources.ToolStripOpen), new EventHandler(m_Open_Click));
            openToolstripItem.ShortcutKeyDisplayString = "Ctrl+O";
            OpenToolStripMenuItem.DropDownItems.Add(openToolstripItem);

            ToolStripSeparator seperatorItem1 = new ToolStripSeparator();
            OpenToolStripMenuItem.DropDownItems.Add(seperatorItem1);

            int MaxNumber = Convert.ToInt32(Variables.Editor_RecentNumber);
            if (MaxNumber > Convert.ToInt32(Variables.MaxRecents))
            {
                MaxNumber = 20;
                Variables.Editor_RecentNumber = "20";
            }
            if (listWithRecents.Any())
            {
                foreach (var recentItem in listWithRecents.Take(MaxNumber))
                {
                    ToolStripMenuItem recentToolstripItem = new ToolStripMenuItem(recentItem, null, new EventHandler(recentListItem_Click));
                    recentToolstripItem.Tag = recentItem;
                    recentToolstripItem.ToolTipText = recentToolstripItem.Tag.ToString();
                    OpenToolStripMenuItem.DropDownItems.Add(recentToolstripItem);

                }

                ToolStripSeparator seperatorItem2 = new ToolStripSeparator();
                OpenToolStripMenuItem.DropDownItems.Add(seperatorItem2);

                ToolStripMenuItem clearRecentToolstripItem = new ToolStripMenuItem("Clear All Recents", new Bitmap(Spellpad.Properties.Resources.ClearIcon), new EventHandler(clearRecent_Click));
                OpenToolStripMenuItem.DropDownItems.Add(clearRecentToolstripItem);
            }
            else
            {
                OpenToolStripMenuItem.DropDownItems.Add(noRecentsToolStripMenuItem);
            }
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRecentList();
        }

        private void richTextBox1_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            int index = 0;
            Variables._TextBox.ContextMenu.Items.Clear();

            #region If Spelling Error Show Suggestions or No Suggestions
            SpellingError spellingError = Variables._TextBox.GetSpellingError(Variables._TextBox.CaretIndex);
            if (spellingError != null && spellingError.Suggestions.Count() >= 1)
            {
                foreach (string suggestion in spellingError.Suggestions)
                {
                    System.Windows.Controls.MenuItem menuItem = new System.Windows.Controls.MenuItem();
                    menuItem.Header = suggestion;
                    menuItem.FontWeight = FontWeights.Bold;
                    menuItem.Command = EditingCommands.CorrectSpellingError;
                    menuItem.CommandParameter = suggestion;
                    menuItem.CommandTarget = Variables._TextBox;
                    Variables._TextBox.ContextMenu.Items.Insert(index, menuItem);
                    index += 1;
                }
                Separator seperator = new Separator();
                Variables._TextBox.ContextMenu.Items.Insert(index, seperator);
                index += 1;
                //Adding the IgnoreAll menu item
                System.Windows.Controls.MenuItem IgnoreAllMenuItem = new System.Windows.Controls.MenuItem();
                IgnoreAllMenuItem.Header = "Ignore All";
                IgnoreAllMenuItem.Command = EditingCommands.IgnoreSpellingError;
                IgnoreAllMenuItem.CommandTarget = Variables._TextBox;
                Variables._TextBox.ContextMenu.Items.Insert(index, IgnoreAllMenuItem);
                index += 1;
            }
            else
            {
                //No Suggestions found, add a disabled NoSuggestions menuitem.
                System.Windows.Controls.MenuItem menuItem = new System.Windows.Controls.MenuItem();
                menuItem.Header = "No Suggestions";
                menuItem.IsEnabled = false;
                Variables._TextBox.ContextMenu.Items.Insert(index, menuItem);
                index += 1;
            }
            #endregion

            int selectionStart = Variables._TextBox.GetSpellingErrorStart(Variables._TextBox.CaretIndex);
            if (selectionStart >= 0)
            {
                Separator seperator1 = new Separator();
                Variables._TextBox.ContextMenu.Items.Insert(index, seperator1);
                index += 1;
                System.Windows.Controls.MenuItem AddToDictionary = new System.Windows.Controls.MenuItem();

                if (Variables._TextBox.SelectedText == string.Empty)
                {

                    string EllipsisGetString = Variables._TextBox.Text.Substring(selectionStart, Variables._TextBox.GetSpellingErrorLength(Variables._TextBox.CaretIndex));
                    if (EllipsisGetString.Length > 16)
                    {
                        EllipsisGetString = Variables.Truncate(Variables._TextBox.Text.Substring(selectionStart, Variables._TextBox.GetSpellingErrorLength(Variables._TextBox.CaretIndex)), 16) + "...";
                    }
                    else
                    {
                        EllipsisGetString = Variables.Truncate(Variables._TextBox.Text.Substring(selectionStart, Variables._TextBox.GetSpellingErrorLength(Variables._TextBox.CaretIndex)), 16).ToString();
                    }
                    AddToDictionary.Header = string.Format("Add '{0}' to Dictionary", EllipsisGetString);
                }
                else
                {
                    string EllipsisSelectedString = Variables._TextBox.SelectedText;
                    if (EllipsisSelectedString.Length > 16)
                    {
                        EllipsisSelectedString = Variables.Truncate(Variables._TextBox.SelectedText, 16) + "...";
                    }
                    else
                    {
                        EllipsisSelectedString = Variables.Truncate(Variables._TextBox.SelectedText, 16).ToString();
                    }
                    AddToDictionary.Header = string.Format("Add '{0}' to Dictionary", EllipsisSelectedString);
                }

                AddToDictionary.Command = EditingCommands.IgnoreSpellingError;
                AddToDictionary.CommandTarget = Variables._TextBox;
                AddToDictionary.Click += AddToDictionary_Click;
                Variables._TextBox.ContextMenu.Items.Insert(index, AddToDictionary);
                index += 1;
            }

            //Common Edit MenuItems.
            Separator seperator2 = new Separator();
            Variables._TextBox.ContextMenu.Items.Insert(index, seperator2);
            index += 1;

            if (Variables._TextBox.SelectionLength > 0)
            {

                System.Windows.Controls.MenuItem searchMenuItem = new System.Windows.Controls.MenuItem();

                string EllipsisSearchString = Variables._TextBox.SelectedText;
                if (EllipsisSearchString.Length > 16)
                {
                    EllipsisSearchString = Variables.Truncate(Variables._TextBox.SelectedText, 16) + "...";
                }
                else
                {
                    EllipsisSearchString = Variables.Truncate(Variables._TextBox.SelectedText, 16).ToString();
                }

                searchMenuItem.Header = "Search Google for " + "'" + EllipsisSearchString + "'";
                searchMenuItem.Click += searchMenuItem_Click;
                Variables._TextBox.ContextMenu.Items.Insert(index, searchMenuItem);
                index += 1;

                string EllipsisDefineString = Variables._TextBox.SelectedText;
                if (EllipsisDefineString.Length > 16)
                {
                    EllipsisDefineString = Variables.Truncate(Variables._TextBox.SelectedText, 16) + "...";
                }
                else
                {
                    EllipsisDefineString = Variables.Truncate(Variables._TextBox.SelectedText, 16).ToString();
                }

                System.Windows.Controls.MenuItem defineMenuItem = new System.Windows.Controls.MenuItem();
                defineMenuItem.Header = "Define " + "'" + EllipsisDefineString + "'";
                defineMenuItem.Click += defineMenuItem_Click;
                Variables._TextBox.ContextMenu.Items.Insert(index, defineMenuItem);
                index += 1;

                Separator seperator22 = new Separator();
                Variables._TextBox.ContextMenu.Items.Insert(index, seperator22);
                index += 1;
            }

            #region Cut, Copy, Paste MenuItems
            //Cut
            System.Windows.Controls.MenuItem cutMenuItem = new System.Windows.Controls.MenuItem();
            cutMenuItem.Command = ApplicationCommands.Cut;
            Variables._TextBox.ContextMenu.Items.Insert(index, cutMenuItem);
            index += 1;
            //Copy
            System.Windows.Controls.MenuItem copyMenuItem = new System.Windows.Controls.MenuItem();
            copyMenuItem.Command = ApplicationCommands.Copy;
            Variables._TextBox.ContextMenu.Items.Insert(index, copyMenuItem);
            index += 1;
            //Paste
            System.Windows.Controls.MenuItem pasteMenuItem = new System.Windows.Controls.MenuItem();
            pasteMenuItem.Command = ApplicationCommands.Paste;
            Variables._TextBox.ContextMenu.Items.Insert(index, pasteMenuItem);
            index += 1;
            Separator seperator3 = new Separator();
            Variables._TextBox.ContextMenu.Items.Insert(index, seperator3);
            index += 1;
            //Delete
            System.Windows.Controls.MenuItem deleteMenuItem = new System.Windows.Controls.MenuItem();
            deleteMenuItem.Command = ApplicationCommands.Delete;
            Variables._TextBox.ContextMenu.Items.Insert(index, deleteMenuItem);
            index += 1;
            
            Separator seperator4 = new Separator();
            Variables._TextBox.ContextMenu.Items.Insert(index, seperator4);
            index += 1;
            System.Windows.Controls.MenuItem insertBullet = new System.Windows.Controls.MenuItem();
            insertBullet.Header = "Insert • Bullet Point";
            insertBullet.Click += insertBullet_Click;
            Variables._TextBox.ContextMenu.Items.Insert(index, insertBullet);
            index += 1;
            System.Windows.Controls.MenuItem insertSymbolMenuItem = new System.Windows.Controls.MenuItem();
            insertSymbolMenuItem.Header = "Insert Symbol...";
            insertSymbolMenuItem.Click += insertSymbolMenuItem_Click;
            Variables._TextBox.ContextMenu.Items.Insert(index, insertSymbolMenuItem);
            index += 1;
            //Select All
            Separator seperator5 = new Separator();
            Variables._TextBox.ContextMenu.Items.Insert(index, seperator5);
            index += 1;
            System.Windows.Controls.MenuItem selectAllMenuItem = new System.Windows.Controls.MenuItem();
            selectAllMenuItem.Command = ApplicationCommands.SelectAll;
            Variables._TextBox.ContextMenu.Items.Insert(index, selectAllMenuItem);
            index += 1;
            #endregion

        }

        private void insertBullet_Click(object sender, RoutedEventArgs e)
        {
            Variables._TextBox.SelectedText = "• ";
            Variables._TextBox.CaretIndex += Variables._TextBox.SelectedText.Length;
            Variables._TextBox.SelectionLength = 0;
        }

        private void insertSymbolMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!Variables.alreadyOpenedInsert)
            {
                _InsertSymbols = new frm_Insert(this);
                _InsertSymbols.StartPosition = FormStartPosition.Manual;
                _InsertSymbols.Location = new System.Drawing.Point(this.Location.X + (this.Width - _InsertSymbols.Width) / 2, this.Location.Y + (this.Height - _InsertSymbols.Height) / 2);
                _InsertSymbols.Show(this);
            }
        }
        private void defineMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + @"http://www.tfd.com/" + Variables._TextBox.SelectedText));
        }

        private void searchMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + @"http://www.google.com/search?q=" + Variables._TextBox.SelectedText));
        }

        private void AddToDictionary_Click(object sender, RoutedEventArgs e)
        {
            int selectionStart = Variables._TextBox.GetSpellingErrorStart(Variables._TextBox.CaretIndex);
            if (selectionStart >= 0)
            {
                Variables.currentDict.Add(Variables._TextBox.Text.Substring(selectionStart, Variables._TextBox.GetSpellingErrorLength(Variables._TextBox.CaretIndex)));
                Variables.AddToDictionary();
            }
        }

        void _TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Variables.hasMadeChanges = true;

            if (Variables.FilePath != null)
                this.Text = string.Format("*{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
            else
                this.Text = string.Format("*Untitled - {0}", ProductName);

            UpdateCharacters();
            m_Save.Enabled = true;
            ts_Save.Enabled = true;
        }

        void _TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (Variables._TextBox.SelectionLength > 0)
            {
                Variables.F3Text = Variables._TextBox.SelectedText;
                m_FindNext.Enabled = true;
                m_FindPrevious.Enabled = true;
            }

            UpdateCharacters();

            CheckEdits();

            #region Enable Casing Options
            if (Variables._TextBox.SelectionLength > 0)
                btn_TextCasing.Enabled = true;
            else
                btn_TextCasing.Enabled = false;
            #endregion

        }

        private void UpdateCharacters()
        {
            #region Update Words Count
            if (Variables.CountWords(Variables._TextBox.Text) == 1)
                lbl_Words.Text = Variables.CountWords(Variables._TextBox.Text).ToString("N0") + " Word";
            else if (Variables.CountWords(Variables._TextBox.Text) >= 2 || Variables.CountWords(Variables._TextBox.Text) == 0)
                lbl_Words.Text = Variables.CountWords(Variables._TextBox.Text).ToString("N0") + " Words";

            #endregion

            #region Update Characters Count
            if (Variables._TextBox.Text.Length == 1)
                lbl_Characters.Text = Variables._TextBox.Text.Length.ToString("N0") + " Character";
            else if (Variables._TextBox.Text.Length >= 2 || Variables._TextBox.Text.Length == 0)
                lbl_Characters.Text = Variables._TextBox.Text.Length.ToString("N0") + " Characters";
            #endregion

            #region Update Line and Character Position
            int row = Variables._TextBox.GetLineIndexFromCharacterIndex(Variables._TextBox.CaretIndex);
            int col = Variables._TextBox.CaretIndex - Variables._TextBox.GetCharacterIndexFromLineIndex(row);
            lbl_LineCol.Text = "Ln " + (row + 1).ToString("N0") + ", Ch " + (col + 1).ToString("N0");
            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            #region Keyboard Shortcuts
            if (keyData == (Keys.Enter))
            {
                if (findOpen)
                {
                    _FindDialog.PerformNextClick();
                    return true;
                }
            }
            #region Keyboard New Document Shortcut
            if (keyData == (Keys.Control | Keys.N))
            {
                m_New.PerformClick();
                return true;
            }
            #endregion

            #region Keyboard Find Next Shortcut
            if (keyData == (Keys.F3))
            {
                m_FindNext.PerformClick();
                return true;
            }
            #endregion

            #region Keyboard Find Previous Shortcut
            if (keyData == (Keys.Shift | Keys.F3))
            {
                m_FindPrevious.PerformClick();
                hasF3d = false;
                return true;
            }
            #endregion

            return base.ProcessCmdKey(ref msg, keyData);
            #endregion
        }

        public void CheckEdits()
        {
            if (Variables._TextBox.CanUndo)
            {
                m_Undo.Enabled = true;
                ts_Undo.Enabled = true;
            }
            else
            {
                m_Undo.Enabled = false;
                ts_Undo.Enabled = false;
            }

            if (Variables._TextBox.CanRedo)
            {
                m_Redo.Enabled = true;
                ts_Redo.Enabled = true;
            }
            else
            {
                m_Redo.Enabled = false;
                ts_Redo.Enabled = false;
            }

            if (Variables._TextBox.Text.Length > 0)
            {
                ts_Find.Enabled = true;
                ts_Replace.Enabled = true;
                m_Find.Enabled = true;
                m_GoTo.Enabled = true;
                m_Replace.Enabled = true;
            }
            else
            {
                ts_Find.Enabled = false;
                ts_Replace.Enabled = false;
                m_Find.Enabled = false;
                m_GoTo.Enabled = false;
                m_Replace.Enabled = false;
            }

            if (Variables._TextBox.SelectionLength > 0)
            {
                m_Cut.Enabled = true;
                m_Copy.Enabled = true;
                m_Delete.Enabled = true;
                m_SelectAll.Enabled = true;
                //m_FindNext.Enabled = true;
                //m_FindPrevious.Enabled = true;
                ts_Copy.Enabled = true;
                ts_Cut.Enabled = true;
            }
            else
            {
                m_Cut.Enabled = false;
                m_Copy.Enabled = false;
                m_Delete.Enabled = false;
                m_SelectAll.Enabled = false;
                //m_FindNext.Enabled = false;
                //m_FindPrevious.Enabled = false;
                ts_Copy.Enabled = false;
                ts_Cut.Enabled = false;
            }

            if (System.Windows.Clipboard.ContainsText(System.Windows.TextDataFormat.Text))
            {
                m_Paste.Enabled = true;
                ts_Paste.Enabled = true;
            }
            else
            {
                m_Paste.Enabled = false;
                ts_Paste.Enabled = false;
            }
        }

        private void NewDocument()
        {
            //m_CloseDocument.Enabled = false;
            Variables._TextBox.Clear();
            Variables.FilePath = null;
            this.Text = String.Format("Untitled - {0}", ProductName);
            lbl_LastSaved.Text = "Not Saved";
            lbl_LastSaved.ForeColor = System.Drawing.Color.Gray;
            UpdateCharacters();
            Variables.hasMadeChanges = false;
        }

        private void OpenCommandLineDocument()
        {
            using (StreamReader sr = new StreamReader(Variables.FilePath, Encoding.Default))
            {
                Variables._TextBox.Text = sr.ReadToEnd();
            }

            this.Text = string.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
            Variables.hasMadeChanges = false;
            lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
            lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
            UpdateCharacters();
            mru.SaveToList(Variables.FilePath);

            if (!listWithRecents.Contains(Variables.FilePath))
            {
                listWithRecents.Add(Variables.FilePath);
            }
            mru.PlaceOnTop(listWithRecents, Variables.FilePath);
            m_CloseDocument.Enabled = true;
            m_Save.Enabled = false;
            ts_Save.Enabled = false;
        }

        private void OpenDocument()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Open File";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Variables.FilePath = openFileDialog.FileName;

                using (StreamReader sr = new StreamReader(Variables.FilePath, Encoding.Default))
                {
                    Variables._TextBox.Text = sr.ReadToEnd();
                }

                this.Text = string.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                Variables.hasMadeChanges = false;
                lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
                lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
                UpdateCharacters();
                mru.SaveToList(Variables.FilePath);

                if (!listWithRecents.Contains(Variables.FilePath))
                {
                    listWithRecents.Add(Variables.FilePath);
                }
                mru.PlaceOnTop(listWithRecents, Variables.FilePath);

                m_Save.Enabled = false;
                ts_Save.Enabled = false;
                Variables.ClearUndo();
                m_CloseDocument.Enabled = true;
            }
        }

        private void SaveAsDocument()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.Title = "Save File As...";
            saveFileDialog.FileName = Path.GetFileName(Variables.FilePath);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Variables.FilePath = saveFileDialog.FileName;
                using (StreamWriter sw = new StreamWriter(Variables.FilePath, false, Encoding.Default))
                {
                    sw.Write(Variables._TextBox.Text);
                }

                this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                Variables.hasMadeChanges = false;
                lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");

                m_Save.Enabled = false;
                ts_Save.Enabled = false;

                mru.SaveToList(Variables.FilePath);

                if (!listWithRecents.Contains(Variables.FilePath))
                {
                    listWithRecents.Add(Variables.FilePath);
                }
                mru.PlaceOnTop(listWithRecents, Variables.FilePath);
                m_CloseDocument.Enabled = true;
            }
        }

        public void _TriggerSave()
        {
            SaveDocument();
        }

        public static bool IsFileReadOnly(string FileName)
        {
            FileInfo fInfo = new FileInfo(FileName);
            return fInfo.IsReadOnly;
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        public void SaveDocument()
        {
            if (File.Exists(Variables.FilePath))
            {
                if (IsFileReadOnly(Variables.FilePath))
                {
                    DialogResult saveAttributeDialog = System.Windows.Forms.MessageBox.Show(string.Format("{0} cannot be saved because it is marked as a Read-Only file. Do you want to disable the Read-Only attribute for this file and save?", Path.GetFileName(Variables.FilePath)), ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (saveAttributeDialog == DialogResult.Yes)
                    {
                        FileAttributes fileAttributes = File.GetAttributes(Variables.FilePath);
                        fileAttributes = RemoveAttribute(fileAttributes, FileAttributes.ReadOnly);
                        File.SetAttributes(Variables.FilePath, fileAttributes);

                        using (StreamWriter sw = new StreamWriter(Variables.FilePath, false, Encoding.Default))
                        {
                            sw.Write(Variables._TextBox.Text);
                        }

                        this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                        Variables.hasMadeChanges = false;
                        lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
                        lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
                        m_Save.Enabled = false;
                        ts_Save.Enabled = false;

                        mru.SaveToList(Variables.FilePath);

                        if (!listWithRecents.Contains(Variables.FilePath))
                        {
                            listWithRecents.Add(Variables.FilePath);
                        }
                        mru.PlaceOnTop(listWithRecents, Variables.FilePath);

                        if (Variables.saveAndQuit)
                        {
                            Process.Start(updateInfo.UpdateLocation);
                        }
                        m_CloseDocument.Enabled = true;

                    }
                    else if (saveAttributeDialog == DialogResult.No)
                    {

                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(Variables.FilePath, false, Encoding.Default))
                    {
                        sw.Write(Variables._TextBox.Text);
                    }

                    this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                    Variables.hasMadeChanges = false;
                    lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
                    lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
                    m_Save.Enabled = false;
                    ts_Save.Enabled = false;

                    mru.SaveToList(Variables.FilePath);

                    if (!listWithRecents.Contains(Variables.FilePath))
                    {
                        listWithRecents.Add(Variables.FilePath);
                    }
                    mru.PlaceOnTop(listWithRecents, Variables.FilePath);

                    if (Variables.saveAndQuit)
                    {
                        Process.Start(updateInfo.UpdateLocation);
                    }
                    m_CloseDocument.Enabled = true;
                }
            }
            else
            {
                if (Variables.saveAndQuit)
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.Title = "Save File";
                    System.Windows.Forms.DialogResult result = saveFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Variables.FilePath = saveFileDialog.FileName;
                        using (StreamWriter sw = new StreamWriter(Variables.FilePath, false, Encoding.Default))
                        {
                            sw.Write(Variables._TextBox.Text);
                        }

                        this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                        Variables.hasMadeChanges = false;
                        lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
                        lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
                        m_Save.Enabled = false;
                        ts_Save.Enabled = false;

                        mru.SaveToList(Variables.FilePath);

                        if (!listWithRecents.Contains(Variables.FilePath))
                        {
                            listWithRecents.Add(Variables.FilePath);
                        }

                        mru.PlaceOnTop(listWithRecents, Variables.FilePath);
                        Process.Start(updateInfo.UpdateLocation);
                        m_CloseDocument.Enabled = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        Process.Start(updateInfo.UpdateLocation);
                    }
                }
                else
                {
                    System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                    saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.Title = "Save File";

                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Variables.FilePath = saveFileDialog.FileName;
                        using (StreamWriter sw = new StreamWriter(Variables.FilePath, false, Encoding.Default))
                        {
                            sw.Write(Variables._TextBox.Text);
                        }

                        this.Text = String.Format("{1} - {0}", ProductName, Path.GetFileNameWithoutExtension(Variables.FilePath));
                        Variables.hasMadeChanges = false;
                        lbl_LastSaved.Text = File.GetLastWriteTime(Variables.FilePath).ToString("f");
                        lbl_LastSaved.ForeColor = System.Drawing.Color.DarkGreen;
                        m_Save.Enabled = false;
                        ts_Save.Enabled = false;

                        mru.SaveToList(Variables.FilePath);

                        if (!listWithRecents.Contains(Variables.FilePath))
                        {
                            listWithRecents.Add(Variables.FilePath);
                        }
                        mru.PlaceOnTop(listWithRecents, Variables.FilePath);
                        m_CloseDocument.Enabled = true;
                    }
                }
            }
        }

        private void m_New_Click(object sender, EventArgs e)
        {
            if (Variables.hasMadeChanges)
            {
                DialogResult saveChangesDialog = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (saveChangesDialog == DialogResult.Yes)
                {
                    SaveDocument();
                }
                else if (saveChangesDialog == DialogResult.No)
                {
                    NewDocument();
                }
            }
            else
            {
                NewDocument();
            }
        }

        private void m_Settings_Click(object sender, EventArgs e)
        {
            var settings = new frm_Settings(this);
            settings.ShowDialog();
        }

        private void m_QuickBar_Click(object sender, EventArgs e)
        {
            if (m_QuickBar.Checked)
            {
                m_QuickBar.Checked = false;
                Variables.Editor_QuickBar = Convert.ToBoolean(m_QuickBar.Checked.ToString());
                m_QuickBar.Checked = Variables.Editor_QuickBar;
                ini_GlobalSettings.Write("Editor", "Editor_Quickbar", Variables.Editor_QuickBar.ToString());
                mainToolbar.Visible = Variables.Editor_QuickBar;
            }
            else
            {
                m_QuickBar.Checked = true;
                Variables.Editor_QuickBar = Convert.ToBoolean(m_QuickBar.Checked.ToString());
                m_QuickBar.Checked = Variables.Editor_Statusbar;
                ini_GlobalSettings.Write("Editor", "Editor_Quickbar", Variables.Editor_QuickBar.ToString());
                mainToolbar.Visible = Variables.Editor_QuickBar;
            }
        }

        private void m_StatusBar_Click(object sender, EventArgs e)
        {
            #region Visible On/Off StatusBar
            if (m_StatusBar.Checked)
            {
                m_StatusBar.Checked = false;
                Variables.Editor_Statusbar = Convert.ToBoolean(m_StatusBar.Checked.ToString());
                m_StatusBar.Checked = Variables.Editor_Statusbar;
                ini_GlobalSettings.Write("Editor", "Editor_Statusbar", Variables.Editor_Statusbar.ToString());
                _StatusBar.Visible = Variables.Editor_Statusbar;
            }
            else
            {
                m_StatusBar.Checked = true;
                Variables.Editor_Statusbar = Convert.ToBoolean(m_StatusBar.Checked.ToString());
                m_StatusBar.Checked = Variables.Editor_Statusbar;
                ini_GlobalSettings.Write("Editor", "Editor_Statusbar", Variables.Editor_Statusbar.ToString());
                _StatusBar.Visible = Variables.Editor_Statusbar;
            }
            #endregion
        }

        private void m_WordWrap_Click(object sender, EventArgs e)
        {
            #region Wordwrapping On/Off
            if (m_WordWrap.Checked)
            {
                m_WordWrap.Checked = false;
                Variables.Editor_WordWrap = Convert.ToBoolean(m_WordWrap.Checked.ToString());
                m_WordWrap.Checked = Variables.Editor_WordWrap;
                ini_GlobalSettings.Write("Editor", "Editor_WordWrap", Variables.Editor_WordWrap.ToString());
                Variables._TextBox.TextWrapping = TextWrapping.NoWrap;
            }
            else
            {
                m_WordWrap.Checked = true;
                Variables.Editor_WordWrap = Convert.ToBoolean(m_WordWrap.Checked.ToString());
                m_WordWrap.Checked = Variables.Editor_WordWrap;
                ini_GlobalSettings.Write("Editor", "Editor_WordWrap", Variables.Editor_WordWrap.ToString());
                Variables._TextBox.TextWrapping = TextWrapping.Wrap;
            }
            #endregion
        }

        private void m_Open_Click(object sender, EventArgs e)
        {
            if (Variables.hasMadeChanges)
            {
                DialogResult saveChangesDialog = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (saveChangesDialog == DialogResult.Yes)
                {
                    SaveDocument();
                }
                else if (saveChangesDialog == DialogResult.No)
                {
                    OpenDocument();
                }
                else { }
            }
            else
            {
                OpenDocument();
            }
        }

        private void m_Fonts_Click(object sender, EventArgs e)
        {
            var settings = new frm_Settings(this);
            settings.ShowDialog();
        }

        private void m_Save_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void m_SaveAs_Click(object sender, EventArgs e)
        {
            SaveAsDocument();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            UpdateCharacters();
        }

        private void m_Paste_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Paste();
        }

        private void m_Cut_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Cut();
        }

        private void m_Copy_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Copy();
        }

        private void m_Delete_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Text = "";
        }

        private void m_SelectAll_Click(object sender, EventArgs e)
        {
            Variables._TextBox.SelectAll();
        }

        private void m_FindNext_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Variables.F3Text))
            {
                hasF3d = true;
                MoveToNextMatch(Variables._TextBox, true, false, Variables.F3Text);
            }
        }

        private void m_FindPrevious_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Variables.F3Text))
            {
                MoveToNextMatch(Variables._TextBox, false, false, Variables.F3Text);
            }
        }

        private int GetIntialCharPos(string Text)
        {
            int row = Variables._TextBox.GetLineIndexFromCharacterIndex(Variables._TextBox.CaretIndex);
            int col = Variables._TextBox.CaretIndex - Variables._TextBox.GetCharacterIndexFromLineIndex(row);
            return col;
        }

        private void m_Undo_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Undo();
        }

        private void m_Redo_Click(object sender, EventArgs e)
        {
            Variables._TextBox.Redo();
        }

        private void btn_ToUpper_Click(object sender, EventArgs e)
        {
            Variables._TextBox.SelectedText = Variables._TextBox.SelectedText.ToUpper();
        }

        private void btn_ToLower_Click(object sender, EventArgs e)
        {
            Variables._TextBox.SelectedText = Variables._TextBox.SelectedText.ToLower();
        }

        private void btn_CapEachWord_Click(object sender, EventArgs e)
        {
            Variables._TextBox.SelectedText = Variables._TextBox.SelectedText.ToLower();
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = new CultureInfo(currentCulture.ToString(), false).TextInfo;
            Variables._TextBox.SelectedText = textInfo.ToTitleCase(Variables._TextBox.SelectedText);
        }

        public bool findOpen = false;
        private frm_FindReplace _FindDialog;
        private void m_Find_Click(object sender, EventArgs e)
        {
            if (!Variables.alreadyOpenedFind)
            {
                Variables.tabIndex = 0;
                _FindDialog = new frm_FindReplace(this);
                _FindDialog.StartPosition = FormStartPosition.Manual;
                _FindDialog.Location = new System.Drawing.Point(this.Location.X + (this.Width - _FindDialog.Width) / 2, this.Location.Y + (this.Height - _FindDialog.Height) / 2);
                _FindDialog.Show(this);
                findOpen = true;
            }
        }

        private void m_Replace_Click(object sender, EventArgs e)
        {
            if (!Variables.alreadyOpenedFind)
            {
                Variables.tabIndex = 1;
                _FindDialog = new frm_FindReplace(this);
                _FindDialog.StartPosition = FormStartPosition.Manual;
                _FindDialog.Location = new System.Drawing.Point(this.Location.X + (this.Width - _FindDialog.Width) / 2, this.Location.Y + (this.Height - _FindDialog.Height) / 2);
                _FindDialog.Show(this);
            }
        }

        private void m_GoTo_Click(object sender, EventArgs e)
        {
            if (!Variables.alreadyOpenedFind)
            {
                Variables.tabIndex = 2;
                _FindDialog = new frm_FindReplace(this);
                _FindDialog.StartPosition = FormStartPosition.Manual;
                _FindDialog.Location = new System.Drawing.Point(this.Location.X + (this.Width - _FindDialog.Width) / 2, this.Location.Y + (this.Height - _FindDialog.Height) / 2);
                _FindDialog.Show(this);
                _FindDialog.FocusGoTo();
            }
        }

        void _TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        #region Search Related
        bool hasF3d;
        bool hasEdited;
        bool firstTry = true;
        int pre_fIndex;


        public void MoveToNextMatch(System.Windows.Controls.TextBox box, bool forward, bool matchCase, string text)
        {
            var needle = text;
            var haystack = box.Text;
            int index = box.SelectionStart;
            StringComparison mode = matchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            if (forward)
            {
                if (firstTry)
                {
                    if (hasF3d)
                    {
                        index = haystack.IndexOf(needle, index + 1, mode);
                        if (index < 0)
                        {
                            index = haystack.IndexOf(needle, 0, mode);
                        }
                        firstTry = false;
                    }
                    else
                    {
                        index = haystack.IndexOf(needle, index, mode);
                        if (index < 0)
                        {
                            index = haystack.IndexOf(needle, 0, mode);
                        }
                        firstTry = false;
                    }

                }
                else
                {
                    index = haystack.IndexOf(needle, pre_fIndex, mode);
                    if (hasEdited)
                    {

                        if (index < 0)
                        {
                            index = haystack.IndexOf(needle, 0, mode);
                        }
                        hasEdited = false;
                    }
                    else
                    {
                        index = haystack.IndexOf(needle, index + 1, mode);
                        if (index < 0)
                        {
                            index = haystack.IndexOf(needle, 0, mode);
                        }
                    }
                }
            }
            else
            {
                if (index == 0)
                {
                    index = -1;
                }
                else
                {
                    if (hasEdited)
                    {
                        index = haystack.LastIndexOf(needle, pre_fIndex - 1, mode);
                        hasEdited = false;
                    }
                    else
                    {
                        index = haystack.LastIndexOf(needle, index - 1, mode);
                    }
                }

                if (index < 0)
                {
                    index = haystack.LastIndexOf(needle, haystack.Length - 1, mode);
                    firstTry = false;
                }
            }

            pre_fIndex = index;

            if (index >= 0 & index != -1)
            {
                box.SelectionStart = index;
                box.SelectionLength = needle.Length;
            }

            if (index == -1)
            {
                index = 0;
                pre_fIndex = 0;
                if (Variables.alreadyOpenedFind)
                {
                    _FindDialog.ShowNone();
                }

            }

            if (index == haystack.IndexOf(text) & index != -1)
            {
                if (Variables.alreadyOpenedFind)
                {
                    _FindDialog.ShowFirst();
                }
            }

            if (index == haystack.LastIndexOf(text) & index != -1)
            {
                if (Variables.alreadyOpenedFind)
                {
                    _FindDialog.ShowLast();
                }

            }
            box.Focus();
        }
        #endregion

        private frm_Updates _UpdateDialog;

        private void m_Updates_Click(object sender, EventArgs e)
        {

            _UpdateDialog = new frm_Updates(this);
            _UpdateDialog.ShowDialog(this);
        }

        public void ChangeUpdateAvailableText()
        {
            ts_UpdAvl.Text = "Install Update";
        }

        public void showUpdateAvailability()
        {
            ts_UpdAvl.Visible = true;
        }

        private void ts_UpdAvl_Click(object sender, EventArgs e)
        {
            if (ts_UpdAvl.Text == "Install Update")
            {
                _UpdateDialog = new frm_Updates(this);
                _UpdateDialog.ShowDialog(this);
            }
            else
            {
                Variables.triggerSaveDialog = true;
                _UpdateDialog = new frm_Updates(this);
                _UpdateDialog.ShowDialog(this);
            }
        }

        System.Timers.Timer timer;
        public System.Timers.Timer getSystemUpdateTimer()
        {
            return timer;
        }

        public void createUpdateTimer()
        {
            timer = new System.Timers.Timer();
            if (updateInfo.AutUpdateCheckInterval == "30 Seconds")
            {
                timer.Interval = 30000;
            }
            else if (updateInfo.AutUpdateCheckInterval == "1 Minute")
            {
                timer.Interval = 60000;
            }
            else if (updateInfo.AutUpdateCheckInterval == "3 Minutes")
            {
                timer.Interval = 180000;
            }
            else if (updateInfo.AutUpdateCheckInterval == "6 Minutes")
            {
                timer.Interval = 360000;
            }
            else
            {
                timer.Interval = 30000;
                updateInfo.AutUpdateCheckInterval = "30 Seconds";
                string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");
                string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(string.Format(@"{0}\Update Information.txt", SettingsFolder)))
                {
                    writer.Write(jsonOutput);
                }
            }

            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!bgwCheckUpdate.IsBusy)
            {
                bgwCheckUpdate.RunWorkerAsync();
            }
            else if (bgwCheckUpdate.IsBusy)
            {
                bgwCheckUpdate.CancelAsync();
            }
        }

        public BackgroundWorker getBackgroundWorkerUpdate()
        {
            return bgwCheckUpdate;
        }

        private void bgwCheckUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                HttpWebRequest update_versionRequest = (HttpWebRequest)WebRequest.Create("https://dl.dropboxusercontent.com/u/82716142/Spellpad%20Update%20Files/Update/Files/Main_Update.txt");
                HttpWebResponse update_versionResponse = (HttpWebResponse)update_versionRequest.GetResponse();
                StreamReader update_versionReader = new StreamReader(update_versionResponse.GetResponseStream());
                string NewVersion = update_versionReader.ReadToEnd();
                string currentversion = System.Windows.Forms.Application.ProductVersion;
                Variables.tempNewVersion = NewVersion;
                if (NewVersion.Contains(currentversion))
                {
                    Variables.updateAvailable = false;
                    ts_UpdAvl.Visible = false;
                }
                else
                {
                    CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    var ci = new CultureInfo(currentCulture.ToString());

                    updateInfo.LastCheckedUpdate = string.Format("{0} at {1}", DateTime.Now.ToString("D", ci), DateTime.Now.ToString("t", ci));

                    string sPath = string.Format(@"{0}\Update Information.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings"));

                    string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                    using (StreamWriter writer = new StreamWriter(sPath))
                    {
                        writer.Write(jsonOutput);
                    }

                    Variables.updateAvailable = true;
                    bgwCheckUpdate.CancelAsync();
                    ts_UpdAvl.Visible = true;
                }
            }

            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show(string.Format("Updater couldn't check for updates properly due to an unkown error. Auto update will be disabled till the next startup.", ProductName), "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //string jsonOutput = JsonConvert.SerializeObject(updateInfo, Formatting.Indented);
                //updateInfo.AutoUpdateChecked = "False";
                ////getSystemUpdateTimer().Enabled = false;
                //string sPath = string.Format(@"{0}\Update Information.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings"));
                //using (StreamWriter writer = new StreamWriter(sPath))
                //{
                //    writer.Write(jsonOutput);
                //}
            }
        }

        private void bgwCheckUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgwCheckUpdate.CancelAsync();
        }

        private void m_About_Click(object sender, EventArgs e)
        {
            frm_About AboutDialog = new frm_About();
            AboutDialog.ShowDialog();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            #region Save Windows State 
            switch (this.WindowState)
            {
                case FormWindowState.Minimized:
                    ini_GlobalSettings.Write("Program Window", "Window_State", "Normal");
                    break;
                case FormWindowState.Normal:
                case FormWindowState.Maximized:
                    ini_GlobalSettings.Write("Program Window", "Window_State", this.WindowState.ToString());
                    break;

                default:
                    ini_GlobalSettings.Write("Program Window", "Window_State", this.WindowState.ToString());
                    break;
            }
            #endregion

            #region Check If Saved
            if (Variables.hasMadeChanges)
            {
                if (Variables.saveAndQuit)
                {
                    if (Variables.fromInstallMenu)
                    {
                        DialogResult saveBeforeRestart = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                        if (saveBeforeRestart == DialogResult.Yes)
                        {
                            _TriggerSave();
                        }
                        else if (saveBeforeRestart == DialogResult.No)
                        {
                            Process.Start(updateInfo.UpdateLocation);
                        }
                        else if (saveBeforeRestart == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        DialogResult saveBeforeRestart = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (saveBeforeRestart == DialogResult.Yes)
                        {
                            _TriggerSave();
                        }
                        else if (saveBeforeRestart == DialogResult.No)
                        {
                            Process.Start(updateInfo.UpdateLocation);
                        }
                    }
                }
                else
                {
                    DialogResult saveBeforeRestart = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (saveBeforeRestart == DialogResult.Yes)
                    {
                        _TriggerSave();
                    }
                    else if (saveBeforeRestart == DialogResult.No)
                    {

                    }
                    else if (saveBeforeRestart == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }

            }
            else
            {
                e.Cancel = false;
            }
            #endregion
        }

        private void m_Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            LoadTimes();

            if (!string.IsNullOrWhiteSpace(Variables.F3Text))
            {
                m_FindNext.Enabled = true;
                m_FindPrevious.Enabled = true;
            }
        }

        private void m_Feedback_Click(object sender, EventArgs e)
        {
            frm_Feedback frmFeedback = new frm_Feedback();
            frmFeedback.ShowDialog();
        }

        private void m_PrintPreview_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog.Document = PrintDoc;
            PrintPreviewDialog.ShowDialog();
        }

        private void m_PrintNow_Click(object sender, EventArgs e)
        {
            PrintDoc.DocumentName = this.Text;
            string StringToPrint = Variables._TextBox.Text;
            PrintDoc.Print();
        }

        string textbeforePrinting;
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            textbeforePrinting = Variables._TextBox.Text;
            Font PrintFont = new Font(Variables._TextBox.FontFamily.ToString(), Convert.ToSingle(Variables._TextBox.FontSize));
            int charactersOnPage = Variables._TextBox.Text.Length;
            int linesPerPage = 0;

            //e.Graphics.DrawRectangle(Pens.Red, e.MarginBounds)
            e.Graphics.MeasureString(Variables._TextBox.Text, PrintFont, e.MarginBounds.Size, StringFormat.GenericDefault, out charactersOnPage, out linesPerPage);
            e.Graphics.DrawString(Variables._TextBox.Text, PrintFont, System.Drawing.Brushes.Black, e.MarginBounds, StringFormat.GenericDefault);

            Variables._TextBox.Text = Variables._TextBox.Text.Substring(charactersOnPage);
            e.HasMorePages = Variables._TextBox.Text.Length > 0;
            Variables._TextBox.Text = textbeforePrinting;
        }

        private void frm_Main_Resize(object sender, EventArgs e)
        {
            TrackWindowState();
        }

        private void frm_Main_Move(object sender, EventArgs e)
        {
            TrackWindowState();
        }

        private void m_WhatsNew_Click(object sender, EventArgs e)
        {
            frmWhatsNew WhatsNew = new frmWhatsNew();
            WhatsNew.ShowDialog();
        }

        private void btn_SpecialReplace_Click(object sender, EventArgs e)
        {
            if (Variables._TextBox.Text.Contains("‘") | Variables._TextBox.Text.Contains("’") | Variables._TextBox.Text.Contains("`") | Variables._TextBox.Text.Contains("“") | Variables._TextBox.Text.Contains("”") | Variables._TextBox.Text.Contains("—"))
            {
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("‘", "'");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("’", "'");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("`", "'");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("“", "\"");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("”", "\"");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("„", "\"");
                Variables._TextBox.Text = Variables._TextBox.Text.Replace("—", " - ");
                Variables._TextBox.ScrollToEnd();
                Variables._TextBox.Select(Variables._TextBox.Text.Length, 0);
            }
        }

        private void m_CloseDocument_Click(object sender, EventArgs e)
        {
            if (Variables.hasMadeChanges)
            {
                DialogResult saveChangesDialog = System.Windows.Forms.MessageBox.Show("Would you like to save the changes you have made to this document?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (saveChangesDialog == DialogResult.Yes)
                {
                    SaveDocument();
                    NewDocument();
                }
                else if (saveChangesDialog == DialogResult.No)
                {
                    NewDocument();
                }
            }
            else
            {
                NewDocument();
            }
        }

        frm_Insert _InsertSymbols;
        private void m_Insert_Click(object sender, EventArgs e)
        {
            if (!Variables.alreadyOpenedInsert)
            {
                _InsertSymbols = new frm_Insert(this);
                _InsertSymbols.StartPosition = FormStartPosition.Manual;
                _InsertSymbols.Location = new System.Drawing.Point(this.Location.X + (this.Width - _InsertSymbols.Width) / 2, this.Location.Y + (this.Height - _InsertSymbols.Height) / 2);
                _InsertSymbols.Show(this);
            }
        }

        private void m_Print_Click(object sender, EventArgs e)
        {

        }

        private void PrintPreviewDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
