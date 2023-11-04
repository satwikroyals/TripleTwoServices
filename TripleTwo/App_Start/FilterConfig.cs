using System;
using System.Web;
using System.Web.Mvc;

namespace TripleTwo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class GroupCookieAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Request.Cookies["_gr"];
                if (user == null)
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/group/account/Logout");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
        public class OrgCookieAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Request.Cookies["_org"];
                if (user == null)
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/account/Logout");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class comCookieAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Request.Cookies["_com"];
                if (user == null)
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/account/Logout");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class adminCookieAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Request.Cookies["_out"];
                if (user == null)
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/outcome/account/Logout");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
        public class partnerCookieAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Request.Cookies["_222prtn"];
                if (user == null)
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/Partner/account/Logout");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }
    }
}
