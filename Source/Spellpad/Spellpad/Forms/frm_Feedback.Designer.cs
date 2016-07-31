namespace Spellpad
{
    partial class frm_Feedback
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
            this.txtbx_Feedback = new System.Windows.Forms.TextBox();
            this.btn_SendFeedback = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbx_Feedback
            // 
            this.txtbx_Feedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbx_Feedback.Location = new System.Drawing.Point(10, 0);
            this.txtbx_Feedback.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.txtbx_Feedback.Multiline = true;
            this.txtbx_Feedback.Name = "txtbx_Feedback";
            this.txtbx_Feedback.Size = new System.Drawing.Size(385, 240);
            this.txtbx_Feedback.TabIndex = 18;
            this.txtbx_Feedback.TextChanged += new System.EventHandler(this.txtbx_Feedback_TextChanged);
            // 
            // btn_SendFeedback
            // 
            this.btn_SendFeedback.AutoSize = true;
            this.btn_SendFeedback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SendFeedback.Location = new System.Drawing.Point(9, 245);
            this.btn_SendFeedback.Margin = new System.Windows.Forms.Padding(9, 5, 9, 3);
            this.btn_SendFeedback.Name = "btn_SendFeedback";
            this.btn_SendFeedback.Size = new System.Drawing.Size(387, 24);
            this.btn_SendFeedback.TabIndex = 19;
            this.btn_SendFeedback.Text = "Send";
            this.btn_SendFeedback.UseVisualStyleBackColor = true;
            this.btn_SendFeedback.Click += new System.EventHandler(this.btn_SendFeedback_Click);
            // 
            // Label3
            // 
            this.Label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label3.Location = new System.Drawing.Point(0, 0);
            this.Label3.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.Label3.Size = new System.Drawing.Size(405, 43);
            this.Label3.TabIndex = 17;
            this.Label3.Text = "Make sure your feedback is brief and gets to the point. It can be anything from g" +
    "eneral feedback to bugs.";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.btn_SendFeedback, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbx_Feedback, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(405, 272);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // frm_Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(405, 324);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(421, 363);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(421, 363);
            this.Name = "frm_Feedback";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feedback";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtbx_Feedback;
        private System.Windows.Forms.Button btn_SendFeedback;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}