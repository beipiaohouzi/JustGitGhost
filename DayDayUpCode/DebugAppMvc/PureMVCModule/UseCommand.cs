using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PureMVC.Interfaces;

namespace DebugAppMvc
{
    public class UserCommand:PureMVC.Patterns.Command.SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            object body = notification.Body;
            base.Execute(notification);
        }
    }
}