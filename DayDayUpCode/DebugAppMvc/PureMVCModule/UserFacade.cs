using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebugAppMvc
{
    public class UserFacade : PureMVC.Patterns.Facade.Facade
    {
        public static UserFacade instance;
        public string defaultStartUp;
        public string name;
        public UserInfo user;
        public string notify;
        public UserCommand userCommand;
        public static UserFacade getInstance()
        {
            if (instance == null)
            {
                instance = new UserFacade(string.Empty);
            }
            return instance;
        }
        public UserFacade(string name) : base(name)
        {

        }
        protected override void InitializeController()
        {
            base.InitializeController();//初始化控制器
            RegisterCommand(defaultStartUp, () => userCommand);//注册可用的command
        }
        protected override void InitializeModel()
        {//初始化数据访问模型，数据访问层封装
            base.InitializeModel();
            RegisterProxy(new UserProxy(name, user));
        }
        public void SendNotificationData(string notify,object body,string notifyType)
        {
            SendNotification(notify, body, notifyType);
        }
        public void RegisterThisMediator()
        {
            RegisterMediator(new UserMediator(name,user));
        }
    }
}