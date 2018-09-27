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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.xpPanel1 = new XPect.Lib.XPControl.XPPanel();
            this.xpPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgain
            // 
            this.btnAgain.Location = new System.Drawing.Point(22, 7);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(75, 23);
            this.btnAgain.TabIndex = 2;
            this.btnAgain.Text = "Again";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(906, 494);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(243, 7);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 4;
            this.btnAddRow.Text = "Add";
            this.btnAddRow.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(346, 3);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRow.TabIndex = 5;
            this.btnDeleteRow.Text = "Delete";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            // 
            // xpPanel1
            // 
            this.xpPanel1.Controls.Add(this.btnDeleteRow);
            this.xpPanel1.Controls.Add(this.btnAddRow);
            this.xpPanel1.Controls.Add(this.btnAgain);
            this.xpPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xpPanel1.Location = new System.Drawing.Point(0, 0);
            this.xpPanel1.Name = "xpPanel1";
            this.xpPanel1.Size = new System.Drawing.Size(906, 33);
            this.xpPanel1.TabIndex = 6;
            // 
            // TestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 494);
            this.Controls.Add(this.xpPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TestFrm";
            this.Text = "tableLayoutPanelForm";
            this.Load += new System.EventHandler(this.TestFrm_Load);
            this.xpPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        private Button btnAgain;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnAddRow;
        private Button btnDeleteRow;
        private XPect.Lib.XPControl.XPPanel xpPanel1;
    }
}