using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.XPControl;
using PureMVC.Interfaces;
namespace PureMVCAppDemo
{
    public partial class GridFrm : BasePureMVCMediator
    {
        int col = 0, rowHeight = 0;
        int mColWidth = 0;
        public GridFrm()
        {
            InitializeComponent();
            InitEle();
        }
        private void InitEle()
        {
            btnAddRow.Click += new EventHandler(btnAddRow_Click);
            btnDeleteRow.Click += new EventHandler(btnDeleteRow_Click);
            btnAddCol.Click += new EventHandler(BtnAddCol_Click);
            col = 3;
            rowHeight = 260;
            mColWidth = tablePanel.Width / col;
            tablePanel.RowStyles.Clear();
            AddGridRow(col, rowHeight);
            tablePanel.AutoScroll = true;
        }
        private void AddGridRow(int col,int rowHeight)
        { 
            tablePanel.ColumnCount = col;
            for (int i = 0; i < col; i++)
            {
                this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, mColWidth));
            }
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, rowHeight));
            XPImagePanel img = new XPImagePanel()
            {
                Width = mColWidth,
                Height = rowHeight
            };
            img.RefreshDesc("Index:" + tablePanel.Controls.Count);
            tablePanel.Controls.Add(img);
        }
        private void BtnAddCol_Click(object sender,EventArgs e)
        {
            XPImagePanel img = new XPImagePanel()
            {
               Height= rowHeight,
               Width=mColWidth
            };
            img.RefreshDesc("Index:" + tablePanel.Controls.Count);
            tablePanel.Controls.Add(img);
        }
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddGridRow(col,rowHeight);
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

        }
        #region  overide
        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case NotifyData.Cmd_Account:
                    string msg = notification.Body as string;
                    Console.WriteLine(string.Format("form :{0} receiver msg:{1}", this.GetType().Name, msg));
                    break;
            }
        }
        public override string[] ListNotificationInterests()
        {
            return new string[] {
                NotifyData.Cmd_Grid,
                NotifyData.Cmd_Account
           };
        }
        #endregion 
    }
}
