using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class BusinessManager
    {

        BusinessData dal = new BusinessData();
        public BusinessDetailResponse GetBusinessDetailsById(Int32 bid)
        {
            return dal.GetBusinessDetailsById(bid);
        }

        public List<BusinessListResponse> GetBusinessList(BusinessListParam p)
        {
            return dal.GetBusinessList(p);
        }
    }
}
