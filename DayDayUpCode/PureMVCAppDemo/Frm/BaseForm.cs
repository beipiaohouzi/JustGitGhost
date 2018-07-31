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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(FormClose_Event);
        }
        /// <summary>
        /// 供其他动作进行窗体间的操作[封装一个公用的调度方法]
        /// </summary>
        /// <param name="data"></param> 
        public CallFormDoMutual Call { get; private set; }
        public virtual void CallTodo(object data) { }
        void FormClose_Event(object sender,FormClosedEventArgs e)
        {
            Type t = this.GetType();
            //当窗体关闭时不能打开显示此窗体，建议移除puremvc中faccade注册的对象
            object fm= System.Activator.CreateInstance(t);
            BaseForm bf = fm as BaseForm;
            OutSideCall.ReplaceForm(bf);
        } 
    }
    public partial class BaseView : Form,PureMVC.Interfaces.IMediator, PureMVC.Interfaces.INotifier
    {
        public BaseView()
        {
            //1渲染
            InitializeComponent(); 
        }
        #region implementation
        
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
            return new string[] { MediatorName };
        }
         
        public void OnRegister()
        {

        }

        public void OnRemove()
        {

        }
         
        public void InitializeNotifier(string key)
        {
            return;
        }
        #region ui 层需要重写的
        public string MediatorName
        {
            get; set;
        }

        public void SendNotification(string notificationName, object body, string type)
        {
            instance.SendNotification(notificationName, body, type);

        }
        public void HandleNotification(INotification notification)
        {
            return;
        }
        #endregion
        #endregion
        FacadeFactory instance;
        /// <summary>
        /// 这里需要基类调用才生效
        /// </summary>
        public void RegisterMediator()
        { 
            instance = new FacadeFactory(MediatorName);
            instance.RegisterMediator(this);
            instance.RegisterCommand(MediatorName, () => new RegisterCommand());
        }
        
    }

    partial class BaseView
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
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "BaseView";
            this.Size = new System.Drawing.Size(491, 430);
            this.ResumeLayout(false);

        }

        #endregion
    }
    public enum MediatorMsgType
    {
        Call=1,
        Log=2,
        Response=3
    }
    public enum NotifyType
    {
        Login=1,
        Register=2,
        Onlines=3,
        Accounts=4
    }
}
