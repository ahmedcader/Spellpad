using Spellpad.Classes;
using Spellpad.Classes.Ini;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frm_About : Form
    {
        public frm_About()
        {
            InitializeComponent();

            Icon IEIcon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Image im = IEIcon.ToBitmap();
            pb_Icon.Image = im;
            lblProductName.Text = ProductName;
            lbl_Version.Text = string.Format("Version: {0}", ProductVersion);
        }

        private void btn_ForumPost_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + @"http://www.overclockers.com/forums/showthread.php/752487-Notepad-with-Spell-Checker-already-added-in!"));
        }

        private void btn_Donate_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "\"" + @"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GUVL2W3WAE5JN"));
        }
    }
}
