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
    public partial class RegisterFrm :  BasePureMVCMediator
    {
        public RegisterFrm()
        {
            InitializeComponent();
            Init();
        }
        //封装一个公用的调度方法
     
        void Init()
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {//进行消息发送
            string tip = this.GetType().Name + " send : " + txtMsg.Text;
            // OutSideCall.SendNotify(typeof(RegisterFrm).Name, tip);
          
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
