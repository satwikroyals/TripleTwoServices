using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class GlobalManager
    {
        GlobalData dal = new GlobalData();
        public List<CountryEntity> GetCountries(Int32 couid)
        {
            return dal.GetCountries(couid);
        }

        public List<OrganisationType> GetOrganisationTypes(Int32 orgid)
        {
            return dal.GetOrganisationTypes(orgid);
        }

        public List<OrganisationGroups> GetOrganisationGroups(int orgid)
        {
            return dal.GetOrganisationGroups(orgid);
        }
    }
}
