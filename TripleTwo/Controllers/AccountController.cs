using TripleTwo.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TripleTwo.DAL;
using TripleTwo.BAL;
using TripleTwo.Entities;
using TripleTwo.Models;

namespace TripleTwo.Controllers
{
    public class AccountController : Controller
    {
        private OrganizationManager objorgm = new OrganizationManager();
        public ActionResult Login(string id)
        {
            Response.Cache.SetNoStore();
            if (HttpContext.Request.Cookies["_org"] != null)
            {
                return RedirectToAction("Home", "Dashboard");
            }
            else
            {
                LoginModel lm = new Models.LoginModel();
                return View(lm);
            }
        }
        [HttpPost]

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                OrgEntity orge = new OrgEntity();

                orge = objorgm.CheckOrgLogin(model.UserName, model.Password);  //Check Valid admin or not; return valid 1 not valid 0
                if (orge == null)
                {
                    ModelState.AddModelError("Login", "Invalid username / password.");    //go to login page
                    return View(model);
                }

                else
                {
                    DateTime expiration = DateTime.Now.AddDays(30);
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, model.UserName,
                        DateTime.Now, expiration, true,
                        FormsAuthentication.FormsCookiePath);
                    HttpCookie ck = new HttpCookie("_org", FormsAuthentication.Encrypt(tkt));
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    ck.Expires = expiration;
                    ck["orgid"] = orge.OrgId.ToString();
                    ck["orgn"] = orge.OrgName;
                    ck["orgl"] = orge.LogoPath;
                    ck["orgprimary"] = orge.Primarycolor;
                    ck["orgsecondary"] = orge.Secondarycolor;
                    ck["orgbtns"] = orge.Thirdcolor;
                    ck["orgtxt"] = orge.Textcolor;
                    ck["orgbackgroundimg"] = orge.BackgroundImagepath;
                    ck["orgmenuimg"] = orge.MenuBackImagePath;
                    ck["orgbannerimg"] = orge.BannerImagepath;
                    Response.Cookies.Add(ck);
                    FormsAuthentication.RedirectFromLoginPage(orge.OrgId.ToString(), true);
                    return RedirectToAction("Home", "Dashboard");
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            Globalsettings.DoOrgLogOut();
            return RedirectToAction("Login");
        }
	}
}