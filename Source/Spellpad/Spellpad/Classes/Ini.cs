using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Spellpad.Classes.Ini
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateDeleteString(string section, string key, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);


        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        public static List<string> GetKeys(string iniFile, string category)
        {
            byte[] buffer = new byte[2048];

            GetPrivateProfileSection(category, buffer, 2048, iniFile);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');

            List<string> result = new List<string>();

            foreach (String entry in tmp)
            {
                try
                {
                    result.Add(entry.Substring(0, entry.IndexOf("=")));
                }
                catch (Exception)
                {

                }
            }
            return result;
        }

        public bool KeyExists(string Section, string Key)
        {
            return Read(Key, Section).Length > 0;
        }

        public void Write(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public string Read(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }

        public void DeleteKey(string Section, string Key)
        {
            WritePrivateProfileString(Section, Key, null, this.path);
        }
    }
}
