using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PureMVC.Interfaces;
namespace PureMVCAppDemo
{
    public partial class ImgPathSelectFrm : BasePureMVCMediator
    {
        OpenFileDialog of = new OpenFileDialog();
        public ImgPathSelectFrm()
        {
            InitializeComponent();
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

        private void btnLoading_Click(object sender, EventArgs e)
        {
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                string[] files = of.FileNames;
                txtFile.Text = string.Join(";", files);
                SendNotification(NotifyData.Cmd_Image_PathSelect, files,string.Empty);
            }
        }
    }
}
