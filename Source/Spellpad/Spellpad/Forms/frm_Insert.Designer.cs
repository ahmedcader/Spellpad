namespace Spellpad.Forms
{
    partial class frm_Insert
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
            this.pnl_SymbolHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_symbol = new System.Windows.Forms.TextBox();
            this.btn_AddSymbol = new System.Windows.Forms.Button();
            this.btn_EditSymbols = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_SymbolHolder
            // 
            this.pnl_SymbolHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_SymbolHolder.AutoScroll = true;
            this.pnl_SymbolHolder.Location = new System.Drawing.Point(11, 59);
            this.pnl_SymbolHolder.Name = "pnl_SymbolHolder";
            this.pnl_SymbolHolder.Size = new System.Drawing.Size(266, 165);
            this.pnl_SymbolHolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add custom symbol:";
            // 
            // tb_symbol
            // 
            this.tb_symbol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_symbol.Font = new System.Drawing.Font("Segoe UI Emoji", 8F);
            this.tb_symbol.Location = new System.Drawing.Point(15, 29);
            this.tb_symbol.MaxLength = 1;
            this.tb_symbol.Name = "tb_symbol";
            this.tb_symbol.Size = new System.Drawing.Size(145, 22);
            this.tb_symbol.TabIndex = 2;
            this.tb_symbol.TextChanged += new System.EventHandler(this.tb_symbol_TextChanged);
            // 
            // btn_AddSymbol
            // 
            this.btn_AddSymbol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_AddSymbol.Enabled = false;
            this.btn_AddSymbol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSymbol.Location = new System.Drawing.Point(166, 29);
            this.btn_AddSymbol.Name = "btn_AddSymbol";
            this.btn_AddSymbol.Size = new System.Drawing.Size(53, 24);
            this.btn_AddSymbol.TabIndex = 3;
            this.btn_AddSymbol.Text = "Add";
            this.btn_AddSymbol.UseVisualStyleBackColor = true;
            this.btn_AddSymbol.Click += new System.EventHandler(this.btn_AddSymbol_Click);
            // 
            // btn_EditSymbols
            // 
            this.btn_EditSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_EditSymbols.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EditSymbols.Location = new System.Drawing.Point(221, 29);
            this.btn_EditSymbols.Name = "btn_EditSymbols";
            this.btn_EditSymbols.Size = new System.Drawing.Size(53, 24);
            this.btn_EditSymbols.TabIndex = 4;
            this.btn_EditSymbols.Text = "Edit";
            this.btn_EditSymbols.UseVisualStyleBackColor = true;
            this.btn_EditSymbols.Click += new System.EventHandler(this.btn_EditSymbols_Click);
            // 
            // frm_Insert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(290, 229);
            this.Controls.Add(this.btn_EditSymbols);
            this.Controls.Add(this.btn_AddSymbol);
            this.Controls.Add(this.tb_symbol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_SymbolHolder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Insert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Insert_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_SymbolHolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_symbol;
        private System.Windows.Forms.Button btn_AddSymbol;
        private System.Windows.Forms.Button btn_EditSymbols;
    }
}