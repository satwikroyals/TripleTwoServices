using Dapper;
using DbFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;

namespace TripleTwo.DAL
{
    public class BusinessData
    {
        public BusinessDetailResponse GetBusinessDetailsById(Int32 bid)
        {
            DapperRepositry<BusinessDetailResponse> _repo = new DapperRepositry<BusinessDetailResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@BusinessId", bid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetBusinessDetailsById", param);
        }

        public List<BusinessListResponse> GetBusinessList(BusinessListParam p)
        {
            DapperRepositry<BusinessListResponse> _repo = new DapperRepositry<BusinessListResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@PageSize", p.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", p.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@str", p.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", p.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@BusinessId", p.BusinessId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetBusinessList", param);
        }
    }
}
