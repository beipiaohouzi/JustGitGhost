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
    public partial class RegisterListFrm : BasePureMVCMediator
    {
        public RegisterListFrm()
        {
            InitializeComponent();
            Init();
            
        }
        void Init()
        {
           
            btnLogin.Click += new EventHandler(Button_Click);
            btnReg.Click += new EventHandler(Button_Click);
        }
        
        void Button_Click(object sender, EventArgs e)
        {
            //此处进行消息发送
            string txt= txtMsg .Text;
            Button btn = sender as Button;
           
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
