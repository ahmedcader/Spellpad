using Newtonsoft.Json;
using Spellpad.Classes;
using Spellpad.Forms.Spellpad_Forms;
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
    public partial class frm_Insert : Form
    {
        public static string CharToHex(char c)
        {
            return ((ushort)c).ToString("X4");
        }
        public static char HexToChar(string hex)
        {
            return (char)ushort.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        }
        public List<string> customSymbols = new List<string>();
        private List<string> defaultSymbols = new List<string>();
        private readonly frm_Main formMain;
        public frm_Insert(frm_Main main)
        {
            MinimumSize = new Size(306, 268);
            formMain = main;

            string[] defaultSymbolsCollection = { "•", "✓", "°", "↑", "↓", "←", "→", "©", "½", "¢", "€", "£", "¥", "♪", "®" };

            InitializeComponent();

            for (int i = 0; i < defaultSymbolsCollection.Length; i++)
            {
                if (!defaultSymbols.Contains(defaultSymbolsCollection[i]))
                {
                    string x = CharToHex(Convert.ToChar(defaultSymbolsCollection[i]));
                    int value = int.Parse(x, System.Globalization.NumberStyles.HexNumber);
                    string symbol = char.ConvertFromUtf32(value).ToString();
                    AddSymbol(Convert.ToString((char)value), true);
                }
            }

            if (File.Exists(string.Format(@"{0}\CustomSymbols.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings"))))
            {
                List<string> deserializedProduct = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(string.Format(@"{0}\CustomSymbols.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings"))));
                customSymbols = deserializedProduct;
                if (!(customSymbols.Count < 0))
                {
                    for (int i = 0; i < customSymbols.Count; i++)
                    {
                        Button newSymbol = new Button()
                        {
                            Text = customSymbols[i],
                            Size = new Size(32, 32),
                            Font = new Font("Lucida Sans Unicode", 9),
                            Tag = customSymbols[i],
                            UseMnemonic = false
                        };
                        newSymbol.Click += SymbolButton_Click;
                        pnl_SymbolHolder.Controls.Add(newSymbol);
                    }
                }
                else
                {
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(string.Format(@"{0}\CustomSymbols.txt", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings")), true))
                {
                    sw.WriteLine("[]");
                }
            }
            Variables.alreadyOpenedInsert = true;
        }

        private void btn_AddSymbol_Click(object sender, EventArgs e)
        {
            AddSymbol(tb_symbol.Text, false);
        }

        public void RemoveSymbol(string _SymbolToRemove)
        {
            string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");

            foreach (Button button in pnl_SymbolHolder.Controls)
            {
                if ((string)button.Tag == _SymbolToRemove)
                {
                    pnl_SymbolHolder.Controls.Remove(button);
                    customSymbols.Remove(_SymbolToRemove);
                    break;
                }
            }
            string output = JsonConvert.SerializeObject(customSymbols, Formatting.Indented);
            File.WriteAllText(string.Format(@"{0}\CustomSymbols.txt", SettingsFolder), output);
        }

        public Panel getCurrentSymbolPanel()
        {
            return pnl_SymbolHolder;
        }

        public void AddSymbol(string _symbolText, bool initial)
        {
            if (initial)
            {
                Button symbolButton = new Button()
                {
                    Text = _symbolText,
                    Size = new Size(32, 32),
                    Font = new Font("Lucida Sans Unicode", 9),
                    Tag = _symbolText,
                    UseMnemonic = false,

                };
                symbolButton.Click += SymbolButton_Click;
                pnl_SymbolHolder.Controls.Add(symbolButton);
            }
            else
            {
                string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ProductName, "Settings");

                if (!string.IsNullOrWhiteSpace(tb_symbol.Text))
                {
                    if (!customSymbols.Contains(_symbolText))
                    {
                        customSymbols.Add(_symbolText);
                        Button newSymbol = new Button()
                        {
                            Text = _symbolText,
                            Size = new Size(32, 32),
                            Font = new Font("Lucida Sans Unicode", 9),
                            Tag = _symbolText,
                            UseMnemonic = false
                        };
                        newSymbol.Click += SymbolButton_Click;
                        pnl_SymbolHolder.Controls.Add(newSymbol);
                        tb_symbol.Text = "";
                        btn_AddSymbol.Enabled = false;

                        string output = JsonConvert.SerializeObject(customSymbols, Formatting.Indented);
                        File.WriteAllText(string.Format(@"{0}\CustomSymbols.txt", SettingsFolder), output);
                        //btn_EditSymbols.Enabled = true;
                    }
                }
            }
        }

        public void GenerateNewSymbolButton(string _SymbolText)
        {
            Button newSymbol = new Button()
            {
                Text = _SymbolText,
                Size = new Size(32, 32),
                Font = new Font("Lucida Sans Unicode", 9),
                Tag = _SymbolText,
                UseMnemonic = false
            };
            newSymbol.Click += SymbolButton_Click;
            pnl_SymbolHolder.Controls.Add(newSymbol);
        }

        private void SymbolButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Variables._TextBox.SelectedText = btn.Text + " ";
            Variables._TextBox.CaretIndex += Variables._TextBox.SelectedText.Length;
            Variables._TextBox.SelectionLength = 0;
        }

        private void frm_Insert_FormClosed(object sender, FormClosedEventArgs e)
        {
            Variables.alreadyOpenedInsert = false;
        }

        private void tb_symbol_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_symbol.Text))
            {
                btn_AddSymbol.Enabled = true;
            }
            else
            {
                btn_AddSymbol.Enabled = false;
            }
        }

        private frm_EditSymbols _editSymbols;
        private void btn_EditSymbols_Click(object sender, EventArgs e)
        {
            _editSymbols = new frm_EditSymbols(this);
            _editSymbols.StartPosition = FormStartPosition.Manual;
            _editSymbols.Location = new Point(Location.X + (this.Width - _editSymbols.Width) / 2, this.Location.Y + (this.Height - _editSymbols.Height) / 2);
            _editSymbols.ShowDialog(this);

        }
    }
}
