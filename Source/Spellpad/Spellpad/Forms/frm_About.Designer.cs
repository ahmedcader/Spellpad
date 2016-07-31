namespace Spellpad.Forms
{
    partial class frm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_About));
            this.Label3 = new System.Windows.Forms.Label();
            this.pb_Icon = new System.Windows.Forms.PictureBox();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.btn_Donate = new System.Windows.Forms.Button();
            this.btn_ForumPost = new System.Windows.Forms.Button();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(9, 63);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(382, 96);
            this.Label3.TabIndex = 26;
            this.Label3.Text = resources.GetString("Label3.Text");
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_Icon
            // 
            this.pb_Icon.Location = new System.Drawing.Point(12, 12);
            this.pb_Icon.Name = "pb_Icon";
            this.pb_Icon.Size = new System.Drawing.Size(61, 48);
            this.pb_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Icon.TabIndex = 29;
            this.pb_Icon.TabStop = false;
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.Location = new System.Drawing.Point(79, 31);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(65, 15);
            this.lbl_Version.TabIndex = 29;
            this.lbl_Version.Text = "Version: {0}";
            this.lbl_Version.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Donate
            // 
            this.btn_Donate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Donate.Location = new System.Drawing.Point(12, 191);
            this.btn_Donate.Name = "btn_Donate";
            this.btn_Donate.Size = new System.Drawing.Size(118, 23);
            this.btn_Donate.TabIndex = 30;
            this.btn_Donate.Text = "Make a Donation";
            this.btn_Donate.UseVisualStyleBackColor = true;
            this.btn_Donate.Click += new System.EventHandler(this.btn_Donate_Click);
            // 
            // btn_ForumPost
            // 
            this.btn_ForumPost.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForumPost.Location = new System.Drawing.Point(12, 162);
            this.btn_ForumPost.Name = "btn_ForumPost";
            this.btn_ForumPost.Size = new System.Drawing.Size(118, 23);
            this.btn_ForumPost.TabIndex = 31;
            this.btn_ForumPost.Text = "Spellpad Forum";
            this.btn_ForumPost.UseVisualStyleBackColor = true;
            this.btn_ForumPost.Click += new System.EventHandler(this.btn_ForumPost_Click);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(79, 16);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(39, 15);
            this.lblProductName.TabIndex = 32;
            this.lblProductName.Text = "Name";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(79, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ahmed.C";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frm_About
            // 
            this.AcceptButton = this.btn_ForumPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(403, 225);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.btn_ForumPost);
            this.Controls.Add(this.btn_Donate);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.pb_Icon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.PictureBox pb_Icon;
        internal System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Button btn_Donate;
        private System.Windows.Forms.Button btn_ForumPost;
        internal System.Windows.Forms.Label lblProductName;
        internal System.Windows.Forms.Label label1;
    }
}