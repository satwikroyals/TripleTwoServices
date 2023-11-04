using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbFactory.Repositories;
using TripleTwo.Entities;
using DbFactory;
using System.Data;

namespace TripleTwo.DAL
{
    public class PartnersData
    {
        public List<PartnerEntity> GetPartners(paggingEntity es, Int32 orgid)
        {
            DapperRepositry<PartnerEntity> _repo = new DapperRepositry<PartnerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageSize", es.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", es.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@Searchstr", es.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", es.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@FromDate", es.FromDate, DbType.String, ParameterDirection.Input);
            param.Add("@ToDate", es.ToDate, DbType.String, ParameterDirection.Input);
            param.Add("@OrgId", orgid, DbType.Int32, ParameterDirection.Input);

            return _repo.GetList("GetPartners", param);
        }
        public PartnerEntity GetPartnerDetails(Int32 prtnrid)
        {
            DapperRepositry<PartnerEntity> _repo = new DapperRepositry<PartnerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", prtnrid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetPartnerDetails", param);
        }
        public List<PartnerImageEntity> GetPartnerImagesByPid(Int32 prtnrid)
        {
            DapperRepositry<PartnerImageEntity> _repo = new DapperRepositry<PartnerImageEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", prtnrid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetPartnerImagesByPId", param);
        }
        //public StatusResponse AddPartner(PartnerEntity pEntity)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@PartnerId", pEntity.PartnerId, DbType.Int64, ParameterDirection.Input);
        //    param.Add("@OrgId", pEntity.OrgId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@PartnerName", pEntity.PartnerName, DbType.String, ParameterDirection.Input);
        //    param.Add("@Logo", pEntity.Logo, DbType.String, ParameterDirection.Input);
        //    //param.Add("@Images", pEntity.Images, DbType.String, ParameterDirection.Input);
        //    param.Add("@EmailId", pEntity.EmailId, DbType.String, ParameterDirection.Input);
        //    param.Add("@Username", pEntity.Username, DbType.String, ParameterDirection.Input);
        //    param.Add("@Password", pEntity.Password, DbType.String, ParameterDirection.Input);
        //    param.Add("@Phone", pEntity.Phone, DbType.String, ParameterDirection.Input);
        //    param.Add("@CountryId", pEntity.CountryId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@StateId", pEntity.StateId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@City", pEntity.CityName, DbType.String, ParameterDirection.Input);
        //    param.Add("@Website", pEntity.Website, DbType.String, ParameterDirection.Input);
        //    param.Add("@Description", pEntity.Description, DbType.String, ParameterDirection.Input);
        //    param.Add("@Mission", pEntity.Mission, DbType.String, ParameterDirection.Input);
        //    param.Add("@PartnerTypeId", pEntity.PartnerTypeId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@LiveSrtreaming", pEntity.LiveStreaming, DbType.String, ParameterDirection.Input);
        //    param.Add("@MediaTypeId", pEntity.MediaTypeId, DbType.String, ParameterDirection.Input);
        //    param.Add("@Status", pEntity.Status, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@Location", pEntity.Location, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("AddPartner", param);
        //}
        public PartnerEntity CheckPartnerLogin(string un, string pwd)
        {
            DapperRepositry<PartnerEntity> _repo = new DapperRepositry<PartnerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserName", un, DbType.String, ParameterDirection.Input);
            param.Add("@Password", pwd, DbType.String, ParameterDirection.Input);
            return _repo.GetResult("CheckPartnerLogin", param);
        }
        public List<PartnerTypeddl> GetPartnerTypesddl()
        {
            DapperRepositry<PartnerTypeddl> _repo = new DapperRepositry<PartnerTypeddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            return _repo.GetList("GetPartnerTypeddl", param);
        }
        public List<PartnerEntity> GetPartnersByOrg(Int64 orgid)
        {
            DapperRepositry<PartnerEntity> _repo = new DapperRepositry<PartnerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", orgid, DbType.Int32, ParameterDirection.Input);

            return _repo.GetList("GetPartnersByOrg", param);
        }
        public List<PartnerSocilaMediaLinksEntity> GetPartnerSocialMediaLinks(Int64 Pid)
        {
            DapperRepositry<PartnerSocilaMediaLinksEntity> _repo = new DapperRepositry<PartnerSocilaMediaLinksEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", Pid, DbType.Int32, ParameterDirection.Input);

            return _repo.GetList("GetPartnerSocialMediaLinks", param);
        }
        public PartnerEntity DeletePartner(Int32 pid)
        {
            DapperRepositry<PartnerEntity> _repo = new DapperRepositry<PartnerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PartnerId", pid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("DeletePartner", param);
        }
    }
}
