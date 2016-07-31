using Spellpad.Classes.Ini;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Classes
{
    class MruMenu
    {
        IniFile ini_GlobalSettings = new IniFile(Variables.IniSettingsPath);
        private List<string> RecentItemsList = new List<string>();
        
        public void SaveToList(string filePathToSave)
        {
            ini_GlobalSettings.Write("Recent List", filePathToSave, Path.GetFileName(filePathToSave));
        }

        public List<string> getRecentItems(List<string> listWithItems)
        {
            foreach (string recentItem in listWithItems)
            {
                if (!RecentItemsList.Contains(recentItem))
                {
                    RecentItemsList.Add(recentItem);
                }
            }
            return RecentItemsList;
        }

        public void ClearRecents(List<string> listWithRecents)
        {
            foreach (var item in IniFile.GetKeys(Variables.IniSettingsPath, "Recent List").ToList())
            {
                ini_GlobalSettings.DeleteKey("Recent List", item);
            }
            listWithRecents.Clear();
        }

        public void PlaceOnTop(List<string> listWithRecents, string ItemToPlaceOnTop)
        {
            var filePath = listWithRecents.FirstOrDefault(x => x.Contains(ItemToPlaceOnTop));
            listWithRecents.Remove(filePath);
            listWithRecents.Insert(0, filePath);

            foreach (var item in IniFile.GetKeys(Variables.IniSettingsPath, "Recent List").ToList())
            {
                ini_GlobalSettings.DeleteKey("Recent List", item);
            }

            foreach (string item in listWithRecents)
            {
                ini_GlobalSettings.Write("Recent List", item, Path.GetFileName(item));
            }
        }
    }
}
