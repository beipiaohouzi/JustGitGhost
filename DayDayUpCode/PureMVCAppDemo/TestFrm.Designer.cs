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
            this.btnAgain = new System.Windows.Forms.Button();
            this.rtbTip = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(44, 3);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(75, 23);
            this.btnAgain.TabIndex = 2;
            this.btnAgain.Text = "Again";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // rtbTip
            // 
            this.rtbTip.Location = new System.Drawing.Point(29, 81);
            this.rtbTip.Name = "rtbTip";
            this.rtbTip.Size = new System.Drawing.Size(253, 184);
            this.rtbTip.TabIndex = 3;
            this.rtbTip.Text = "";
            // 
            // TestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 303);
            this.Controls.Add(this.rtbTip);
            this.Controls.Add(this.btnAgain);
            this.Name = "TestFrm";
            this.Text = "tableLayoutPanelForm";
            this.Load += new System.EventHandler(this.TestFrm_Load);
            this.ResumeLayout(false);

        }
        #endregion
        private Button btnAgain;
        private RichTextBox rtbTip;
    }
}