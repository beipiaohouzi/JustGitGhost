namespace PureMVCAppDemo
{
    partial class FrmFileForeach
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbFiles = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.ckChildren = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbFiles);
            this.panel1.Location = new System.Drawing.Point(5, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 343);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckChildren);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.lblDir);
            this.panel2.Controls.Add(this.txtDir);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Location = new System.Drawing.Point(8, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 71);
            this.panel2.TabIndex = 1;
            // 
            // rtbFiles
            // 
            this.rtbFiles.Location = new System.Drawing.Point(4, 3);
            this.rtbFiles.Name = "rtbFiles";
            this.rtbFiles.Size = new System.Drawing.Size(589, 337);
            this.rtbFiles.TabIndex = 0;
            this.rtbFiles.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(518, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(72, 65);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "btnClear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(52, 16);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(318, 21);
            this.txtDir.TabIndex = 1;
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Location = new System.Drawing.Point(5, 21);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(29, 12);
            this.lblDir.TabIndex = 2;
            this.lblDir.Text = "目录";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(440, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(72, 65);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "搜盘";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // ckChildren
            // 
            this.ckChildren.AutoSize = true;
            this.ckChildren.Location = new System.Drawing.Point(376, 20);
            this.ckChildren.Name = "ckChildren";
            this.ckChildren.Size = new System.Drawing.Size(60, 16);
            this.ckChildren.TabIndex = 4;
            this.ckChildren.Text = "子目录";
            this.ckChildren.UseVisualStyleBackColor = true;
            // 
            // FrmFileForeach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 444);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmFileForeach";
            this.Text = "FrmFileForeach";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtbFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox ckChildren;
    }
}