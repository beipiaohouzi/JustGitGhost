using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
namespace PureMVCAppDemo
{
    public class RegisterFrmMediator:Mediator,INotifier
    {
        public RegisterFrmMediator(string name, object obj) : base(name, obj)
        {
            MultitonKey = name;
        }
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
        public override void HandleNotification(INotification notification)
        {
            base.HandleNotification(notification);
        }
        public override string[] ListNotificationInterests()
        {
            return new string[] { NotifyType.Register.ToString() };
        }
    }
    public class LoginFrmMediator : Mediator, INotifier
    {
        object mediator;
        public LoginFrmMediator(string name, object obj) : base(name, obj)
        {
            MultitonKey = name;
            mediator = obj;
        }
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
        public override void HandleNotification(INotification notification)
        {
            if (mediator != null)
            {
                IMediator m = mediator as IMediator;
                m.HandleNotification(notification);
            }
            else
                base.HandleNotification(notification);
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] { NotifyType.Login.ToString(), NotifyType.Register.ToString()};
        }
    }
    /// <summary>
    /// 视图层次的处理
    /// </summary>
    public class BaseViewMediator : Mediator, INotifier
    {
        string mediatorName;
        public BaseViewMediator(string name, object obj) : base(name, obj)
        {
            mediatorName = name;
            MultitonKey = mediatorName;
        }
        /// <summary>
        /// 会进行监听的对象
        /// </summary>
        public string[] ListenceNotifier;
        //启用全局注解形式来实现puremvc调用
        public override string[] ListNotificationInterests()
        {
            return ListenceNotifier;
        }
        /// <summary>
        /// 监听到消息时的处理逻辑
        /// </summary>
        /// <param name="notification"></param>
        public override void HandleNotification(INotification notification)
        {//
            base.HandleNotification(notification);
        }
        /// <summary>
        /// 进行消息发送的处理逻辑
        /// </summary>
        /// <param name="notificationName">消息对象名</param>
        /// <param name="body">消息内容</param>
        /// <param name="type">消息类型</param>
        public override void SendNotification(string notificationName, object body, string type)
        {//
            base.SendNotification(notificationName, body, type);
        }
    }
}
