using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class SupporterManager
    {

        SupporterData dal = new SupporterData();
        public SupporterDetailResponse GetSupporterDetailsById(Int32 bid)
        {
            return dal.GetSupporterDetailsById(bid);
        }

        public List<SupporterListResponse> GetSupporterList(SupporterListParam p)
        {
            return dal.GetSupporterList(p);
        }

    }
}
