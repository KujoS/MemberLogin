using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MemberLogin.Models.ViewModel;
using MemberLogin.Models.Service;
using System.Web.Security;

namespace MemberLogin.Controllers
{ 
    [Authorize]
    public class HomeController : Controller
    {
        ISys_userService userService;

        public HomeController(ISys_userService _user)
        {
            userService = _user;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            ModelState.AddModelError("", "使用者不存在");
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var u = userService.Query()?.FirstOrDefault(c => c.Name.Equals(model.Name));

            if (u == null)
            {
                ModelState.AddModelError("Name", "使用者不存在");
            }
            else if (!u.Password.Equals(model.Password, StringComparison.Ordinal))
            {
                ModelState.AddModelError("Password", "密碼錯誤");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAccount()
        {
            try
            {
                var acc = Request.Params["acc"];
                var pw = Request.Params["pw"];
                if(string.IsNullOrWhiteSpace(acc) || string.IsNullOrWhiteSpace(pw))
                {
                    throw new Exception("缺少資料");
                }

                userService.Insert(new Models.EF.sys_user
                {
                    Name = acc,
                    Password = pw,
                    Level = 1

                });

                return Content("000");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }
        public ActionResult Index()
        {
            string user = System.Web.HttpContext.Current.User.Identity.Name;

            var acc = userService.Query(user);
            ViewBag.UserName = acc?.Name;
            ViewBag.Level = acc?.Level;
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}