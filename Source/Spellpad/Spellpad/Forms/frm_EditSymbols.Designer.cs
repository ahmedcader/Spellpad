namespace Spellpad.Forms
{
    partial class frm_EditSymbols
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_ListofSymbols = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RemoveSymbols = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_symbol = new System.Windows.Forms.TextBox();
            this.btn_AddSymbol = new System.Windows.Forms.Button();
            this.btn_ResetSymbols = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_ListofSymbols
            // 
            this.lb_ListofSymbols.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ListofSymbols.FormattingEnabled = true;
            this.lb_ListofSymbols.ItemHeight = 15;
            this.lb_ListofSymbols.Location = new System.Drawing.Point(15, 70);
            this.lb_ListofSymbols.Name = "lb_ListofSymbols";
            this.lb_ListofSymbols.Size = new System.Drawing.Size(151, 154);
            this.lb_ListofSymbols.TabIndex = 0;
            this.lb_ListofSymbols.SelectedIndexChanged += new System.EventHandler(this.lb_ListofSymbols_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Symbols:";
            // 
            // btn_RemoveSymbols
            // 
            this.btn_RemoveSymbols.Enabled = false;
            this.btn_RemoveSymbols.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveSymbols.Location = new System.Drawing.Point(172, 69);
            this.btn_RemoveSymbols.Name = "btn_RemoveSymbols";
            this.btn_RemoveSymbols.Size = new System.Drawing.Size(75, 24);
            this.btn_RemoveSymbols.TabIndex = 4;
            this.btn_RemoveSymbols.Text = "Remove";
            this.btn_RemoveSymbols.UseVisualStyleBackColor = true;
            this.btn_RemoveSymbols.Click += new System.EventHandler(this.btn_RemoveSymbols_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add Symbol:";
            // 
            // tb_symbol
            // 
            this.tb_symbol.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_symbol.Location = new System.Drawing.Point(15, 27);
            this.tb_symbol.MaxLength = 1;
            this.tb_symbol.Name = "tb_symbol";
            this.tb_symbol.Size = new System.Drawing.Size(151, 22);
            this.tb_symbol.TabIndex = 5;
            this.tb_symbol.TextChanged += new System.EventHandler(this.tb_symbol_TextChanged);
            // 
            // btn_AddSymbol
            // 
            this.btn_AddSymbol.Enabled = false;
            this.btn_AddSymbol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSymbol.Location = new System.Drawing.Point(172, 26);
            this.btn_AddSymbol.Name = "btn_AddSymbol";
            this.btn_AddSymbol.Size = new System.Drawing.Size(75, 24);
            this.btn_AddSymbol.TabIndex = 4;
            this.btn_AddSymbol.Text = "Add";
            this.btn_AddSymbol.UseVisualStyleBackColor = true;
            this.btn_AddSymbol.Click += new System.EventHandler(this.btn_AddSymbol_Click);
            // 
            // btn_ResetSymbols
            // 
            this.btn_ResetSymbols.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetSymbols.Location = new System.Drawing.Point(172, 99);
            this.btn_ResetSymbols.Name = "btn_ResetSymbols";
            this.btn_ResetSymbols.Size = new System.Drawing.Size(75, 41);
            this.btn_ResetSymbols.TabIndex = 6;
            this.btn_ResetSymbols.Text = "Reset Symbols";
            this.btn_ResetSymbols.UseVisualStyleBackColor = true;
            this.btn_ResetSymbols.Click += new System.EventHandler(this.btn_ResetSymbols_Click);
            // 
            // frm_EditSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(260, 235);
            this.Controls.Add(this.btn_ResetSymbols);
            this.Controls.Add(this.tb_symbol);
            this.Controls.Add(this.btn_AddSymbol);
            this.Controls.Add(this.btn_RemoveSymbols);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_ListofSymbols);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EditSymbols";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Symbols";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_ListofSymbols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RemoveSymbols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_symbol;
        private System.Windows.Forms.Button btn_AddSymbol;
        private System.Windows.Forms.Button btn_ResetSymbols;
    }
}