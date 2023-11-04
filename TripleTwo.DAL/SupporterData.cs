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
    public class SupporterData
    {

        public SupporterDetailResponse GetSupporterDetailsById(Int32 bid)
        {
            DapperRepositry<SupporterDetailResponse> _repo = new DapperRepositry<SupporterDetailResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@SupporterId", bid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetSupporterDetailsById", param);
        }

        public List<SupporterListResponse> GetSupporterList(SupporterListParam p)
        {
            DapperRepositry<SupporterListResponse> _repo = new DapperRepositry<SupporterListResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@PageSize", p.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", p.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@str", p.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", p.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@SupporterId", p.SupporterId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetSupporterList", param);
        }

    }
}
