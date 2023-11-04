using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;
using TripleTwo.DAL;

namespace TripleTwo.BAL
{
    public class OrganizationManager
    {
        private Organizationdata objorg = new Organizationdata();
        public OrgEntity CheckOrgLogin(string un, string pw)
        {
            return objorg.CheckOrgLogin(un, pw);
        }
        public LoginbgEntity GetOrgLoginTheme(string id)
        {
            return objorg.GetOrgLoginTheme(id);
        }
        public LoginbgEntity GetOrgById(Int32 orgid)
        {
            return objorg.GetOrgById(orgid);
        }
        public List<Organizationddl> GetOrganizationddl()
        {
            return objorg.GetOrganizationddl();
        }
        public List<OrgEntity> GetOrganizations(paggingEntity es)
        {
            return objorg.GetOrganizations(es);
        }
        //public StatusResponse AddOrganization(OrgEntity oEntity)
        //{
        //    return objorg.AddOrganization(oEntity);
        //}
        public List<Organizationddl> GetOrganizationTypes()
        {
            return objorg.GetOrganizationTypes();
        }
        public List<ClientLinkEntity> GetOrgMenuLinks(Int32 clId)
        {
            return objorg.GetOrgClientLinks(clId);
        }
        public List<ClientLinkEntity> GetOrgClientLinks(Int32 linkId)
        {
            List<ClientLinkEntity> cl = new List<ClientLinkEntity>();
            cl = objorg.GetOrgClientSubLinks(linkId);
            foreach (ClientLinkEntity cle in cl)
            {
                cle.SubLink = objorg.GetOrgClientSubLinks(cle.LinkId).ToList();
            }
            return cl;
        }
    }
}
