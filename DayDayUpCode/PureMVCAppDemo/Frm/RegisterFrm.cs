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
    public partial class RegisterFrm : BaseForm, IMediator,INotifier//Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
            Init();
        }
        //封装一个公用的调度方法
        public CallFormDoMutual Call { get; private set; }
        void Init()
        {
            RegisterMediator();
        }
        public override void CallTodo(object data)
        {
            string tip = data as string;
            rtbTip.Text += "\r\n" + tip + "\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {//进行消息发送
            string tip = this.GetType().Name + " do message send" ;
            // OutSideCall.SendNotify(typeof(RegisterFrm).Name, tip);
            SendNotification(MediatorName, tip, ListNotificationInterests()[0]);
        }
        #region implementation
        public string MediatorName
        {
            get
            {
                return "BBB";
            }
        }

        public object  ViewComponent
        {
            get
            {
                return this;
            }

            set
            {
                value = this;
            }
        }

        public string[]  ListNotificationInterests()
        {
            return new  string[]{ MediatorName };
        }

        public void  HandleNotification(INotification notification)
        {
            object data = notification.Body;
            string name = notification.Name;
            string text = data as string;
            rtbTip.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + text + "\r\n";
            return;
        }

        public void  OnRegister()
        {
             
        }

        public void OnRemove()
        {
             
        }

        public void  SendNotification(string notificationName, object body, string type)
        {
            instance.SendNotification(notificationName, body, type);
        }

        public void  InitializeNotifier(string key)
        {
            return;
        }
        #endregion 
        FacadeFactory instance;
        public void RegisterMediator()
        {
            instance = new FacadeFactory(typeof(LoginFrm).Name);
            instance.RegisterMediator(this);
            LoginCommand lf = new LoginCommand();
            instance.RegisterCommand(MediatorName,()=>lf);
        }
    }
   
}
