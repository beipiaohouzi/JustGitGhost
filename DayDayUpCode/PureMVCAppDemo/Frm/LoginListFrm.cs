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
    public partial class LoginListFrm :BasePureMVCMediator
    {
        public LoginListFrm()
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
    }
}
