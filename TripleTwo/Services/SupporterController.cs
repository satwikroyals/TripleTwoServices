using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripleTwo.BAL;
using TripleTwo.Code;
using TripleTwo.Entities;

namespace TripleTwo.Services
{
    public class SupporterController : ApiController
    {
        SupporterManager objsm = new SupporterManager();

        [Route("api/GetSupporterList")]
        [HttpPost]
        public List<SupporterListResponse> GetSupporterList(SupporterListParam p)
        {

            try
            {
                return objsm.GetSupporterList(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "SupporterController", "GetSupporterList-Services");
                return new List<SupporterListResponse>();
            }
        }

        [Route("api/GetSupporterDetailsById")]
        [HttpGet]
        public SupporterDetailResponse GetSupporterDetailsById(Int32 bid)
        {

            return objsm.GetSupporterDetailsById(bid);

        }
    }
}