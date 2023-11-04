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
    public class SponsorController : ApiController
    {

        SponsorManager objsm = new SponsorManager();

        [Route("api/GetSponsorList")] 
        [HttpPost]
        public List<SponsorListResponse> GetSponsorList(SponsorListParam p)
        {

            try
            {
                return objsm.GetSponsorList(p);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "SponsorController", "GetSponsorList-Services");
                return new List<SponsorListResponse>();
            }
        }

        [Route("api/GetSponsorDetailsById")]
        [HttpGet]
        public SponsorDetailResponse GetSponsorDetailsById(Int32 bid)
        {

            return objsm.GetSponsorDetailsById(bid);

        }

    }
}