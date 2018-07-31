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
    public partial class LoginFrm : BaseForm, IMediator, INotifier
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
            RegisterMediator();
        }
        public override void CallTodo(object data)
        {
            string tip = data as string;
            rtbTip.Text += "\r\n" + tip+"\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // BaseForm bf = OutSideCall.GetFormInstance(typeof(RegisterFrm).Name) as BaseForm;
            string tip = this.GetType().Name + " send : " + txtMsg.Text;
            SendNotification(MediatorName, tip, ListNotificationInterests()[0]);
        }
        #region implementation
        public string MediatorName
        {
            get
            {
                return NotifyType.Login.ToString();
            }
        }

        public object ViewComponent
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

        public string[] ListNotificationInterests()
        {
            return new string[] { NotifyType.Login.ToString(),  NotifyType.Accounts.ToString() };
        }

        public void HandleNotification(INotification notification)
        {
            object data = notification.Body;
            string name = notification.Name;
            string text = data as string;
            rtbTip.Text += "\r\n" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + text;
            return;
        }

        public void OnRegister()
        {

        }

        public void OnRemove()
        {

        }

        public void SendNotification(string notificationName, object body, string type)
        {
            instance.SendNotification(notificationName, body, type);
            
        }

        public void InitializeNotifier(string key)
        {
            return;
        }
        #endregion
        FacadeFactory instance;
        //public LoginFrmMediator instance;
        public void RegisterMediator()
        {
            //instance = new LoginFrmMediator(MediatorName, ViewComponent);
            instance =  FacadeFactory.GetInstance();
            LoginFrmMediator lm = new LoginFrmMediator(MediatorName, this);
            instance.RegisterMediator(lm);
            LoginCommand lf = new LoginCommand();
            instance.RegisterCommand(MediatorName, () => lf);
            
            
        }
    }
}
