namespace Spellpad.Forms.Spellpad_Forms
{
    partial class frm_EditDictionary
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_addWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstbx_DictWords = new System.Windows.Forms.ListBox();
            this.btn_AddWord = new System.Windows.Forms.Button();
            this.btn_delWord = new System.Windows.Forms.Button();
            this.btn_DelAllWords = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Word(s):";
            // 
            // txtbx_addWord
            // 
            this.txtbx_addWord.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtbx_addWord.Location = new System.Drawing.Point(15, 25);
            this.txtbx_addWord.Name = "txtbx_addWord";
            this.txtbx_addWord.Size = new System.Drawing.Size(272, 22);
            this.txtbx_addWord.TabIndex = 8;
            this.txtbx_addWord.TextChanged += new System.EventHandler(this.txtbx_addWord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Word(s) List:";
            // 
            // lstbx_DictWords
            // 
            this.lstbx_DictWords.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lstbx_DictWords.FormattingEnabled = true;
            this.lstbx_DictWords.Location = new System.Drawing.Point(15, 85);
            this.lstbx_DictWords.Name = "lstbx_DictWords";
            this.lstbx_DictWords.Size = new System.Drawing.Size(272, 95);
            this.lstbx_DictWords.TabIndex = 10;
            this.lstbx_DictWords.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_AddWord
            // 
            this.btn_AddWord.AutoSize = true;
            this.btn_AddWord.Enabled = false;
            this.btn_AddWord.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_AddWord.Location = new System.Drawing.Point(14, 186);
            this.btn_AddWord.Name = "btn_AddWord";
            this.btn_AddWord.Size = new System.Drawing.Size(75, 25);
            this.btn_AddWord.TabIndex = 11;
            this.btn_AddWord.Text = "Add";
            this.btn_AddWord.UseVisualStyleBackColor = true;
            this.btn_AddWord.Click += new System.EventHandler(this.btn_AddWord_Click);
            // 
            // btn_delWord
            // 
            this.btn_delWord.AutoSize = true;
            this.btn_delWord.Enabled = false;
            this.btn_delWord.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_delWord.Location = new System.Drawing.Point(132, 186);
            this.btn_delWord.Name = "btn_delWord";
            this.btn_delWord.Size = new System.Drawing.Size(75, 25);
            this.btn_delWord.TabIndex = 12;
            this.btn_delWord.Text = "Delete";
            this.btn_delWord.UseVisualStyleBackColor = true;
            this.btn_delWord.Click += new System.EventHandler(this.btn_delWord_Click);
            // 
            // btn_DelAllWords
            // 
            this.btn_DelAllWords.AutoSize = true;
            this.btn_DelAllWords.Enabled = false;
            this.btn_DelAllWords.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_DelAllWords.Location = new System.Drawing.Point(213, 186);
            this.btn_DelAllWords.Name = "btn_DelAllWords";
            this.btn_DelAllWords.Size = new System.Drawing.Size(75, 25);
            this.btn_DelAllWords.TabIndex = 13;
            this.btn_DelAllWords.Text = "Delete All";
            this.btn_DelAllWords.UseVisualStyleBackColor = true;
            this.btn_DelAllWords.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.AutoSize = true;
            this.btn_OK.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_OK.Location = new System.Drawing.Point(183, 240);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(105, 25);
            this.btn_OK.TabIndex = 14;
            this.btn_OK.Text = "Save And Close";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_EditDictionary
            // 
            this.AcceptButton = this.btn_AddWord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(299, 277);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_DelAllWords);
            this.Controls.Add(this.btn_delWord);
            this.Controls.Add(this.btn_AddWord);
            this.Controls.Add(this.lstbx_DictWords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbx_addWord);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_EditDictionary";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_addWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstbx_DictWords;
        private System.Windows.Forms.Button btn_AddWord;
        private System.Windows.Forms.Button btn_delWord;
        private System.Windows.Forms.Button btn_DelAllWords;
        private System.Windows.Forms.Button btn_OK;
    }
}