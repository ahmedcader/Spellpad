namespace Spellpad.Forms
{
    partial class frm_GetSpellpad
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
            this.label1 = new System.Windows.Forms.Label();
            this.lnklbl_getSpellpad = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "To download the latest version of Spellpad, please visit: ";
            // 
            // lnklbl_getSpellpad
            // 
            this.lnklbl_getSpellpad.AutoSize = true;
            this.lnklbl_getSpellpad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklbl_getSpellpad.Location = new System.Drawing.Point(32, 24);
            this.lnklbl_getSpellpad.Name = "lnklbl_getSpellpad";
            this.lnklbl_getSpellpad.Size = new System.Drawing.Size(256, 15);
            this.lnklbl_getSpellpad.TabIndex = 1;
            this.lnklbl_getSpellpad.TabStop = true;
            this.lnklbl_getSpellpad.Text = "https://github.com/CDemha/Spellpad/releases";
            this.lnklbl_getSpellpad.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_getSpellpad_LinkClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.Location = new System.Drawing.Point(125, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_GetSpellpad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(324, 94);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lnklbl_getSpellpad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_GetSpellpad";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Spellpad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lnklbl_getSpellpad;
        private System.Windows.Forms.Button button1;
    }
}