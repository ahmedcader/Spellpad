namespace Spellpad.Forms.Spellpad_Forms
{
    partial class frm_Settings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Editor");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Recents List");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Appearance");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Global Dictionary");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Custom Dictionaries");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Backup Options");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Context Menu");
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Default = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_Fonts = new System.Windows.Forms.ComboBox();
            this.cmb_Size = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkbx_LargeToolbar = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkbx_StatusBar = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pbcl_editorBackColor = new System.Windows.Forms.PictureBox();
            this.pbcl_selectionColor = new System.Windows.Forms.PictureBox();
            this.pbcl_editorForeColor = new System.Windows.Forms.PictureBox();
            this.chkbx_TextWrapping = new System.Windows.Forms.CheckBox();
            this.chkbx_QuickToolbar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbx_warnClearRecents = new System.Windows.Forms.CheckBox();
            this.btn_ClearRecents = new System.Windows.Forms.Button();
            this.btn_editRecentsList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.recentsCount = new System.Windows.Forms.NumericUpDown();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkbx_EnableSpellcheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SelectGlobalDic = new System.Windows.Forms.Button();
            this.btn_editGlobalDict = new System.Windows.Forms.Button();
            this.txtbx_GlobalDicLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.Label();
            this.btn_RenameDict = new System.Windows.Forms.Button();
            this.lstbx_customDictLocations = new System.Windows.Forms.CheckedListBox();
            this.btn_removeCusDictLoc = new System.Windows.Forms.Button();
            this.btn_editDict = new System.Windows.Forms.Button();
            this.btn_addCusDictLoc = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_ClearHistoryBack = new System.Windows.Forms.Button();
            this.Label14 = new System.Windows.Forms.Label();
            this.btn_CreateBackup = new System.Windows.Forms.Button();
            this.btn_RestoreBackup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtbx_BackupSaveDir = new System.Windows.Forms.TextBox();
            this.lstbx_BackupHistory = new System.Windows.Forms.ListBox();
            this.btn_ChooseDir = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chkbxDisableContextMenu = new System.Windows.Forms.CheckBox();
            this.lblAdminNeed = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_editorBackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_selectionColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_editorForeColor)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentsCount)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.03226F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.96774F));
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.79781F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(533, 358);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.Indent = 5;
            this.treeView1.ItemHeight = 35;
            this.treeView1.LineColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Editor";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Recents List";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Appearance";
            treeNode4.Name = "Node6";
            treeNode4.Text = "Global Dictionary";
            treeNode5.Name = "Node7";
            treeNode5.Text = "Custom Dictionaries";
            treeNode6.Name = "Node9";
            treeNode6.Text = "Backup Options";
            treeNode7.Name = "Node1";
            treeNode7.Text = "Context Menu";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(148, 352);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(154, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(379, 358);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.btn_Apply, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Default, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 331);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(379, 27);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btn_Apply
            // 
            this.btn_Apply.AutoSize = true;
            this.btn_Apply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Apply.Enabled = false;
            this.btn_Apply.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Apply.Location = new System.Drawing.Point(252, 0);
            this.btn_Apply.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(127, 25);
            this.btn_Apply.TabIndex = 37;
            this.btn_Apply.Text = "Apply Changes";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.AutoSize = true;
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Save.Enabled = false;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Save.Location = new System.Drawing.Point(126, 0);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(126, 25);
            this.btn_Save.TabIndex = 38;
            this.btn_Save.Text = "Save Changes";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Default
            // 
            this.btn_Default.AutoSize = true;
            this.btn_Default.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Default.Enabled = false;
            this.btn_Default.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Default.Location = new System.Drawing.Point(0, 0);
            this.btn_Default.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(126, 25);
            this.btn_Default.TabIndex = 36;
            this.btn_Default.Text = "Restore Defaults";
            this.btn_Default.UseVisualStyleBackColor = true;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(379, 331);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmb_Fonts);
            this.panel1.Controls.Add(this.cmb_Size);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 82);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Default Font:";
            // 
            // cmb_Fonts
            // 
            this.cmb_Fonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Fonts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Fonts.FormattingEnabled = true;
            this.cmb_Fonts.Location = new System.Drawing.Point(7, 17);
            this.cmb_Fonts.Margin = new System.Windows.Forms.Padding(0);
            this.cmb_Fonts.Name = "cmb_Fonts";
            this.cmb_Fonts.Size = new System.Drawing.Size(360, 23);
            this.cmb_Fonts.TabIndex = 31;
            this.cmb_Fonts.SelectionChangeCommitted += new System.EventHandler(this.cmb_Fonts_SelectionChangeCommitted);
            // 
            // cmb_Size
            // 
            this.cmb_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Size.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Size.FormattingEnabled = true;
            this.cmb_Size.Location = new System.Drawing.Point(7, 59);
            this.cmb_Size.Margin = new System.Windows.Forms.Padding(0);
            this.cmb_Size.Name = "cmb_Size";
            this.cmb_Size.Size = new System.Drawing.Size(360, 23);
            this.cmb_Size.TabIndex = 33;
            this.cmb_Size.SelectionChangeCommitted += new System.EventHandler(this.cmb_Size_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(4, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Default Font Size:";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.chkbx_LargeToolbar);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chkbx_StatusBar);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.pbcl_editorBackColor);
            this.panel2.Controls.Add(this.pbcl_selectionColor);
            this.panel2.Controls.Add(this.pbcl_editorForeColor);
            this.panel2.Controls.Add(this.chkbx_TextWrapping);
            this.panel2.Controls.Add(this.chkbx_QuickToolbar);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 225);
            this.panel2.TabIndex = 35;
            this.panel2.Visible = false;
            // 
            // chkbx_LargeToolbar
            // 
            this.chkbx_LargeToolbar.AutoSize = true;
            this.chkbx_LargeToolbar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_LargeToolbar.Location = new System.Drawing.Point(7, 203);
            this.chkbx_LargeToolbar.Name = "chkbx_LargeToolbar";
            this.chkbx_LargeToolbar.Size = new System.Drawing.Size(98, 19);
            this.chkbx_LargeToolbar.TabIndex = 45;
            this.chkbx_LargeToolbar.Text = "Large Toolbar";
            this.chkbx_LargeToolbar.UseVisualStyleBackColor = true;
            this.chkbx_LargeToolbar.Click += new System.EventHandler(this.chkbx_LargeToolbar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(3, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "Background Color";
            // 
            // chkbx_StatusBar
            // 
            this.chkbx_StatusBar.AutoSize = true;
            this.chkbx_StatusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_StatusBar.Location = new System.Drawing.Point(7, 180);
            this.chkbx_StatusBar.Name = "chkbx_StatusBar";
            this.chkbx_StatusBar.Size = new System.Drawing.Size(78, 19);
            this.chkbx_StatusBar.TabIndex = 42;
            this.chkbx_StatusBar.Text = "Status Bar";
            this.chkbx_StatusBar.UseVisualStyleBackColor = true;
            this.chkbx_StatusBar.Click += new System.EventHandler(this.chkbx_StatusBar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(3, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 15);
            this.label9.TabIndex = 43;
            this.label9.Text = "Foreground Color";
            // 
            // pbcl_editorBackColor
            // 
            this.pbcl_editorBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbcl_editorBackColor.Location = new System.Drawing.Point(7, 19);
            this.pbcl_editorBackColor.Name = "pbcl_editorBackColor";
            this.pbcl_editorBackColor.Size = new System.Drawing.Size(28, 22);
            this.pbcl_editorBackColor.TabIndex = 41;
            this.pbcl_editorBackColor.TabStop = false;
            this.pbcl_editorBackColor.Click += new System.EventHandler(this.pbcl_editorBackColor_Click);
            // 
            // pbcl_selectionColor
            // 
            this.pbcl_selectionColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbcl_selectionColor.Location = new System.Drawing.Point(7, 105);
            this.pbcl_selectionColor.Name = "pbcl_selectionColor";
            this.pbcl_selectionColor.Size = new System.Drawing.Size(28, 22);
            this.pbcl_selectionColor.TabIndex = 37;
            this.pbcl_selectionColor.TabStop = false;
            this.pbcl_selectionColor.Click += new System.EventHandler(this.pbcl_selectionColor_Click);
            // 
            // pbcl_editorForeColor
            // 
            this.pbcl_editorForeColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbcl_editorForeColor.Location = new System.Drawing.Point(7, 62);
            this.pbcl_editorForeColor.Name = "pbcl_editorForeColor";
            this.pbcl_editorForeColor.Size = new System.Drawing.Size(28, 22);
            this.pbcl_editorForeColor.TabIndex = 44;
            this.pbcl_editorForeColor.TabStop = false;
            this.pbcl_editorForeColor.Click += new System.EventHandler(this.pbcl_editorForeColor_Click);
            // 
            // chkbx_TextWrapping
            // 
            this.chkbx_TextWrapping.AutoSize = true;
            this.chkbx_TextWrapping.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_TextWrapping.Location = new System.Drawing.Point(7, 157);
            this.chkbx_TextWrapping.Name = "chkbx_TextWrapping";
            this.chkbx_TextWrapping.Size = new System.Drawing.Size(86, 19);
            this.chkbx_TextWrapping.TabIndex = 39;
            this.chkbx_TextWrapping.Text = "Word Wrap";
            this.chkbx_TextWrapping.UseVisualStyleBackColor = true;
            this.chkbx_TextWrapping.Click += new System.EventHandler(this.chkbx_TextWrapping_Click);
            // 
            // chkbx_QuickToolbar
            // 
            this.chkbx_QuickToolbar.AutoSize = true;
            this.chkbx_QuickToolbar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_QuickToolbar.Location = new System.Drawing.Point(7, 134);
            this.chkbx_QuickToolbar.Name = "chkbx_QuickToolbar";
            this.chkbx_QuickToolbar.Size = new System.Drawing.Size(100, 19);
            this.chkbx_QuickToolbar.TabIndex = 40;
            this.chkbx_QuickToolbar.Text = "Quick Toolbar";
            this.chkbx_QuickToolbar.UseVisualStyleBackColor = true;
            this.chkbx_QuickToolbar.Click += new System.EventHandler(this.chkbx_QuickToolbar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(3, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Text Selection Color";
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.chkbx_warnClearRecents);
            this.panel3.Controls.Add(this.btn_ClearRecents);
            this.panel3.Controls.Add(this.btn_editRecentsList);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.recentsCount);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 307);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 160);
            this.panel3.TabIndex = 35;
            this.panel3.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(4, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(183, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = "Edit all Recents from Recents List:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 15);
            this.label2.TabIndex = 42;
            this.label2.Text = "Clear all Recents from Recents List:";
            // 
            // chkbx_warnClearRecents
            // 
            this.chkbx_warnClearRecents.AutoSize = true;
            this.chkbx_warnClearRecents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkbx_warnClearRecents.Location = new System.Drawing.Point(7, 138);
            this.chkbx_warnClearRecents.Name = "chkbx_warnClearRecents";
            this.chkbx_warnClearRecents.Size = new System.Drawing.Size(201, 19);
            this.chkbx_warnClearRecents.TabIndex = 41;
            this.chkbx_warnClearRecents.Text = "Warn before clearing Recent Files";
            this.chkbx_warnClearRecents.UseVisualStyleBackColor = true;
            this.chkbx_warnClearRecents.Click += new System.EventHandler(this.chkbx_warnClearRecents_Click);
            // 
            // btn_ClearRecents
            // 
            this.btn_ClearRecents.Enabled = false;
            this.btn_ClearRecents.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ClearRecents.Location = new System.Drawing.Point(7, 17);
            this.btn_ClearRecents.Name = "btn_ClearRecents";
            this.btn_ClearRecents.Size = new System.Drawing.Size(80, 24);
            this.btn_ClearRecents.TabIndex = 37;
            this.btn_ClearRecents.Text = "Clear";
            this.btn_ClearRecents.UseVisualStyleBackColor = true;
            this.btn_ClearRecents.Click += new System.EventHandler(this.btn_ClearRecents_Click);
            // 
            // btn_editRecentsList
            // 
            this.btn_editRecentsList.Enabled = false;
            this.btn_editRecentsList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_editRecentsList.Location = new System.Drawing.Point(7, 63);
            this.btn_editRecentsList.Name = "btn_editRecentsList";
            this.btn_editRecentsList.Size = new System.Drawing.Size(80, 24);
            this.btn_editRecentsList.TabIndex = 40;
            this.btn_editRecentsList.Text = "Edit";
            this.btn_editRecentsList.UseVisualStyleBackColor = true;
            this.btn_editRecentsList.Click += new System.EventHandler(this.btn_editRecentsList_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(4, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "Number of Recent Files to Store:";
            // 
            // recentsCount
            // 
            this.recentsCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentsCount.Location = new System.Drawing.Point(7, 108);
            this.recentsCount.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.recentsCount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentsCount.Name = "recentsCount";
            this.recentsCount.Size = new System.Drawing.Size(75, 22);
            this.recentsCount.TabIndex = 38;
            this.recentsCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.recentsCount.ValueChanged += new System.EventHandler(this.recentsCount_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.chkbx_EnableSpellcheck);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btn_SelectGlobalDic);
            this.panel4.Controls.Add(this.btn_editGlobalDict);
            this.panel4.Controls.Add(this.txtbx_GlobalDicLocation);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 467);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(374, 147);
            this.panel4.TabIndex = 42;
            this.panel4.Visible = false;
            // 
            // chkbx_EnableSpellcheck
            // 
            this.chkbx_EnableSpellcheck.AutoSize = true;
            this.chkbx_EnableSpellcheck.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbx_EnableSpellcheck.Location = new System.Drawing.Point(8, 125);
            this.chkbx_EnableSpellcheck.Name = "chkbx_EnableSpellcheck";
            this.chkbx_EnableSpellcheck.Size = new System.Drawing.Size(130, 19);
            this.chkbx_EnableSpellcheck.TabIndex = 22;
            this.chkbx_EnableSpellcheck.Text = "Enable Spellchecker";
            this.chkbx_EnableSpellcheck.UseVisualStyleBackColor = true;
            this.chkbx_EnableSpellcheck.Click += new System.EventHandler(this.chkbx_EnableSpellcheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(4, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Global Dictionary Location:";
            // 
            // btn_SelectGlobalDic
            // 
            this.btn_SelectGlobalDic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_SelectGlobalDic.Location = new System.Drawing.Point(330, 16);
            this.btn_SelectGlobalDic.Name = "btn_SelectGlobalDic";
            this.btn_SelectGlobalDic.Size = new System.Drawing.Size(35, 24);
            this.btn_SelectGlobalDic.TabIndex = 19;
            this.btn_SelectGlobalDic.Text = "...";
            this.btn_SelectGlobalDic.UseVisualStyleBackColor = true;
            this.btn_SelectGlobalDic.Click += new System.EventHandler(this.btn_SelectGlobalDic_Click);
            // 
            // btn_editGlobalDict
            // 
            this.btn_editGlobalDict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_editGlobalDict.Location = new System.Drawing.Point(7, 95);
            this.btn_editGlobalDict.Name = "btn_editGlobalDict";
            this.btn_editGlobalDict.Size = new System.Drawing.Size(137, 24);
            this.btn_editGlobalDict.TabIndex = 20;
            this.btn_editGlobalDict.Text = "Edit Global Dictionary";
            this.btn_editGlobalDict.UseVisualStyleBackColor = true;
            this.btn_editGlobalDict.Click += new System.EventHandler(this.btn_editGlobalDict_Click);
            // 
            // txtbx_GlobalDicLocation
            // 
            this.txtbx_GlobalDicLocation.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtbx_GlobalDicLocation.Location = new System.Drawing.Point(7, 17);
            this.txtbx_GlobalDicLocation.Name = "txtbx_GlobalDicLocation";
            this.txtbx_GlobalDicLocation.ReadOnly = true;
            this.txtbx_GlobalDicLocation.Size = new System.Drawing.Size(316, 22);
            this.txtbx_GlobalDicLocation.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(4, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 46);
            this.label4.TabIndex = 21;
            this.label4.Text = "The Global Dictionary may contain words from other added dictionaries. The global" +
    " dictionary acts as a unified dictionary when using multiple custom dictionaries" +
    ".";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Controls.Add(this.btn_RenameDict);
            this.panel5.Controls.Add(this.lstbx_customDictLocations);
            this.panel5.Controls.Add(this.btn_removeCusDictLoc);
            this.panel5.Controls.Add(this.btn_editDict);
            this.panel5.Controls.Add(this.btn_addCusDictLoc);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 614);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(374, 136);
            this.panel5.TabIndex = 43;
            this.panel5.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(4, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 15);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.Text = "Custom Dictionary";
            // 
            // btn_RenameDict
            // 
            this.btn_RenameDict.Enabled = false;
            this.btn_RenameDict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_RenameDict.Location = new System.Drawing.Point(294, 109);
            this.btn_RenameDict.Name = "btn_RenameDict";
            this.btn_RenameDict.Size = new System.Drawing.Size(76, 24);
            this.btn_RenameDict.TabIndex = 22;
            this.btn_RenameDict.Text = "Rename";
            this.btn_RenameDict.UseVisualStyleBackColor = true;
            this.btn_RenameDict.Click += new System.EventHandler(this.btn_RenameDict_Click);
            // 
            // lstbx_customDictLocations
            // 
            this.lstbx_customDictLocations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstbx_customDictLocations.FormattingEnabled = true;
            this.lstbx_customDictLocations.IntegralHeight = false;
            this.lstbx_customDictLocations.Location = new System.Drawing.Point(7, 21);
            this.lstbx_customDictLocations.Name = "lstbx_customDictLocations";
            this.lstbx_customDictLocations.Size = new System.Drawing.Size(281, 112);
            this.lstbx_customDictLocations.TabIndex = 21;
            this.lstbx_customDictLocations.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstbx_customDictLocations_ItemCheck);
            this.lstbx_customDictLocations.SelectedIndexChanged += new System.EventHandler(this.lstbx_customDictLocations_SelectedIndexChanged);
            // 
            // btn_removeCusDictLoc
            // 
            this.btn_removeCusDictLoc.Enabled = false;
            this.btn_removeCusDictLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_removeCusDictLoc.Location = new System.Drawing.Point(294, 79);
            this.btn_removeCusDictLoc.Name = "btn_removeCusDictLoc";
            this.btn_removeCusDictLoc.Size = new System.Drawing.Size(76, 24);
            this.btn_removeCusDictLoc.TabIndex = 19;
            this.btn_removeCusDictLoc.Text = "Remove";
            this.btn_removeCusDictLoc.UseVisualStyleBackColor = true;
            this.btn_removeCusDictLoc.Click += new System.EventHandler(this.btn_removeCusDictLoc_Click);
            // 
            // btn_editDict
            // 
            this.btn_editDict.Enabled = false;
            this.btn_editDict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_editDict.Location = new System.Drawing.Point(294, 49);
            this.btn_editDict.Name = "btn_editDict";
            this.btn_editDict.Size = new System.Drawing.Size(76, 24);
            this.btn_editDict.TabIndex = 20;
            this.btn_editDict.Text = "Edit";
            this.btn_editDict.UseVisualStyleBackColor = true;
            this.btn_editDict.Click += new System.EventHandler(this.btn_editDict_Click);
            // 
            // btn_addCusDictLoc
            // 
            this.btn_addCusDictLoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_addCusDictLoc.Location = new System.Drawing.Point(294, 19);
            this.btn_addCusDictLoc.Name = "btn_addCusDictLoc";
            this.btn_addCusDictLoc.Size = new System.Drawing.Size(76, 24);
            this.btn_addCusDictLoc.TabIndex = 18;
            this.btn_addCusDictLoc.Text = "Add";
            this.btn_addCusDictLoc.UseVisualStyleBackColor = true;
            this.btn_addCusDictLoc.Click += new System.EventHandler(this.btn_addCusDictLoc_Click);
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel6.Controls.Add(this.btn_ClearHistoryBack);
            this.panel6.Controls.Add(this.Label14);
            this.panel6.Controls.Add(this.btn_CreateBackup);
            this.panel6.Controls.Add(this.btn_RestoreBackup);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txtbx_BackupSaveDir);
            this.panel6.Controls.Add(this.lstbx_BackupHistory);
            this.panel6.Controls.Add(this.btn_ChooseDir);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 750);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(374, 198);
            this.panel6.TabIndex = 44;
            this.panel6.Visible = false;
            // 
            // btn_ClearHistoryBack
            // 
            this.btn_ClearHistoryBack.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearHistoryBack.Location = new System.Drawing.Point(283, 172);
            this.btn_ClearHistoryBack.Name = "btn_ClearHistoryBack";
            this.btn_ClearHistoryBack.Size = new System.Drawing.Size(87, 23);
            this.btn_ClearHistoryBack.TabIndex = 53;
            this.btn_ClearHistoryBack.Text = "Clear List";
            this.btn_ClearHistoryBack.UseVisualStyleBackColor = true;
            this.btn_ClearHistoryBack.Click += new System.EventHandler(this.btn_ClearHistoryBack_Click);
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Label14.Location = new System.Drawing.Point(4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(367, 37);
            this.Label14.TabIndex = 52;
            this.Label14.Text = "Make a backup of all the settings and dictionaries. Easily restore them later fro" +
    "m the backup file you created.";
            // 
            // btn_CreateBackup
            // 
            this.btn_CreateBackup.Enabled = false;
            this.btn_CreateBackup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CreateBackup.Location = new System.Drawing.Point(103, 172);
            this.btn_CreateBackup.Name = "btn_CreateBackup";
            this.btn_CreateBackup.Size = new System.Drawing.Size(87, 23);
            this.btn_CreateBackup.TabIndex = 48;
            this.btn_CreateBackup.Text = "Create";
            this.btn_CreateBackup.UseVisualStyleBackColor = true;
            this.btn_CreateBackup.Click += new System.EventHandler(this.btn_CreateBackup_Click);
            // 
            // btn_RestoreBackup
            // 
            this.btn_RestoreBackup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RestoreBackup.Location = new System.Drawing.Point(6, 172);
            this.btn_RestoreBackup.Name = "btn_RestoreBackup";
            this.btn_RestoreBackup.Size = new System.Drawing.Size(87, 23);
            this.btn_RestoreBackup.TabIndex = 51;
            this.btn_RestoreBackup.Text = "Restore";
            this.btn_RestoreBackup.UseVisualStyleBackColor = true;
            this.btn_RestoreBackup.Click += new System.EventHandler(this.btn_RestoreBackup_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(4, 37);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 15);
            this.label10.TabIndex = 45;
            this.label10.Text = "Backup Save Location:";
            // 
            // txtbx_BackupSaveDir
            // 
            this.txtbx_BackupSaveDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_BackupSaveDir.Location = new System.Drawing.Point(7, 54);
            this.txtbx_BackupSaveDir.Margin = new System.Windows.Forms.Padding(2);
            this.txtbx_BackupSaveDir.Name = "txtbx_BackupSaveDir";
            this.txtbx_BackupSaveDir.Size = new System.Drawing.Size(329, 22);
            this.txtbx_BackupSaveDir.TabIndex = 46;
            this.txtbx_BackupSaveDir.TextChanged += new System.EventHandler(this.txtbx_BackupSaveDir_TextChanged);
            // 
            // lstbx_BackupHistory
            // 
            this.lstbx_BackupHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbx_BackupHistory.FormattingEnabled = true;
            this.lstbx_BackupHistory.Location = new System.Drawing.Point(7, 97);
            this.lstbx_BackupHistory.Name = "lstbx_BackupHistory";
            this.lstbx_BackupHistory.Size = new System.Drawing.Size(359, 69);
            this.lstbx_BackupHistory.TabIndex = 49;
            // 
            // btn_ChooseDir
            // 
            this.btn_ChooseDir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChooseDir.Location = new System.Drawing.Point(343, 53);
            this.btn_ChooseDir.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ChooseDir.Name = "btn_ChooseDir";
            this.btn_ChooseDir.Size = new System.Drawing.Size(26, 24);
            this.btn_ChooseDir.TabIndex = 47;
            this.btn_ChooseDir.Text = "...";
            this.btn_ChooseDir.UseVisualStyleBackColor = true;
            this.btn_ChooseDir.Click += new System.EventHandler(this.btn_ChooseDir_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location = new System.Drawing.Point(4, 79);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 15);
            this.label11.TabIndex = 50;
            this.label11.Text = "Backup History";
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.chkbxDisableContextMenu);
            this.panel7.Controls.Add(this.lblAdminNeed);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 948);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(374, 24);
            this.panel7.TabIndex = 45;
            this.panel7.Visible = false;
            // 
            // chkbxDisableContextMenu
            // 
            this.chkbxDisableContextMenu.AutoSize = true;
            this.chkbxDisableContextMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxDisableContextMenu.Location = new System.Drawing.Point(3, 2);
            this.chkbxDisableContextMenu.Name = "chkbxDisableContextMenu";
            this.chkbxDisableContextMenu.Size = new System.Drawing.Size(232, 19);
            this.chkbxDisableContextMenu.TabIndex = 54;
            this.chkbxDisableContextMenu.Text = "\'Edit with Spellpad\' context menu entry";
            this.chkbxDisableContextMenu.UseVisualStyleBackColor = true;
            this.chkbxDisableContextMenu.CheckedChanged += new System.EventHandler(this.chkbxDisableContextMenu_CheckedChanged);
            this.chkbxDisableContextMenu.Click += new System.EventHandler(this.chkbxDisableContextMenu_Click);
            // 
            // lblAdminNeed
            // 
            this.lblAdminNeed.AutoSize = true;
            this.lblAdminNeed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAdminNeed.Location = new System.Drawing.Point(0, 3);
            this.lblAdminNeed.Name = "lblAdminNeed";
            this.lblAdminNeed.Size = new System.Drawing.Size(279, 15);
            this.lblAdminNeed.TabIndex = 52;
            this.lblAdminNeed.Text = "Run Spellpad as Administrator to make this change.";
            // 
            // frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(557, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Settings_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_editorBackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_selectionColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcl_editorForeColor)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recentsCount)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmb_Fonts;
        internal System.Windows.Forms.ComboBox cmb_Size;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkbx_LargeToolbar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkbx_StatusBar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbcl_editorBackColor;
        private System.Windows.Forms.PictureBox pbcl_selectionColor;
        private System.Windows.Forms.PictureBox pbcl_editorForeColor;
        private System.Windows.Forms.CheckBox chkbx_TextWrapping;
        private System.Windows.Forms.CheckBox chkbx_QuickToolbar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkbx_warnClearRecents;
        private System.Windows.Forms.Button btn_ClearRecents;
        private System.Windows.Forms.Button btn_editRecentsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown recentsCount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox chkbx_EnableSpellcheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SelectGlobalDic;
        private System.Windows.Forms.Button btn_editGlobalDict;
        private System.Windows.Forms.TextBox txtbx_GlobalDicLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_RenameDict;
        private System.Windows.Forms.CheckedListBox lstbx_customDictLocations;
        private System.Windows.Forms.Button btn_removeCusDictLoc;
        private System.Windows.Forms.Button btn_editDict;
        private System.Windows.Forms.Button btn_addCusDictLoc;
        private System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Button btn_ClearHistoryBack;
        internal System.Windows.Forms.Button btn_CreateBackup;
        internal System.Windows.Forms.Button btn_RestoreBackup;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox txtbx_BackupSaveDir;
        internal System.Windows.Forms.ListBox lstbx_BackupHistory;
        internal System.Windows.Forms.Button btn_ChooseDir;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.Label lblAdminNeed;
        private System.Windows.Forms.CheckBox chkbxDisableContextMenu;
    }
}