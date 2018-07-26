namespace XP.UI.Startup
{
    partial class FrmSplasher
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
            this.xpTableLayoutPanel1 = new XPect.Lib.XPControl.XPTableLayoutPanel();
            this.mLblStatusCaption = new XPect.Lib.XPControl.XPLabel();
            this.mLblStatusInfo = new XPect.Lib.XPControl.XPLabel();
            this.xpTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpTableLayoutPanel1
            // 
            this.xpTableLayoutPanel1.ColumnCount = 2;
            this.xpTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.22814F));
            this.xpTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.77187F));
            this.xpTableLayoutPanel1.Controls.Add(this.mLblStatusCaption, 1, 1);
            this.xpTableLayoutPanel1.Controls.Add(this.mLblStatusInfo, 1, 2);
            this.xpTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xpTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.xpTableLayoutPanel1.Name = "xpTableLayoutPanel1";
            this.xpTableLayoutPanel1.RowCount = 3;
            this.xpTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.76471F));
            this.xpTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.235294F));
            this.xpTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 396F));
            this.xpTableLayoutPanel1.Size = new System.Drawing.Size(1052, 768);
            this.xpTableLayoutPanel1.TabIndex = 0;
            // 
            // mLblStatusCaption
            // 
            this.mLblStatusCaption.AutoSize = true;
            this.mLblStatusCaption.Dock = System.Windows.Forms.DockStyle.Left;
            this.mLblStatusCaption.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mLblStatusCaption.Location = new System.Drawing.Point(320, 341);
            this.mLblStatusCaption.Name = "mLblStatusCaption";
            this.mLblStatusCaption.Size = new System.Drawing.Size(187, 30);
            this.mLblStatusCaption.TabIndex = 0;
            this.mLblStatusCaption.Text = "XPect Mammo System Loading";
            // 
            // mLblStatusInfo
            // 
            this.mLblStatusInfo.AutoSize = true;
            this.mLblStatusInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.mLblStatusInfo.Location = new System.Drawing.Point(320, 371);
            this.mLblStatusInfo.Name = "mLblStatusInfo";
            this.mLblStatusInfo.Size = new System.Drawing.Size(83, 397);
            this.mLblStatusInfo.TabIndex = 1;
            this.mLblStatusInfo.Text = "Loading......";
            // 
            // FrmSplasher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 768);
            this.Controls.Add(this.xpTableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSplasher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.xpTableLayoutPanel1.ResumeLayout(false);
            this.xpTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private XPect.Lib.XPControl.XPTableLayoutPanel xpTableLayoutPanel1;
        private XPect.Lib.XPControl.XPLabel mLblStatusCaption;
        private XPect.Lib.XPControl.XPLabel mLblStatusInfo;
    }
}

