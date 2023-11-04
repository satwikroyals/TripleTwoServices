using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TripleTwo.Areas.Partner.Controllers
{
    //[RouteArea("Partner")]
    public class DashboardController : Controller
    {
        //[FilterConfig.partnerCookie]
        //[Route("Dashboard")]
        public ActionResult Dashboard()
        {
            return View();
        }
	}
}