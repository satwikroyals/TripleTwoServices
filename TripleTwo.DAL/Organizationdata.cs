using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbFactory.Repositories;
using TripleTwo.Entities;
//using TripleTwo.Entities.Domain;
using DbFactory;
using System.Data;

namespace TripleTwo.DAL
{
    public class Organizationdata
    {
        public OrgEntity CheckOrgLogin(string un, string pwd)
        {
            DapperRepositry<OrgEntity> _repo = new DapperRepositry<OrgEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserName", un, DbType.String, ParameterDirection.Input);
            param.Add("@Password", pwd, DbType.String, ParameterDirection.Input);
            return _repo.GetResult("CheckOrgLogin", param);
        }
        /// <summary>
        /// Get Login page colors and images by tag id
        /// </summary>
        /// <param name="id">loginstring</param>
        /// <returns></returns>
        public LoginbgEntity GetOrgLoginTheme(string id)
        {
            DbFactory.DbSettings _db = new DbFactory.DbSettings(Settings.ProviederName, Settings.DbConnection);
            LoginbgEntity _repo = new LoginbgEntity();
            DynamicParameters param = new DynamicParameters();
            param.Add("@Loginstring", id, DbType.String, ParameterDirection.Input);
            using (IDbConnection db = (IDbConnection)_db.ConnectionString)
            {
                var result = db.QueryMultiple("GetOrganizationLoginTheme", commandType: CommandType.StoredProcedure, param: param);
                _repo.LoginDetails = result.Read<OrgEntity>().FirstOrDefault();
                var resImagedetails = result.Read<LoginbgimageEntity>().ToList();
                _repo.Images = resImagedetails;
            }
            return _repo;
        }
        /// <summary>
        /// get organisations details by id
        /// </summary>
        /// <param name="orgid">organisationid</param>
        /// <returns></returns>
        public LoginbgEntity GetOrgById(Int32 orgid)
        {
            DbFactory.DbSettings _db = new DbFactory.DbSettings(Settings.ProviederName, Settings.DbConnection);
            LoginbgEntity _repo = new LoginbgEntity();
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", orgid, DbType.Int32, ParameterDirection.Input);
            using (IDbConnection db = (IDbConnection)_db.ConnectionString)
            {
                var result = db.QueryMultiple("GetOrgById", commandType: CommandType.StoredProcedure, param: param);
                _repo.LoginDetails = result.Read<OrgEntity>().FirstOrDefault();
                var resImagedetails = result.Read<LoginbgimageEntity>().ToList();
                _repo.Images = resImagedetails;
            }
            return _repo;
        }
        /// <summary>
        /// get organisations dropdown list
        /// </summary>
        /// <returns></returns>
        public List<Organizationddl> GetOrganizationddl()
        {
            DapperRepositry<Organizationddl> _repo = new DapperRepositry<Organizationddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            return _repo.GetList("GetOrganisationsddl", param);
        }
        /// <summary>
        /// Get organization list for super admin panel
        /// </summary>
        /// <returns></returns>
        public List<OrgEntity> GetOrganizations(paggingEntity es)
        {
            DapperRepositry<OrgEntity> _repo = new DapperRepositry<OrgEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageSize", es.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", es.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@Searchstr", es.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", es.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@FromDate", es.FromDate, DbType.String, ParameterDirection.Input);
            param.Add("@ToDate", es.ToDate, DbType.String, ParameterDirection.Input);
            return _repo.GetList("GetOrganizations", param);
        }
        /// <summary>
        /// Add organization
        /// </summary>
        /// <returns></returns>
        //public StatusResponse AddOrganization(OrgEntity oEntity)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@OrgId", oEntity.OrgId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@ComunionId", oEntity.ComunionId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@OrgTypeId", oEntity.OrgTypeId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@OrgName", oEntity.OrgName, DbType.String, ParameterDirection.Input);
        //    param.Add("@OrganizerName", oEntity.OrganizerName, DbType.String, ParameterDirection.Input);
        //    param.Add("@EmailId", oEntity.EmailId, DbType.String, ParameterDirection.Input);
        //    param.Add("@Phone", oEntity.Phone, DbType.String, ParameterDirection.Input);
        //    param.Add("@UserName", oEntity.UserName, DbType.String, ParameterDirection.Input);
        //    param.Add("@Password", oEntity.Password, DbType.String, ParameterDirection.Input);
        //    param.Add("@Logo", oEntity.Logo, DbType.String, ParameterDirection.Input);
        //    param.Add("@Website", oEntity.Website, DbType.String, ParameterDirection.Input);
        //    param.Add("@Description", oEntity.Description, DbType.String, ParameterDirection.Input);
        //    param.Add("@Address", oEntity.Address, DbType.String, ParameterDirection.Input);
        //    param.Add("@CountryId", oEntity.CountryId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@StateId", oEntity.StateId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@City", oEntity.City, DbType.String, ParameterDirection.Input);
        //    param.Add("@Postcode", oEntity.Postcode, DbType.String, ParameterDirection.Input);
        //    param.Add("@BackgroundImage", oEntity.BackgroundImage, DbType.String, ParameterDirection.Input);
        //    param.Add("@BannerImage", oEntity.BannerImage, DbType.String, ParameterDirection.Input);
        //    param.Add("@Primarycolor", oEntity.Primarycolor, DbType.String, ParameterDirection.Input);
        //    param.Add("@Secondarycolor", oEntity.Secondarycolor, DbType.String, ParameterDirection.Input);
        //    param.Add("@Thirdcolor", oEntity.Thirdcolor, DbType.String, ParameterDirection.Input);
        //    param.Add("@Textcolor", oEntity.Textcolor, DbType.String, ParameterDirection.Input);
        //    param.Add("@MenuBgImage", oEntity.MenuBackImage, DbType.String, ParameterDirection.Input);
        //    param.Add("@Loginstring", oEntity.Loginstring, DbType.String, ParameterDirection.Input);
        //    param.Add("@Logbgimg", oEntity.Logbgimg, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("AddOrganization", param);
        //}
        /// <summary>
        /// Add organization type dropdown list
        /// </summary>
        /// <returns></returns>
        public List<Organizationddl> GetOrganizationTypes()
        {
            DapperRepositry<Organizationddl> _repo = new DapperRepositry<Organizationddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            return _repo.GetList("GetOrganizationTypeddl", param);
        }
        public List<ClientLinkEntity> GetOrgClientLinks(Int32 clId)
        {
            DapperRepositry<ClientLinkEntity> _repo = new DapperRepositry<ClientLinkEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", clId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetOrgClientLinks", param);
        }
        public List<ClientLinkEntity> GetOrgClientSubLinks(Int32 linkId)
        {
            DapperRepositry<ClientLinkEntity> _repo = new DapperRepositry<ClientLinkEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@LinkId", linkId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetOrgClientSubLinks", param);
        }
    }
}
