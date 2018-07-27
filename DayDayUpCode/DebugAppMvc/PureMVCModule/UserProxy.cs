using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebugAppMvc
{
    public class UserProxy:PureMVC.Patterns.Proxy.Proxy
    {
        public UserProxy(string Name, UserInfo User) : base(Name, User)
        {

        }
    }
}