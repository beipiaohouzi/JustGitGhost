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
    public partial class RegisterListFrm : BaseView
    {
        public RegisterListFrm()
        {
            InitializeComponent();
            Init();
            
        }
        void Init()
        {
            MediatorName = NotifyType.Accounts.ToString();
           
            RegisterMediator();
            btnLogin.Click += new EventHandler(Button_Click);
            btnReg.Click += new EventHandler(Button_Click);
        }
        //封装一个公用的调度方法
        public CallFormDoMutual Call { get; private set; }
        public new void HandleNotification(INotification notify)
        {
            //进行消息监听
        }
        void Button_Click(object sender, EventArgs e)
        {
            //此处进行消息发送
            string txt= txtMsg .Text;
            Button btn = sender as Button;
            SendNotification(MediatorName,txt, MediatorMsgType.Call.ToString());
        }
    }
}
