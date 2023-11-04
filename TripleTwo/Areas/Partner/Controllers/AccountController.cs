using TripleTwo.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripleTwo.Entities;
using System.Web.Security;
using TripleTwo.Code;
using TripleTwo.Areas.Partner.Models;

namespace TripleTwo.Areas.Partner.Controllers
{
     [RouteArea("Partner")]
    public class AccountController : Controller
    {
        PartnersManager pm = new PartnersManager();
        public ActionResult Login()
        {
            Response.Cache.SetNoStore();
            if (HttpContext.Request.Cookies["_222prtn"] != null)
            {
                return RedirectToAction("Dashboard", "Dashboard", new { area = "Partner" });
            }
            else
            {
                LoginModel lm = new LoginModel();
                return View(lm);
            }
        }
        [HttpPost]
        //[Route("Login")]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                PartnerEntity pe = new PartnerEntity();

                pe = pm.CheckPartnerLogin(model.UserName, model.Password);  //Check Valid admin or not; return valid 1 not valid 0
                if (pe == null)
                {
                    ModelState.AddModelError("Login", "Invalid username / password.");    //go to login page
                    return View(model);
                }

                else
                {
                    //bool rememberMe = form.IsRemember;
                    //create cookie
                    DateTime expiration = DateTime.Now.AddDays(30);
                    FormsAuthentication.Initialize();
                    FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, model.UserName,
                        DateTime.Now, expiration, true,
                        FormsAuthentication.FormsCookiePath);
                    HttpCookie ck = new HttpCookie("_222prtn", FormsAuthentication.Encrypt(tkt));
                    ck.Path = FormsAuthentication.FormsCookiePath;
                    ck.Expires = expiration;
                    ck["pid"] = pe.PartnerId.ToString();
                    ck["pn"] = pe.PartnerName;
                    ck["pl"] = pe.Logo;
                    ck["ptypeid"] = pe.PartnerTypeId.ToString();
                    ck["orgid"] = pe.OrgId.ToString();
                    Response.Cookies.Add(ck);
                    FormsAuthentication.RedirectFromLoginPage(pe.PartnerId.ToString(), true);
                    return RedirectToAction("Dashboard", "Dashboard", new { area = "Partner" });
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Logout()
        {
            Globalsettings.DoPartnerLogOut();
            return RedirectToAction("Login");
        }
    }
}