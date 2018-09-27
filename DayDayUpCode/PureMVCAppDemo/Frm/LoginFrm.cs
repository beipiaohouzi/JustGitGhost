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
    /// <summary>
    /// 窗体的交互动作
    /// </summary>
    /// <param name="data"></param>
    public delegate void CallFormDoMutual(object data);
    public partial class LoginFrm : BasePureMVCMediator
    {
        public LoginFrm()
        {
            InitializeComponent();
            Init();
        }
        //封装一个公用的调度方法
        public CallFormDoMutual Call { get; private set; }
        void Init()
        {
           
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            // BaseForm bf = OutSideCall.GetFormInstance(typeof(RegisterFrm).Name) as BaseForm;
            string input = txtMsg.Text;
            string tip = this.GetType().Name + " send : " +(string.IsNullOrEmpty(input) ? "Non msg。" : input) ;
            SendNotification(NotifyData.Cmd_Account, tip, string.Empty);
        }
        #region  overide
        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case NotifyData.Cmd_Account_Over:
                    string msg = notification.Body as string;
                    string response = string.Format("{0} receiver msg:{1}",this.GetType().Name,msg);
                    rtbTip.Text += response + "\r\n";
                    break;
            }
        }
        public override string[] ListNotificationInterests()
        {
            return new string[] {
                NotifyData.Cmd_Account_Over
           };
        }
        #endregion 
    }
}
