using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class SponsorManager
    {
        SponsorData dal = new SponsorData();
        public SponsorDetailResponse GetSponsorDetailsById(Int32 bid)
        {
            return dal.GetSponsorDetailsById(bid);
        }

        public List<SponsorListResponse> GetSponsorList(SponsorListParam p)
        {
            return dal.GetSponsorList(p);
        }


    }
}
