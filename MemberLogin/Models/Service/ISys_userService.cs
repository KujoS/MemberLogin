using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MemberLogin.Models.EF;

namespace MemberLogin.Models.Service
{
    public interface ISys_userService
    {
        int Insert(sys_user t);

        int Delete(int id);

        int Update(sys_user t);

        List<sys_user> Query();

        sys_user Query(int id);
    }
}