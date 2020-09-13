using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemberLogin.Models.Service;
using MemberLogin.Models.EF;

namespace MemberLogin.Controllers.api
{
    public class MemberController : ApiController
    {
        ISys_userService sys_userService;

        public MemberController(ISys_userService _user)
        {
            sys_userService = _user;
        }
        // GET: api/Member
        public IEnumerable<sys_user> Get()
        {
            return sys_userService.Query();
        }

        // GET: api/Member/5
        public sys_user Get(int id)
        {
            return sys_userService.Query(id);
        }

        // POST: api/Member
        public IHttpActionResult Post([FromBody]sys_user user)
        {
            sys_userService.Insert(user);
            return Ok();
        }

        // PUT: api/Member/5
        public IHttpActionResult Put(int id, [FromBody]sys_user user)
        {
            sys_userService.Update(user);
            return Ok();
        }

        // DELETE: api/Member/5
        public IHttpActionResult Delete(int id)
        {
            sys_userService.Delete(id);
            return Ok();
        }
    }
}
