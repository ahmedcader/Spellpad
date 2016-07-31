using Ionic.Zip;
using Spellpad.Classes.Ini;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Spellpad.Classes
{
    class Variables
    {
        //Program Variables

        public static string IniSettingsPath { get; set; }
        public static string JsonSettingsPath { get; set; }
        public static string DictionaryPath { get; set; }

        public static string Global_CustomDictionary { get; set; }
        public static string Global_DictionaryFile { get; set; }
        public static string MaxRecents = "20";

        public static bool isGlobalDict { get; set; }
        public static string EditingDictionary { get; set; }
        public static bool isNewDocument { get; set; }
        public static bool hasSavedDocument { get; set; }
        public static bool hasMadeChanges { get; set; }
        public static string DownloadingDictionary { get; set; }
        public static string FilePath { get; set; }
        public static System.Windows.Controls.TextBox _TextBox { get; set; }

        public static string DefaultDictionary { get; set; }
        public static List<string> List_RemovingDictionaries { get; set; }
        public static List<string> List_AddedDictionaries { get; set; }
        public static List<string> List_WordsFromDictionaries { get; set; }
        public static List<string> List_WithRecents { get; set; }
        public static List<string> List_SearchHistory { get; set; }
        public static List<string> List_ReplaceHistory { get; set; }
        public static List<string> currentDict { get; set; }
        public static bool HasAlteredSettings { get; set; }
        public static bool NeedSaveSettings { get; set; }
        public static bool mustRestoreDefault { get; set; }

        public static bool alreadyOpenedFind { get; set; }
        public static bool alreadyOpenedInsert { get; set; }
        public static bool fromInstallMenu { get; set; }
        public static bool saveAndQuit { get; set; }
        public static string lastUpdateChecked { get; set; }
        public static int tabIndex { get; set; }
        public static string downloadLocation { get; set; }
        public static bool updateHasDownloaded { get; set; }
        public static bool updateAvailable { get; set; }
        public static string tempNewVersion { get; set; }
        public static bool triggerSaveDialog { get; set; }
        public static bool openThroughCommandLine { get; set; }

        //Settings Variables
        public static bool Editor_ReplaceShowSuggestions { get; set; }
        public static int Editor_FontSize { get; set; }
        public static string Editor_Font { get; set; }
        public static string Editor_BackColor { get; set; }
        public static string Editor_ForeColor { get; set; }
        public static string Editor_SelectionColor { get; set; }
        public static bool Editor_SpellEnable { get; set; }
        public static bool Editor_Statusbar { get; set; }
        public static string Editor_RecentNumber { get; set; }
        public static bool Editor_WordWrap { get; set; }
        public static bool Editor_LargeToolbar { get; set; }
        public static bool Editor_QuickBar { get; set; }
        public static bool Editor_WarnBeforeClear { get; set; }
        public static bool Editor_MatchCaseFindings { get; set; }
        public static bool Program_CheckAutoUpdate { get; set; }
        public static string Program_FeedbackID { get; set; }
        public static string F3Text { get; set; }

       

        public static int CountWords(string value)
        {
            MatchCollection collection = Regex.Matches(value, "\\S+");
            return collection.Count;
        }

        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string GetID(int length)
        {
            string sGUID = null;
            sGUID = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12).ToUpper();
            return sGUID;
        }

        public static int GetServerFile(string uri)
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(uri);
            req.Method = "HEAD";
            int fileSize = 0;
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                int ContentLength;
                if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    fileSize = ContentLength;
                }
            }
            return fileSize;
        }

        public static void InitializeDictionary(System.Windows.Controls.TextBox _textBox, string lexPath)
        {
            _TextBox.SpellCheck.IsEnabled = false;
            IList dictionaries = SpellCheck.GetCustomDictionaries(_textBox);
            dictionaries.Clear();
            dictionaries.Add(new Uri(lexPath));
            _TextBox.SpellCheck.IsEnabled = Variables.Editor_SpellEnable;
        }

        public static void MoveCaretToLine(System.Windows.Controls.TextBox txtBox, int lineNumber)
        {
            txtBox.SelectionStart = txtBox.GetCharacterIndexFromLineIndex(lineNumber - 1);
            txtBox.SelectionLength = txtBox.GetLineLength(lineNumber - 1);
            txtBox.CaretIndex = txtBox.SelectionStart;
            txtBox.ScrollToLine(lineNumber - 1);
            txtBox.Focus();
        }

        public static void PutWordsInList()
        {
            if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
            {
                currentDict.Clear();
                foreach (var item in File.ReadAllLines(DefaultDictionary))
                {
                    if (!currentDict.Contains(item))
                    {
                        currentDict.Add(item);
                    }
                }
            }
        }

        public static void AddToDictionary()
        {
            if (!string.IsNullOrWhiteSpace(Variables.DefaultDictionary))
            {
                using (StreamWriter streamWriter = new StreamWriter(Variables.DefaultDictionary, false))
                {
                    foreach (var word in currentDict)
                    {
                        if (!(word == null))
                            streamWriter.WriteLine(word);
                    }
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(Variables.Global_CustomDictionary, false))
                {
                    foreach (var word in currentDict)
                    {
                        if (!(word == null))
                            streamWriter.WriteLine(word);
                    }
                }
            }

        }


        public static void Unzip(string ZipToUnpack, string ExtractDirectory)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(ZipToUnpack))
                {
                    foreach (var entry in zip)
                    {
                        entry.Extract(ExtractDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        public static String BytesToString(long byteCount)
        {
            string[] suf = { " B", " KB", " MB", " GB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public static void CreateFolder(string Location)
        {
            bool folderExists = System.IO.Directory.Exists(Location);
            if (!folderExists)
            {
                System.IO.Directory.CreateDirectory(Location);
            }
        }
        public static double PointsToPixels(double points)
        {
            return points * (96.0 / 72.0);
        }
        public static bool CheckValidFormatHtmlColor(string inputColor)
        {
            if (Regex.Match(inputColor, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
                return true;

            var result = System.Drawing.Color.FromName(inputColor);
            return result.IsKnownColor;
        }
        static void RemoveMissingDictionary(string Path)
        {
            IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
            ini_GlobalSettings.DeleteKey("Custom Dictionaries", Path);
        }
        public static void LoadWordsFromDictionaries()
        {
            string[] lines = File.ReadAllLines(Global_CustomDictionary);
            if (Variables.List_AddedDictionaries.Any())
            {
                foreach (var dictionaryPath in Variables.List_AddedDictionaries)
                {
                    if (File.Exists(dictionaryPath))
                    {
                        foreach (var word in File.ReadLines(dictionaryPath))
                        {
                            if (!Variables.List_WordsFromDictionaries.Contains(word))
                            {
                                using (StreamWriter w = File.AppendText(Global_CustomDictionary))
                                {
                                    if (!lines.Contains(word))
                                    {
                                        w.WriteLine(word);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        RemoveMissingDictionary(Path.GetFileName(dictionaryPath));
                    }
                }
            }
        }

        public static void ClearUndo()
        {
            Variables._TextBox.IsUndoEnabled = false;
            Variables._TextBox.IsUndoEnabled = true;
        }
    }
}
