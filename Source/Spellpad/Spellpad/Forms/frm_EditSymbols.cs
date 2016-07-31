using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spellpad.Forms
{
    public partial class frm_EditSymbols : Form
    {
        private readonly frm_Insert formInsert;
        public frm_EditSymbols(frm_Insert insert)
        {
            formInsert = insert;
            InitializeComponent();

            for (int i = 0; i < formInsert.customSymbols.Count; i++)
            {
                lb_ListofSymbols.Items.Add(formInsert.customSymbols[i]);
            }

            if (lb_ListofSymbols.Items.Count == 0)
                btn_ResetSymbols.Enabled = false;
            else
                btn_ResetSymbols.Enabled = true;
        }


        private void btn_AddSymbol_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_symbol.Text))
            {
                if (!lb_ListofSymbols.Items.Contains(tb_symbol.Text))
                {
                    lb_ListofSymbols.Items.Add(tb_symbol.Text);
                    btn_AddSymbol.Enabled = false;

                    if (!formInsert.customSymbols.Contains(tb_symbol.Text))
                    {
                        formInsert.customSymbols.Add(tb_symbol.Text);
                        formInsert.GenerateNewSymbolButton(tb_symbol.Text);
                        tb_symbol.Text = "";
                        btn_AddSymbol.Enabled = false;

                        string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");
                        string output = JsonConvert.SerializeObject(formInsert.customSymbols, Formatting.Indented);
                        File.WriteAllText(string.Format(@"{0}\CustomSymbols.txt", SettingsFolder), output);
                        btn_ResetSymbols.Enabled = true;
                    }
                }
            }
        }

        private void tb_symbol_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_symbol.Text))
                btn_AddSymbol.Enabled = false;
            else
                btn_AddSymbol.Enabled = true;
        }

        private void lb_ListofSymbols_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_ListofSymbols.SelectedIndex != -1)
            {
                btn_RemoveSymbols.Enabled = true;
            }
            else if (lb_ListofSymbols.SelectedIndex == -1)
            {
                btn_RemoveSymbols.Enabled = false;
            }
        }

        private void btn_RemoveSymbols_Click(object sender, EventArgs e)
        {
            formInsert.RemoveSymbol(lb_ListofSymbols.SelectedItem.ToString());
            btn_RemoveSymbols.Enabled = false;
            lb_ListofSymbols.Items.Remove(lb_ListofSymbols.SelectedItem);
            lb_ListofSymbols.SelectedIndex = -1;

            if (lb_ListofSymbols.Items.Count == 0)
                btn_ResetSymbols.Enabled = false;
            else
                btn_ResetSymbols.Enabled = true;
        }

        private void btn_ResetSymbols_Click(object sender, EventArgs e)
        {
            string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");

            lb_ListofSymbols.Items.Clear();
            btn_RemoveSymbols.Enabled = false;
            lb_ListofSymbols.SelectedIndex = -1;


            foreach (Button button in formInsert.getCurrentSymbolPanel().Controls)
            {
                for (int i = 0; i < formInsert.customSymbols.Count; i++)
                {
                    formInsert.RemoveSymbol(formInsert.customSymbols[i]);
                    btn_ResetSymbols.Enabled = false;
                }
            }
        }
    }
}
