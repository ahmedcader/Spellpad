namespace Spellpad.Forms
{
    partial class frm_Updates
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
            this.components = new System.ComponentModel.Container();
            this.lbl_currentText = new System.Windows.Forms.Label();
            this.lbl_Status = new System.Windows.Forms.Label();
            this.lbl_LastChecked = new System.Windows.Forms.Label();
            this.chkbx_CheckUpdate = new System.Windows.Forms.CheckBox();
            this.btn_Check = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_LastCheckedVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_CheckEveryCollection = new System.Windows.Forms.ComboBox();
            this.tmrChange = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_currentText
            // 
            this.lbl_currentText.AutoSize = true;
            this.lbl_currentText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentText.Location = new System.Drawing.Point(5, 0);
            this.lbl_currentText.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lbl_currentText.Name = "lbl_currentText";
            this.lbl_currentText.Size = new System.Drawing.Size(100, 17);
            this.lbl_currentText.TabIndex = 10;
            this.lbl_currentText.Text = "Current version:";
            // 
            // lbl_Status
            // 
            this.lbl_Status.AutoSize = true;
            this.lbl_Status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Status.Location = new System.Drawing.Point(8, 5);
            this.lbl_Status.Margin = new System.Windows.Forms.Padding(8, 5, 3, 8);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(201, 17);
            this.lbl_Status.TabIndex = 6;
            this.lbl_Status.Text = "You have the latest version of {0}.";
            // 
            // lbl_LastChecked
            // 
            this.lbl_LastChecked.AutoSize = true;
            this.lbl_LastChecked.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastChecked.Location = new System.Drawing.Point(8, 60);
            this.lbl_LastChecked.Margin = new System.Windows.Forms.Padding(8, 0, 3, 20);
            this.lbl_LastChecked.Name = "lbl_LastChecked";
            this.lbl_LastChecked.Size = new System.Drawing.Size(120, 17);
            this.lbl_LastChecked.TabIndex = 13;
            this.lbl_LastChecked.Text = "Last checked on {0}";
            // 
            // chkbx_CheckUpdate
            // 
            this.chkbx_CheckUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbx_CheckUpdate.AutoSize = true;
            this.chkbx_CheckUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbx_CheckUpdate.Location = new System.Drawing.Point(11, 100);
            this.chkbx_CheckUpdate.Margin = new System.Windows.Forms.Padding(11, 3, 3, 0);
            this.chkbx_CheckUpdate.Name = "chkbx_CheckUpdate";
            this.chkbx_CheckUpdate.Size = new System.Drawing.Size(200, 19);
            this.chkbx_CheckUpdate.TabIndex = 12;
            this.chkbx_CheckUpdate.Text = "Check for Updates Automatically";
            this.chkbx_CheckUpdate.UseVisualStyleBackColor = true;
            this.chkbx_CheckUpdate.CheckedChanged += new System.EventHandler(this.chkbx_CheckUpdate_CheckedChanged);
            // 
            // btn_Check
            // 
            this.btn_Check.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Check.Location = new System.Drawing.Point(10, 166);
            this.btn_Check.Margin = new System.Windows.Forms.Padding(10, 3, 3, 8);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(93, 24);
            this.btn_Check.TabIndex = 11;
            this.btn_Check.Text = "Check";
            this.btn_Check.UseVisualStyleBackColor = true;
            this.btn_Check.Click += new System.EventHandler(this.btn_CheckUpdate_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.lbl_Status);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.lbl_LastChecked);
            this.flowLayoutPanel1.Controls.Add(this.chkbx_CheckUpdate);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cmb_CheckEveryCollection);
            this.flowLayoutPanel1.Controls.Add(this.btn_Check);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(478, 201);
            this.flowLayoutPanel1.TabIndex = 15;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lbl_currentText, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_LastCheckedVersion, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(131, 17);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lbl_LastCheckedVersion
            // 
            this.lbl_LastCheckedVersion.AutoSize = true;
            this.lbl_LastCheckedVersion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastCheckedVersion.Location = new System.Drawing.Point(105, 0);
            this.lbl_LastCheckedVersion.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_LastCheckedVersion.Name = "lbl_LastCheckedVersion";
            this.lbl_LastCheckedVersion.Size = new System.Drawing.Size(26, 17);
            this.lbl_LastCheckedVersion.TabIndex = 10;
            this.lbl_LastCheckedVersion.Text = "{0}.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Auto check updates every:";
            this.label1.Visible = false;
            // 
            // cmb_CheckEveryCollection
            // 
            this.cmb_CheckEveryCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CheckEveryCollection.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_CheckEveryCollection.FormattingEnabled = true;
            this.cmb_CheckEveryCollection.Items.AddRange(new object[] {
            "30 Seconds",
            "1 Minute",
            "3 Minutes",
            "6 Minutes"});
            this.cmb_CheckEveryCollection.Location = new System.Drawing.Point(11, 139);
            this.cmb_CheckEveryCollection.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.cmb_CheckEveryCollection.MaxDropDownItems = 3;
            this.cmb_CheckEveryCollection.Name = "cmb_CheckEveryCollection";
            this.cmb_CheckEveryCollection.Size = new System.Drawing.Size(198, 21);
            this.cmb_CheckEveryCollection.TabIndex = 14;
            this.cmb_CheckEveryCollection.Visible = false;
            this.cmb_CheckEveryCollection.SelectionChangeCommitted += new System.EventHandler(this.cmb_CheckEveryCollection_SelectionChangeCommitted);
            // 
            // tmrChange
            // 
            this.tmrChange.Interval = 1;
            this.tmrChange.Tick += new System.EventHandler(this.tmrChange_Tick);
            // 
            // frm_Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(478, 201);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Updates";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spellpad Updates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Updates_FormClosed);
            this.Shown += new System.EventHandler(this.frm_Updates_Shown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_currentText;
        private System.Windows.Forms.Label lbl_Status;
        private System.Windows.Forms.Label lbl_LastChecked;
        private System.Windows.Forms.CheckBox chkbx_CheckUpdate;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmb_CheckEveryCollection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LastCheckedVersion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer tmrChange;
    }
}