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
    public class SponsorData
    {

        public SponsorDetailResponse GetSponsorDetailsById(Int32 bid)
        {
            DapperRepositry<SponsorDetailResponse> _repo = new DapperRepositry<SponsorDetailResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@SponsorId", bid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetSponsorDetailsById", param);
        }

        public List<SponsorListResponse> GetSponsorList(SponsorListParam p)
        {
            DapperRepositry<SponsorListResponse> _repo = new DapperRepositry<SponsorListResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@PageSize", p.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", p.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@str", p.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", p.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@SponsorId", p.SponsorId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetSponsorList", param);
        }

    }
}
