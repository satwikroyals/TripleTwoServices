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
    public class BusinessController : ApiController
    {
        BusinessManager objsm = new BusinessManager();

        [Route("api/GetBusinessList")]
        [HttpPost]
        public List<BusinessListResponse> GetBusinessList(BusinessListParam p)
        {

            try
            {
                return objsm.GetBusinessList(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "BusinessController", "GetBusinessList-Services");
                return new List<BusinessListResponse>();
            }
        }

        [Route("api/GetBusinessDetailsById")]
        [HttpGet]
        public BusinessDetailResponse GetBusinessDetailsById(Int32 bid)
        {

            return objsm.GetBusinessDetailsById(bid);

        }

    }
}