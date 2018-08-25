namespace PureMVCAppDemo
{
    using System.Windows.Forms;
    partial class TestFrm
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
            this.corePic = new System.Windows.Forms.PictureBox();
            this.iconPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.corePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // corePic
            // 
            this.corePic.Location = new System.Drawing.Point(44, 39);
            this.corePic.Name = "corePic";
            this.corePic.Size = new System.Drawing.Size(222, 217);
            this.corePic.TabIndex = 1;
            this.corePic.TabStop = false;
            // 
            // iconPic
            // 
            this.iconPic.Location = new System.Drawing.Point(226, 39);
            this.iconPic.Name = "iconPic";
            this.iconPic.Size = new System.Drawing.Size(40, 41);
            this.iconPic.TabIndex = 0;
            this.iconPic.TabStop = false;
            // 
            // TestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 303);
           
           
            this.Controls.Add(this.iconPic);
            this.Controls.Add(this.corePic);
            this.Name = "TestFrm";
            this.Text = "tableLayoutPanelForm";
            ((System.ComponentModel.ISupportInitialize)(this.corePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPic)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private PictureBox corePic;
        private PictureBox iconPic;
    }
}