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


    public class NotifyData
    {
        public static string Logic = "Logic";
        public const string Cmd_Grid = "Cmd_Grid";
        public const string Cmd_Account = "Cmd_Account";
        public const string Cmd_Account_Over= "Cmd_Account_Over";
        public const string Cmd_Image_PathSelect = "Cmd_Image_PathSelect";
        public const string Cmd_Image_ShowResult = "Cmd_Image_ShowResult";
    }
}
