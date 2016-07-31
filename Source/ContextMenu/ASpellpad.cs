using System.Windows.Forms;
using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using ContextMenu.Properties;
using Microsoft.Win32;
using System.Diagnostics;
using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System.Drawing;

[ComVisible(true)]
[COMServerAssociation(AssociationType.AllFiles)]
[Guid("E4B9A575-60B6-4F8E-9388-F126473A8DE6")]
public class ASpellpad : SharpContextMenu
{
    protected override bool CanShowMenu()
    {
        return true;
    }

    protected override ContextMenuStrip CreateMenu()
    {
        
        var menu = new ContextMenuStrip();
        //string InstallPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Spellpad", "ContextMenuIconSize", "96");
        //if (InstallPath != null)
        //{
        //    if (InstallPath == "96")
        //    {
                var itemCountLines = new ToolStripMenuItem
                {
                    Text = "Edit with Spellpad",
                    Image = Resources.Notepad_16,
                    AutoSize = true,
                    ImageScaling = ToolStripItemImageScaling.SizeToFit
                };
                itemCountLines.Click += (sender, args) => CountLines();
                menu.Items.Add(itemCountLines);
        //    }
        //    else
        //    {
        //        var itemCountLines = new ToolStripMenuItem
        //        {
        //            Text = "Edit with Spellpad",
        //            Image = Resources.Notepad_24,
        //            AutoSize = true,
        //            ImageScaling = ToolStripItemImageScaling.SizeToFit
        //        };
        //        itemCountLines.Click += (sender, args) => CountLines();
        //        menu.Items.Add(itemCountLines);
        //    }
        //}

        return menu;
    }

    private void CountLines()
    {
        string openWith = Registry.GetValue(string.Format("HKEY_LOCAL_MACHINE\\Software\\WOW6432Node\\Spellpad"), "CommandLineArgument", null).ToString();
        foreach (var filePath in SelectedItemPaths)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            string commandArg = string.Format("\"{0}\"", info.FullName);
            Process.Start(openWith, commandArg);
        }
    }
}
