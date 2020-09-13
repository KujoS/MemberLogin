using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberLogin.Models.EF
{
    public class sys_user
    {
        public int id { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public int Level { set; get; }
        public string Remark { set; get; }
    }
}