namespace XP.UI.Test
{
    partial class Form1
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
            this.xpTextBox1 = new XPect.Lib.XPControl.XPTextBox();
            this.xpButton1 = new XPect.Lib.XPControl.XPButton();
            this.SuspendLayout();
            // 
            // xpTextBox1
            // 
            this.xpTextBox1.Location = new System.Drawing.Point(41, 39);
            this.xpTextBox1.Name = "xpTextBox1";
            this.xpTextBox1.Size = new System.Drawing.Size(100, 21);
            this.xpTextBox1.TabIndex = 0;
            // 
            // xpButton1
            // 
            this.xpButton1.Location = new System.Drawing.Point(41, 90);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 23);
            this.xpButton1.TabIndex = 1;
            this.xpButton1.Text = "xpButton1";
            this.xpButton1.UseVisualStyleBackColor = true;
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.xpButton1);
            this.Controls.Add(this.xpTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XPect.Lib.XPControl.XPTextBox xpTextBox1;
        private XPect.Lib.XPControl.XPButton xpButton1;
    }
}

