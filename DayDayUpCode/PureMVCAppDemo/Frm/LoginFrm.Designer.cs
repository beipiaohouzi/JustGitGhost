namespace PureMVCAppDemo
{
    partial class LoginFrm
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
            this.rtbTip = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbTip
            // 
            this.rtbTip.Location = new System.Drawing.Point(12, 2);
            this.rtbTip.Name = "rtbTip";
            this.rtbTip.Size = new System.Drawing.Size(369, 195);
            this.rtbTip.TabIndex = 0;
            this.rtbTip.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "RegisterFrm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbTip);
            this.Name = "LoginFrm";
            this.Text = "LoginFrm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbTip;
        private System.Windows.Forms.Button button1;
    }
}