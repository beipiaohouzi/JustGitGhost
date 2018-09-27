using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Patterns.Facade;
using PureMVC.Interfaces;
using System.Windows.Forms;
namespace PureMVCAppDemo
{
    #region 常规处理
    public class FacadeEnter:Facade
    {
        public static FacadeEnter Instance;
        static FacadeEnter()
        {
            if (Instance==null)
            {
                Instance = new FacadeEnter();
            }
        }
        public FacadeEnter():base("FacadeEnter")
        {

        }
        public void MVCRegister(IMediator mediator)
        {
            Instance.RegisterMediator(mediator);
        }
    }
    public class OutSideCall
    {
        public static IFacade fa { get; private set; }
        static OutSideCall()
        {
            AfterRegisterCall();
        }
       static  void AfterRegisterCall()
        {
            if (fa == null)
            {
                string name = typeof(FacadeEnter).Name;
                fa = Facade.GetInstance(name, () => new Facade(name));//之前注册的是否可调用
            }
            
        }
        public static Form GetFormInstance(string formName)
        {
            IMediator me = fa.RetrieveMediator(formName);
            object obj = me.ViewComponent;
            return (obj as Form);
        }
        public static void ReplaceForm(BaseForm form)
        {//在进行窗体关闭时，会出现窗体对象已经释放，不能再加载显示
            InstanceService ins = new InstanceService();
            //之前已经存在的对象先进行删除
            string mediator = form.GetType().Name;
            fa.RemoveMediator(mediator);
            fa.RegisterMediator(ins.RegisterForm(mediator, form));
        }
       
    }
    #endregion
    
    public class NotifyBody
    {
        public string Msg { get; set; }
        public object From { get; set; }
    }
    #region register
    public class BasePureMVCCommand:PureMVC.Patterns.Command.SimpleCommand
    {
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
        }
    }
    [System.ComponentModel.Description("窗体直接传递")]
    public class BasePureMVCMediator :Form, IMediator
    {
        #region private member part
        protected string mediatorName;
        protected object component;
        protected static FacadeFactory Instance;
        #endregion
        #region inherit 
        string IMediator.MediatorName
        {
            get
            {
                return mediatorName;
            }
        }

        object IMediator.ViewComponent
        {
            get
            {
                return component;
            }

            set
            {
                component = value;
            }
        }

        
        void INotifier.InitializeNotifier(string key)
        {
            return;
        }

       

        void IMediator.OnRegister()
        {
            return;
        }

        void IMediator.OnRemove()
        {
            return;
        }
        #endregion
        #region core part
        public virtual void HandleNotification(INotification notification)
        {

        }
        public virtual string[] ListNotificationInterests()
        {
            return new string[] { };
        }
        public virtual void SendNotification(string notificationName, object body, string type)
        {
            Instance.SendNotification(notificationName, body, type);
        }
        public BasePureMVCMediator()
        {
            mediatorName = this.GetType().Name;
            component = this;
            if (Instance == null)
            {
                Instance = FacadeFactory.GetInstance();
            }
            Instance.RegisterMediator(this);
        }
        #endregion
    }
    public class FacadeFactory : Facade
    {
        static string factory = "factory";
        FacadeFactory() : base(factory)
        { 
        }
        static FacadeFactory instance;
        public static FacadeFactory GetInstance()
        {
            if (instance == null)
            {
                return new FacadeFactory();
            }
            return instance;
        }
        protected override void InitializeController()
        {
            base.InitializeController();
            //registe
            RegisterCommand(typeof(LoginCommand).Name, ()=>new LoginCommand());
            RegisterCommand(typeof(RegisterCommand).Name, () => new RegisterCommand());
        }
       
        public override void SendNotification(string notificationName, object body = null, string type = null)
        {
            multitonKey = factory;
            base.SendNotification(notificationName, body, type);
        }
        public override void RegisterMediator(IMediator mediator)
        {
            base.RegisterMediator(mediator);
        }
        public override void RegisterCommand(string notificationName, Func<ICommand> commandClassRef)
        {
            base.RegisterCommand(notificationName, commandClassRef);
        }
    }
    #endregion
     
}
