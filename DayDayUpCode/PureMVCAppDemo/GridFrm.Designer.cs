namespace PureMVCAppDemo
{
    partial class GridFrm
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
            this.xpPanel1 = new XPect.Lib.XPControl.XPPanel();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.xpPanel2 = new XPect.Lib.XPControl.XPPanel();
            this.tablePanel = new XPect.Lib.XPControl.XPTableLayoutPanel();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.btnDeleteCol = new System.Windows.Forms.Button();
            this.xpPanel1.SuspendLayout();
            this.xpPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xpPanel1
            // 
            this.xpPanel1.Controls.Add(this.btnDeleteCol);
            this.xpPanel1.Controls.Add(this.btnAddCol);
            this.xpPanel1.Controls.Add(this.btnDeleteRow);
            this.xpPanel1.Controls.Add(this.btnAddRow);
            this.xpPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xpPanel1.Location = new System.Drawing.Point(0, 0);
            this.xpPanel1.Name = "xpPanel1";
            this.xpPanel1.Size = new System.Drawing.Size(680, 33);
            this.xpPanel1.TabIndex = 7;
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Location = new System.Drawing.Point(370, 7);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(139, 23);
            this.btnDeleteRow.TabIndex = 5;
            this.btnDeleteRow.Text = "Delete Row";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(191, 7);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(149, 23);
            this.btnAddRow.TabIndex = 4;
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.UseVisualStyleBackColor = true;
            // 
            // xpPanel2
            // 
            this.xpPanel2.Controls.Add(this.tablePanel);
            this.xpPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xpPanel2.Location = new System.Drawing.Point(0, 33);
            this.xpPanel2.Name = "xpPanel2";
            this.xpPanel2.Size = new System.Drawing.Size(680, 524);
            this.xpPanel2.TabIndex = 8;
            // 
            // tablePanel
            // 
            this.tablePanel.ColumnCount = 2;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel.Size = new System.Drawing.Size(680, 524);
            this.tablePanel.TabIndex = 0;
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point(12, 7);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(149, 23);
            this.btnAddCol.TabIndex = 6;
            this.btnAddCol.Text = "Add col";
            this.btnAddCol.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCol
            // 
            this.btnDeleteCol.Location = new System.Drawing.Point(529, 7);
            this.btnDeleteCol.Name = "btnDeleteCol";
            this.btnDeleteCol.Size = new System.Drawing.Size(139, 23);
            this.btnDeleteCol.TabIndex = 7;
            this.btnDeleteCol.Text = "Delete Col";
            this.btnDeleteCol.UseVisualStyleBackColor = true;
            // 
            // GridFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 557);
            this.Controls.Add(this.xpPanel2);
            this.Controls.Add(this.xpPanel1);
            this.Name = "GridFrm";
            this.Text = "GridFrm";
            this.xpPanel1.ResumeLayout(false);
            this.xpPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XPect.Lib.XPControl.XPPanel xpPanel1;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnAddRow;
        private XPect.Lib.XPControl.XPPanel xpPanel2;
        private XPect.Lib.XPControl.XPTableLayoutPanel tablePanel;
        private System.Windows.Forms.Button btnDeleteCol;
        private System.Windows.Forms.Button btnAddCol;
    }
}