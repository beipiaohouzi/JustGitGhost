using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DebugAppMvc
{
    // model 层

    public class UserBaseField
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserInfo:UserBaseField
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Birth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
    public class ResponseResult
    {
        public int HttpStatue { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
    public class UserLoginVO:UserBaseField
    {//  VO -- Value object

    }

}