using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripleTwo.BAL;
using TripleTwo.Entities;

namespace TripleTwo.Services
{
    public class GlobalController : ApiController
    {
        GlobalManager objsm = new GlobalManager();


        [Route("api/GetCountries")]
        [HttpGet]
        public List<CountryEntity> GetCountries(Int32 couid)
        {
            return objsm.GetCountries(couid);
        }

        [Route("api/GetOrganisationTypes")]
        [HttpGet]
        public List<OrganisationType> GetOrganisationTypes(Int32 orgid)
        {
            return objsm.GetOrganisationTypes(orgid);
        }

        [Route("api/GetOrganisationGroups")]
        [HttpGet]
        public List<OrganisationGroups> GetOrganisationGroups(Int32 orgid)
        {
            return objsm.GetOrganisationGroups(orgid);
        }

    }
}