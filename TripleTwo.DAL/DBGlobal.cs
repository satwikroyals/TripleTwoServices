using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DbFactory;
using DbFactory.Repositories;
using System.Data;
using TripleTwo.Entities;

namespace TripleTwo.DAL
{
    public class DBGlobal
    {
        //Settings db = new Settings();

        /// <summary>
        /// Returns admin database connection.
        /// </summary>
        public static DbSettings DbAdminRepositrySettings
        {
            get
            {
                return new DbSettings(Settings.ProviederName, Settings.DbConnection);
            }
        }

        // Admin stored procedures prefix.
        public static string SpAdminPrefix = "GTC_";

        // Client stored procedures prefix.
        public static string SpClientPrefix = "GTC_";

        /// <summary>
        /// Returns client database connection.
        /// </summary>
        public DbSettings DbClientRepositrySettings(Int32 clientId)
        {
            Dictionary<string, string> clientDbInfo = this.GetClientDbInfo(clientId);
            if (clientDbInfo != null)
            {
                return new DbSettings(clientDbInfo["DBProviderType"], Settings.SetDbConnectionStringFormat(clientDbInfo));
            }
            else
                return null;
        }

        /// <summary>
        /// Get client database information.
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns>Client database information</returns>
        protected Dictionary<string, string> GetClientDbInfo(Int32? clientId)
        {
            try
            {
                Dictionary<string, string> clientDataBase = null;
                DbSettings DbRepositrySettings = DbAdminRepositrySettings;
                DbRepository repo = DbRepositrySettings.GetDbRepositry;
                IDbDataParameter[] pc = new[] { repo.CreateParameterWithValue("@ClientId", clientId) };
                DataTable result = repo.GetDataTableByReader(SpAdminPrefix + "Get_ClientDBInfo", pc);                //Get client database information from database by clientid.  
                if (result != null && result.Rows.Count == 1)
                {
                    var row = result.Rows[0];
                    clientDataBase = new Dictionary<string, string>();
                    clientDataBase.Add("DBServerUrl", Convert.ToString(row["DBServerUrl"]));
                    clientDataBase.Add("DBUsername", Convert.ToString(row["DBUsername"]));
                    clientDataBase.Add("DBPassword", Convert.ToString(row["DBPassword"]));
                    clientDataBase.Add("DBName", Convert.ToString(row["DBName"]));
                    clientDataBase.Add("DBProviderType", Convert.ToString(row["DBProviderType"]));
                }
                return clientDataBase;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
