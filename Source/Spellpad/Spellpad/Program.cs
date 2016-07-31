using Spellpad.Classes;
using Spellpad.Forms;
using Spellpad.Forms.Spellpad_Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace Spellpad
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args != null && args.Length > 0)
                {
                    if (File.Exists(args[0]))
                    {
                        Variables.openThroughCommandLine = true;
                        Variables.FilePath = args[0];
                    }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_Main());
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        public static void Log(Exception ex)
        {
            string spellpadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Spellpad", "Exceptions");

            if (!Directory.Exists(spellpadFolder))
                Directory.CreateDirectory(spellpadFolder);

            string stackTrace = ex.StackTrace;
            string path = Path.Combine(spellpadFolder,string.Format("{1} - {0:ddd, MMM d, yyyy @ h.mm.ss tt}.txt", DateTime.Now,ex.GetType().ToString()));
            File.WriteAllText(path, string.Format("{0}", stackTrace));
        }
    }
}
