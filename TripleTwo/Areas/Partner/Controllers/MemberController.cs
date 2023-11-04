using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripleTwo.BAL;
using TripleTwo.Entities;
using System.IO;
using TripleTwo.edmx;

namespace TripleTwo.Areas.Partner.Controllers
{
    [RouteArea("Partner")]
    public class MemberController : Controller
    {
        CustomerManager cusm = new CustomerManager();
        //[FilterConfig.partnerCookie]
        //[Route("ViewMembers")]
        public ActionResult ViewMembers()
        {
           
            ViewBag.orgid = Request.Cookies["_222prtn"]["orgid"];
            return View();
        }
        public ActionResult MemberMoods()
        {
            TripleTwoEntities db = new TripleTwoEntities();
            List<CustomerMood> mood = db.CustomerMoods.ToList();

            //ViewBag.orgid = Request.Cookies["_222prtn"]["orgid"];
            return View(mood);
        }
        [FilterConfig.partnerCookie]
        [Route("AddMember")]
        public ActionResult AddMember()
        {
            CustomerEntity ce = new CustomerEntity();
            Int32 id = 0;
            ViewBag.orgid = Request.Cookies["_222prtn"]["orgid"];
            if (Request.Params["id"] != null)
            {
                id = Convert.ToInt32(Request.Params["id"]);
                //ce = cusm.GetCustomerDetails(id);
            }
            ViewBag.id = id;
            return View(ce);
        }
        [FilterConfig.partnerCookie]
        [HttpPost]
        [Route("AddMember")]
        public ActionResult AddMember(CustomerEntity cEntity)
        {
            CustomerManager cm = new CustomerManager();
            //StatusResponse st = new StatusResponse();
            //st = cm.CustomerRegistration(cEntity);
            return RedirectToAction("ViewMembers");
        }
	}
}