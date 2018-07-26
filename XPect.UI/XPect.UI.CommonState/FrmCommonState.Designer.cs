namespace XPect.UI.CommonState
{
    partial class FrmCommonState
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
            this.xpLabel1.Location = new System.Drawing.Point(283, 27);
            this.xpLabel1.Name = "xpLabel1";
            this.xpLabel1.Size = new System.Drawing.Size(89, 12);
            this.xpLabel1.TabIndex = 0;
            this.xpLabel1.Text = "Commom State";
            // 
            // FrmCommonState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1352, 222);
            this.Controls.Add(this.xpLabel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCommonState";
            this.Text = "FrmCommonState";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Lib.XPControl.XPLabel xpLabel1;
    }
}