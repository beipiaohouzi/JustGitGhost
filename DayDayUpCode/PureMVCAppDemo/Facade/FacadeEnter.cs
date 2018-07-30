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
    using PureMVCAppDemo.Command;
    #region 常规处理
    public class FacadeEnter
    {
        public void MVCRegister()
        {
            string name = typeof(FacadeEnter).Name;
            IFacade fa = Facade.GetInstance(name, () => new Facade(name));
            InstanceService ins = new InstanceService();
            fa.RegisterMediator(ins.RegisterForm(typeof(LoginFrm).Name,new LoginFrm()));
            fa.RegisterMediator(ins.RegisterForm(typeof(RegisterFrm).Name, new RegisterFrm()));
            fa.RegisterMediator(ins.RegisterForm(typeof(LoginListFrm).Name, new LoginListFrm()));
            fa.RegisterMediator(ins.RegisterForm(typeof(RegisterListFrm).Name, new RegisterListFrm()));

            IMediator m = fa.RetrieveMediator(typeof(LoginFrm).Name);
            Form obj = m.ViewComponent as Form;
           // IMediator me = new InstanceService().mediator;
           // fa.SendNotification(typeof(InstanceService).Name, me);
            
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
        
    }
    public class BasePureMVCMediator : PureMVC.Patterns.Mediator.Mediator
    {
        public string fac;
        public object view;
        public BasePureMVCMediator(string fac, object view) : base(fac,view)
        {
            this.fac = fac;
            this.view = view;
        }
        public override void HandleNotification(INotification notification)
        {
            base.HandleNotification(notification);
        }
    }
    public class FacadeFactory : Facade
    {
         string factory = "factory";
        public FacadeFactory(string fac) : base(fac)
        {

        }
        protected override void InitializeController()
        {
            Facade fac = new Facade(factory) ;
            //注册
             
            base.InitializeController();
        }
        public override void SendNotification(string notificationName, object body = null, string type = null)
        {
            multitonKey = notificationName;
            base.SendNotification(notificationName, body, type);
        }
        
    }
    #endregion
}
