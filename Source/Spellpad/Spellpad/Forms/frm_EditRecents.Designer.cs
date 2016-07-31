namespace Spellpad.Forms
{
    partial class frm_EditRecents
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
            this.chkklb_RecentsMenu = new System.Windows.Forms.CheckedListBox();
            this.btn_ClearAll = new System.Windows.Forms.Button();
            this.btn_RemoveSelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkklb_RecentsMenu
            // 
            this.chkklb_RecentsMenu.CheckOnClick = true;
            this.chkklb_RecentsMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkklb_RecentsMenu.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chkklb_RecentsMenu.FormattingEnabled = true;
            this.chkklb_RecentsMenu.HorizontalScrollbar = true;
            this.chkklb_RecentsMenu.Location = new System.Drawing.Point(0, 0);
            this.chkklb_RecentsMenu.Name = "chkklb_RecentsMenu";
            this.chkklb_RecentsMenu.Size = new System.Drawing.Size(284, 225);
            this.chkklb_RecentsMenu.TabIndex = 0;
            this.chkklb_RecentsMenu.SelectedIndexChanged += new System.EventHandler(this.chkklb_RecentsMenu_SelectedIndexChanged);
            // 
            // btn_ClearAll
            // 
            this.btn_ClearAll.AutoSize = true;
            this.btn_ClearAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearAll.Location = new System.Drawing.Point(12, 251);
            this.btn_ClearAll.Name = "btn_ClearAll";
            this.btn_ClearAll.Size = new System.Drawing.Size(75, 25);
            this.btn_ClearAll.TabIndex = 1;
            this.btn_ClearAll.Text = "Clear All";
            this.btn_ClearAll.UseVisualStyleBackColor = true;
            this.btn_ClearAll.Click += new System.EventHandler(this.btn_ClearAll_Click);
            // 
            // btn_RemoveSelected
            // 
            this.btn_RemoveSelected.AutoSize = true;
            this.btn_RemoveSelected.Enabled = false;
            this.btn_RemoveSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveSelected.Location = new System.Drawing.Point(93, 251);
            this.btn_RemoveSelected.Name = "btn_RemoveSelected";
            this.btn_RemoveSelected.Size = new System.Drawing.Size(107, 25);
            this.btn_RemoveSelected.TabIndex = 2;
            this.btn_RemoveSelected.Text = "Remove Selected";
            this.btn_RemoveSelected.UseVisualStyleBackColor = true;
            this.btn_RemoveSelected.Click += new System.EventHandler(this.btn_RemoveSelected_Click);
            // 
            // frm_EditRecents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 286);
            this.Controls.Add(this.btn_RemoveSelected);
            this.Controls.Add(this.btn_ClearAll);
            this.Controls.Add(this.chkklb_RecentsMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EditRecents";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Recents List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkklb_RecentsMenu;
        private System.Windows.Forms.Button btn_ClearAll;
        private System.Windows.Forms.Button btn_RemoveSelected;
    }
}