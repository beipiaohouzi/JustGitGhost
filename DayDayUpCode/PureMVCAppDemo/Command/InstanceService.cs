using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
namespace PureMVCAppDemo
{
    public class InstanceService
    {
        public IMediator mediator { get; private set; }
        public InstanceService()
        {

        }
        /// <summary>
        /// 进行窗体注册
        /// </summary>
        /// <param name="form"></param>
        /// <param name="frm"></param>
        public IMediator RegisterForm(string form, Form frm)
        {
            return new Mediator(form, frm);
        }
    }
    public class LoginCommand : SimpleCommand
    {
        public LoginCommand() : base()
        {

        }
        public override void Execute(INotification notification)
        {
           // SendNotification(notification.Name, notification.Body, notification.Type);
            base.Execute(notification);
        }
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
    }
    public class RegisterCommand : SimpleCommand
    {
        public RegisterCommand() { }
        public override void Execute(INotification notification)
        {
            base.Execute(notification);
        }
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
       
    }
}
