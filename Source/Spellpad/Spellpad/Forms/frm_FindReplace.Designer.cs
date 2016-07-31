namespace Spellpad.Forms
{
    partial class frm_FindReplace
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
            this.tab_SearchRepGo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.combobox1 = new Spellpad.Combobox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lnklbl_ClearSearchHistory = new System.Windows.Forms.LinkLabel();
            this.chkbx_MatchCase = new System.Windows.Forms.CheckBox();
            this.btn_FindPrevious = new System.Windows.Forms.Button();
            this.btn_FindNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.combobox3 = new Spellpad.Combobox();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.combobox2 = new Spellpad.Combobox();
            this.lnklbl_UndoReplacements = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.chkbx_matchCaseRep = new System.Windows.Forms.CheckBox();
            this.lnklbl_ClearReplaceHistory = new System.Windows.Forms.LinkLabel();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ReplaceAll = new System.Windows.Forms.Button();
            this.btn_Replace = new System.Windows.Forms.Button();
            this.btn_FindNextRep = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_LineCountTotal = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtbx_GoTo = new System.Windows.Forms.TextBox();
            this.btn_GoTo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_searchStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.totp_OnlyNumbers = new System.Windows.Forms.ToolTip(this.components);
            this.tmr_RefreshStatus = new System.Windows.Forms.Timer(this.components);
            this.tmr_CheckFocus = new System.Windows.Forms.Timer(this.components);
            this.tab_SearchRepGo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_SearchRepGo
            // 
            this.tab_SearchRepGo.Controls.Add(this.tabPage1);
            this.tab_SearchRepGo.Controls.Add(this.tabPage2);
            this.tab_SearchRepGo.Controls.Add(this.tabPage3);
            this.tab_SearchRepGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_SearchRepGo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tab_SearchRepGo.Location = new System.Drawing.Point(0, 0);
            this.tab_SearchRepGo.Name = "tab_SearchRepGo";
            this.tab_SearchRepGo.SelectedIndex = 0;
            this.tab_SearchRepGo.Size = new System.Drawing.Size(574, 249);
            this.tab_SearchRepGo.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.elementHost1);
            this.tabPage1.Controls.Add(this.btn_Close);
            this.tabPage1.Controls.Add(this.lnklbl_ClearSearchHistory);
            this.tabPage1.Controls.Add(this.chkbx_MatchCase);
            this.tabPage1.Controls.Add(this.btn_FindPrevious);
            this.tabPage1.Controls.Add(this.btn_FindNext);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(566, 221);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Find";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(87, 18);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(364, 22);
            this.elementHost1.TabIndex = 32;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.combobox1;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(470, 185);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 25);
            this.btn_Close.TabIndex = 29;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lnklbl_ClearSearchHistory
            // 
            this.lnklbl_ClearSearchHistory.AutoSize = true;
            this.lnklbl_ClearSearchHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnklbl_ClearSearchHistory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnklbl_ClearSearchHistory.Location = new System.Drawing.Point(84, 42);
            this.lnklbl_ClearSearchHistory.Name = "lnklbl_ClearSearchHistory";
            this.lnklbl_ClearSearchHistory.Size = new System.Drawing.Size(113, 15);
            this.lnklbl_ClearSearchHistory.TabIndex = 6;
            this.lnklbl_ClearSearchHistory.TabStop = true;
            this.lnklbl_ClearSearchHistory.Text = "Clear Search History";
            this.lnklbl_ClearSearchHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_ClearSearchHistory_LinkClicked);
            // 
            // chkbx_MatchCase
            // 
            this.chkbx_MatchCase.AutoSize = true;
            this.chkbx_MatchCase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_MatchCase.Location = new System.Drawing.Point(9, 116);
            this.chkbx_MatchCase.Name = "chkbx_MatchCase";
            this.chkbx_MatchCase.Size = new System.Drawing.Size(86, 19);
            this.chkbx_MatchCase.TabIndex = 4;
            this.chkbx_MatchCase.Text = "Match case";
            this.chkbx_MatchCase.UseVisualStyleBackColor = true;
            this.chkbx_MatchCase.CheckedChanged += new System.EventHandler(this.chkbx_MatchCase_CheckedChanged);
            // 
            // btn_FindPrevious
            // 
            this.btn_FindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FindPrevious.Enabled = false;
            this.btn_FindPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_FindPrevious.Location = new System.Drawing.Point(457, 47);
            this.btn_FindPrevious.Name = "btn_FindPrevious";
            this.btn_FindPrevious.Size = new System.Drawing.Size(94, 25);
            this.btn_FindPrevious.TabIndex = 3;
            this.btn_FindPrevious.Text = "Find Previous";
            this.btn_FindPrevious.UseVisualStyleBackColor = true;
            this.btn_FindPrevious.Click += new System.EventHandler(this.btn_FindPrevious_Click);
            // 
            // btn_FindNext
            // 
            this.btn_FindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FindNext.Enabled = false;
            this.btn_FindNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_FindNext.Location = new System.Drawing.Point(457, 17);
            this.btn_FindNext.Name = "btn_FindNext";
            this.btn_FindNext.Size = new System.Drawing.Size(94, 25);
            this.btn_FindNext.TabIndex = 2;
            this.btn_FindNext.Text = "Find Next";
            this.btn_FindNext.UseVisualStyleBackColor = true;
            this.btn_FindNext.Click += new System.EventHandler(this.btn_FindNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find What:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.elementHost3);
            this.tabPage2.Controls.Add(this.elementHost2);
            this.tabPage2.Controls.Add(this.lnklbl_UndoReplacements);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.chkbx_matchCaseRep);
            this.tabPage2.Controls.Add(this.lnklbl_ClearReplaceHistory);
            this.tabPage2.Controls.Add(this.LinkLabel2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btn_ReplaceAll);
            this.tabPage2.Controls.Add(this.btn_Replace);
            this.tabPage2.Controls.Add(this.btn_FindNextRep);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 221);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Replace";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(87, 64);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(364, 22);
            this.elementHost3.TabIndex = 36;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.combobox3;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(87, 18);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(364, 22);
            this.elementHost2.TabIndex = 35;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.combobox2;
            // 
            // lnklbl_UndoReplacements
            // 
            this.lnklbl_UndoReplacements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklbl_UndoReplacements.AutoSize = true;
            this.lnklbl_UndoReplacements.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnklbl_UndoReplacements.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnklbl_UndoReplacements.Location = new System.Drawing.Point(441, 121);
            this.lnklbl_UndoReplacements.Name = "lnklbl_UndoReplacements";
            this.lnklbl_UndoReplacements.Size = new System.Drawing.Size(113, 15);
            this.lnklbl_UndoReplacements.TabIndex = 29;
            this.lnklbl_UndoReplacements.TabStop = true;
            this.lnklbl_UndoReplacements.Text = "Undo Replacements";
            this.lnklbl_UndoReplacements.Visible = false;
            this.lnklbl_UndoReplacements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_UndoReplacements_LinkClicked);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(470, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 28;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // chkbx_matchCaseRep
            // 
            this.chkbx_matchCaseRep.AutoSize = true;
            this.chkbx_matchCaseRep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_matchCaseRep.Location = new System.Drawing.Point(9, 116);
            this.chkbx_matchCaseRep.Name = "chkbx_matchCaseRep";
            this.chkbx_matchCaseRep.Size = new System.Drawing.Size(86, 19);
            this.chkbx_matchCaseRep.TabIndex = 27;
            this.chkbx_matchCaseRep.Text = "Match case";
            this.chkbx_matchCaseRep.UseVisualStyleBackColor = true;
            this.chkbx_matchCaseRep.CheckedChanged += new System.EventHandler(this.chkbx_matchCaseRep_CheckedChanged);
            // 
            // lnklbl_ClearReplaceHistory
            // 
            this.lnklbl_ClearReplaceHistory.AutoSize = true;
            this.lnklbl_ClearReplaceHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnklbl_ClearReplaceHistory.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnklbl_ClearReplaceHistory.Location = new System.Drawing.Point(84, 89);
            this.lnklbl_ClearReplaceHistory.Name = "lnklbl_ClearReplaceHistory";
            this.lnklbl_ClearReplaceHistory.Size = new System.Drawing.Size(119, 15);
            this.lnklbl_ClearReplaceHistory.TabIndex = 25;
            this.lnklbl_ClearReplaceHistory.TabStop = true;
            this.lnklbl_ClearReplaceHistory.Text = "Clear Replace History";
            this.lnklbl_ClearReplaceHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_ClearReplaceHistory_LinkClicked);
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LinkLabel2.Location = new System.Drawing.Point(84, 42);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(113, 15);
            this.LinkLabel2.TabIndex = 24;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "Clear Search History";
            this.LinkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbl_ClearSearchHistory_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Replace with:";
            // 
            // btn_ReplaceAll
            // 
            this.btn_ReplaceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ReplaceAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ReplaceAll.Location = new System.Drawing.Point(457, 92);
            this.btn_ReplaceAll.Name = "btn_ReplaceAll";
            this.btn_ReplaceAll.Size = new System.Drawing.Size(94, 25);
            this.btn_ReplaceAll.TabIndex = 22;
            this.btn_ReplaceAll.Text = "Replace All";
            this.btn_ReplaceAll.UseVisualStyleBackColor = true;
            this.btn_ReplaceAll.Click += new System.EventHandler(this.btn_ReplaceAll_Click);
            // 
            // btn_Replace
            // 
            this.btn_Replace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Replace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Replace.Location = new System.Drawing.Point(457, 63);
            this.btn_Replace.Name = "btn_Replace";
            this.btn_Replace.Size = new System.Drawing.Size(94, 25);
            this.btn_Replace.TabIndex = 21;
            this.btn_Replace.Text = "Replace";
            this.btn_Replace.UseVisualStyleBackColor = true;
            this.btn_Replace.Click += new System.EventHandler(this.btn_Replace_Click);
            // 
            // btn_FindNextRep
            // 
            this.btn_FindNextRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FindNextRep.Enabled = false;
            this.btn_FindNextRep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_FindNextRep.Location = new System.Drawing.Point(457, 17);
            this.btn_FindNextRep.Name = "btn_FindNextRep";
            this.btn_FindNextRep.Size = new System.Drawing.Size(94, 25);
            this.btn_FindNextRep.TabIndex = 7;
            this.btn_FindNextRep.Text = "Find Next";
            this.btn_FindNextRep.UseVisualStyleBackColor = true;
            this.btn_FindNextRep.Click += new System.EventHandler(this.btn_FindNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Find What:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_Cancel);
            this.tabPage3.Controls.Add(this.lbl_LineCountTotal);
            this.tabPage3.Controls.Add(this.Label4);
            this.tabPage3.Controls.Add(this.txtbx_GoTo);
            this.tabPage3.Controls.Add(this.btn_GoTo);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(566, 221);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Go To";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Location = new System.Drawing.Point(470, 185);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 25);
            this.btn_Cancel.TabIndex = 22;
            this.btn_Cancel.Text = "Close";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_LineCountTotal
            // 
            this.lbl_LineCountTotal.AutoSize = true;
            this.lbl_LineCountTotal.Location = new System.Drawing.Point(6, 43);
            this.lbl_LineCountTotal.Name = "lbl_LineCountTotal";
            this.lbl_LineCountTotal.Size = new System.Drawing.Size(261, 15);
            this.lbl_LineCountTotal.TabIndex = 21;
            this.lbl_LineCountTotal.Text = "The current document contains {0} lines in total.";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(6, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(79, 15);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "Line Number:";
            // 
            // txtbx_GoTo
            // 
            this.txtbx_GoTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_GoTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_GoTo.Location = new System.Drawing.Point(87, 18);
            this.txtbx_GoTo.Name = "txtbx_GoTo";
            this.txtbx_GoTo.Size = new System.Drawing.Size(364, 23);
            this.txtbx_GoTo.TabIndex = 18;
            this.txtbx_GoTo.TextChanged += new System.EventHandler(this.txtbx_GoTo_TextChanged);
            this.txtbx_GoTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_GoTo_KeyPress);
            // 
            // btn_GoTo
            // 
            this.btn_GoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GoTo.Enabled = false;
            this.btn_GoTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GoTo.Location = new System.Drawing.Point(457, 17);
            this.btn_GoTo.Name = "btn_GoTo";
            this.btn_GoTo.Size = new System.Drawing.Size(94, 25);
            this.btn_GoTo.TabIndex = 19;
            this.btn_GoTo.Text = "Go To";
            this.btn_GoTo.UseVisualStyleBackColor = true;
            this.btn_GoTo.Click += new System.EventHandler(this.btn_GoTo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_searchStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 249);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(574, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_searchStatus
            // 
            this.lbl_searchStatus.Name = "lbl_searchStatus";
            this.lbl_searchStatus.Size = new System.Drawing.Size(0, 17);
            this.lbl_searchStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totp_OnlyNumbers
            // 
            this.totp_OnlyNumbers.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.totp_OnlyNumbers.ToolTipTitle = "Numbers Only";
            // 
            // tmr_RefreshStatus
            // 
            this.tmr_RefreshStatus.Interval = 2500;
            this.tmr_RefreshStatus.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmr_CheckFocus
            // 
            this.tmr_CheckFocus.Interval = 1;
            this.tmr_CheckFocus.Tick += new System.EventHandler(this.tmr_CheckFocus_Tick);
            // 
            // frm_FindReplace
            // 
            this.AcceptButton = this.btn_FindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(574, 271);
            this.Controls.Add(this.tab_SearchRepGo);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_FindReplace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search and Replace";
            this.Activated += new System.EventHandler(this.frm_FindReplace_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FindReplace_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_FindReplace_FormClosed);
            this.tab_SearchRepGo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab_SearchRepGo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_FindPrevious;
        private System.Windows.Forms.Button btn_FindNext;
        private System.Windows.Forms.CheckBox chkbx_MatchCase;
        private System.Windows.Forms.LinkLabel lnklbl_ClearSearchHistory;
        internal System.Windows.Forms.LinkLabel lnklbl_ClearReplaceHistory;
        internal System.Windows.Forms.LinkLabel LinkLabel2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btn_ReplaceAll;
        internal System.Windows.Forms.Button btn_Replace;
        private System.Windows.Forms.Button btn_FindNextRep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbx_matchCaseRep;
        internal System.Windows.Forms.Label lbl_LineCountTotal;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtbx_GoTo;
        internal System.Windows.Forms.Button btn_GoTo;
        internal System.Windows.Forms.Button btn_Close;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button btn_Cancel;
        internal System.Windows.Forms.ToolTip totp_OnlyNumbers;
        private System.Windows.Forms.ToolStripStatusLabel lbl_searchStatus;
        private System.Windows.Forms.Timer tmr_RefreshStatus;
        internal System.Windows.Forms.LinkLabel lnklbl_UndoReplacements;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Combobox combobox1;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private Combobox combobox2;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private Combobox combobox3;
        private System.Windows.Forms.Timer tmr_CheckFocus;
    }
}