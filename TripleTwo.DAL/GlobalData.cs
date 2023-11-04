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
    public class GlobalData
    {

        public List<CountryEntity> GetCountries(Int32 couid)
        {
            DapperRepositry<CountryEntity> _repo = new DapperRepositry<CountryEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountryId", couid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetCountries", param);

        }

        public List<OrganisationGroups> GetOrganisationGroups(int orgid)
        {
            DapperRepositry<OrganisationGroups> _repo = new DapperRepositry<OrganisationGroups>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrganisationTypeId", orgid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetOrganisationGroups", param);
        }

        public List<OrganisationType> GetOrganisationTypes(Int32 orgid)
        {
            DapperRepositry<OrganisationType> _repo = new DapperRepositry<OrganisationType>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrganisationTypeId", orgid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetOrganisationTypes", param);

        }

    }
}
