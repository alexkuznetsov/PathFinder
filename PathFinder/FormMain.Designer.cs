namespace PathFinder
{
    partial class FormMain
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
			this.btRun = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbFrom = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbTo = new System.Windows.Forms.ComboBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btRun
			// 
			this.btRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btRun.Location = new System.Drawing.Point(414, 293);
			this.btRun.Name = "btRun";
			this.btRun.Size = new System.Drawing.Size(75, 23);
			this.btRun.TabIndex = 0;
			this.btRun.Text = "Start";
			this.btRun.UseVisualStyleBackColor = true;
			this.btRun.Click += new System.EventHandler(this.btRun_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Из";
			// 
			// cmbFrom
			// 
			this.cmbFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbFrom.FormattingEnabled = true;
			this.cmbFrom.Location = new System.Drawing.Point(73, 6);
			this.cmbFrom.Name = "cmbFrom";
			this.cmbFrom.Size = new System.Drawing.Size(416, 21);
			this.cmbFrom.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(14, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "В";
			// 
			// cmbTo
			// 
			this.cmbTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTo.FormattingEnabled = true;
			this.cmbTo.Location = new System.Drawing.Point(73, 33);
			this.cmbTo.Name = "cmbTo";
			this.cmbTo.Size = new System.Drawing.Size(416, 21);
			this.cmbTo.TabIndex = 2;
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(15, 60);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(474, 227);
			this.txtLog.TabIndex = 3;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 328);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.cmbTo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbFrom);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btRun);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Path Finder";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.TextBox txtLog;
    }
}

