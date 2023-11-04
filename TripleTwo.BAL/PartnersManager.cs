using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class PartnersManager
    {
        private PartnersData objpatner = new PartnersData();
        public List<PartnerEntity> GetPartners(paggingEntity es, Int32 orgid)
        {
            return objpatner.GetPartners(es, orgid);
        }
        public PartnerEntity GetPartnerDetails(Int32 partnrid)
        {
            PartnerEntity pe = new PartnerEntity();
            pe = objpatner.GetPartnerDetails(partnrid);
            pe.SocilaMediaLinks = objpatner.GetPartnerSocialMediaLinks(partnrid);
            return pe;
        }
        public List<PartnerImageEntity> GetPartnerImagesByPid(Int32 prtnrid)
        {
            return objpatner.GetPartnerImagesByPid(prtnrid);
        }
        //public StatusResponse AddPartner(PartnerEntity pEntity)
        //{
        //    return objpatner.AddPartner(pEntity);
        //}
        public PartnerEntity CheckPartnerLogin(string un, string pwd)
        {
            return objpatner.CheckPartnerLogin(un, pwd);
        }
        public List<PartnerTypeddl> GetPartnerTypesddl()
        {
            return objpatner.GetPartnerTypesddl();
        }
        public List<PartnerEntity> GetPartnersByOrg(Int64 orgid)
        {
            List<PartnerEntity> pel = new List<PartnerEntity>();
            pel = objpatner.GetPartnersByOrg(orgid);
            foreach (PartnerEntity pe in pel)
            {
                pe.SocilaMediaLinks = objpatner.GetPartnerSocialMediaLinks(pe.PartnerId);
            }
            return pel;
        }
        public PartnerEntity DeletePartner(Int32 pid)
        {
            return objpatner.DeletePartner(pid);
        }
    }
}
