using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebugAppMvc
{
    public class UserMediator:PureMVC.Patterns.Mediator.Mediator
    {
        public UserMediator(string name, object viewCompent) : base(name, viewCompent)
        {

        }
    }
}