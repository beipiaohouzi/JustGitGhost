namespace XPect.UI.Study
{
    partial class FrmStudyToolbar
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
            this.xpLabel1 = new XPect.Lib.XPControl.XPLabel();
            this.SuspendLayout();
            // 
            // xpLabel1
            // 
            this.xpLabel1.AutoSize = true;
            this.xpLabel1.Location = new System.Drawing.Point(487, 390);
            this.xpLabel1.Name = "xpLabel1";
            this.xpLabel1.Size = new System.Drawing.Size(53, 12);
            this.xpLabel1.TabIndex = 0;
            this.xpLabel1.Text = "xpLabel1";
            // 
            // FrmStudyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1267, 817);
            this.Controls.Add(this.xpLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStudyList";
            this.Text = "FrmStudyList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lib.XPControl.XPLabel xpLabel1;
    }
}