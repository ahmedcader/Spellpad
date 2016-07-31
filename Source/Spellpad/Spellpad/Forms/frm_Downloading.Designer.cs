namespace Spellpad.Forms
{
    partial class frm_Downloading
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
            this.lbl_OutOf = new System.Windows.Forms.Label();
            this.pb_Download = new System.Windows.Forms.ProgressBar();
            this.btn_CancelDownload = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_OutOf
            // 
            this.lbl_OutOf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OutOf.Location = new System.Drawing.Point(0, 0);
            this.lbl_OutOf.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OutOf.Name = "lbl_OutOf";
            this.lbl_OutOf.Size = new System.Drawing.Size(424, 24);
            this.lbl_OutOf.TabIndex = 0;
            this.lbl_OutOf.Text = "{0}/{1}";
            this.lbl_OutOf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_Download
            // 
            this.pb_Download.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Download.Location = new System.Drawing.Point(4, 27);
            this.pb_Download.Margin = new System.Windows.Forms.Padding(4, 3, 5, 3);
            this.pb_Download.Name = "pb_Download";
            this.pb_Download.Size = new System.Drawing.Size(415, 25);
            this.pb_Download.TabIndex = 1;
            // 
            // btn_CancelDownload
            // 
            this.btn_CancelDownload.AutoSize = true;
            this.btn_CancelDownload.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_CancelDownload.Location = new System.Drawing.Point(3, 58);
            this.btn_CancelDownload.Name = "btn_CancelDownload";
            this.btn_CancelDownload.Size = new System.Drawing.Size(111, 25);
            this.btn_CancelDownload.TabIndex = 3;
            this.btn_CancelDownload.Text = "Cancel Download";
            this.btn_CancelDownload.UseVisualStyleBackColor = true;
            this.btn_CancelDownload.Click += new System.EventHandler(this.btn_CancelDownload_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbl_OutOf, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_CancelDownload, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pb_Download, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(424, 86);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // frm_Downloading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(446, 105);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Downloading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Downloading Update";
            this.Shown += new System.EventHandler(this.frm_Downloading_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_OutOf;
        private System.Windows.Forms.ProgressBar pb_Download;
        private System.Windows.Forms.Button btn_CancelDownload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}