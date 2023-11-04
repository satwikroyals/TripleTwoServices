using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTwo.Entities
{
    public class GlobalEntity
    {
        public class CountryEntity
        {
            public Int32 CountryId { get; set; }
            public string CountryName { get; set; }
        }

        public class OrganisationType
        {
            public Int32 OrganisationTypeId { get; set; }
            public String OrgName { get; set; }
        }

        

    }
}
