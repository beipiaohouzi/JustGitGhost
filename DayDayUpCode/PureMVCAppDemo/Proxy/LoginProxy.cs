using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PureMVC.Patterns.Proxy;
namespace PureMVCAppDemo
{
    public class LoginProxy:Proxy
    {
        public string Name { get; set; }
        public LoginProxy(string name, object obj) : base(name, obj)
        { }
        public override void SendNotification(string notificationName, object body, string type)
        {
            base.SendNotification(notificationName, body, type);
        }
        
    }
}
