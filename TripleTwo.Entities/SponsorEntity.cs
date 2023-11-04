using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTwo.Entities
{
    public class SponsorEntity
    {


    }

    public class SponsorDetailEntity
    {
        public string SponsorName { get; set; }
        public string SponsorImage { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactName
        {
            get { return ContactFirstName + " " + ContactLastName; }
        }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public string OtherInfo { get; set; }
        public string WebSiteUrl { get; set; }
    }

    public class SponsorDetailResponse
    {
        public long SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string SponsorImage { get; set; }
        public string SponsorImagePath { get { return Settings.GetSponsorImage(this.SponsorId, this.SponsorImage); } }
        //public string ContactFirstName { get; set; }
        //public string ContactLastName { get; set; }
        //public string ContactName
        //{
        //    get { return ContactFirstName + " " + ContactLastName; }
        //}
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public string OtherInfo { get; set; }
        //public string WebSiteUrl { get; set; }
    }


    public class SponsorListParam : paggingEntity
    {
        public int SponsorId { get; set; }
    }
    public class SponsorListResponse
    {
        public long SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string SponsorImage { get; set; }
        public string SponsorImagePath { get { return Settings.GetSponsorImage(this.SponsorId, this.SponsorImage); } }
        public string Location { get; set; }
    }
    public class SponsorListEntity
    {


        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public Int32 SponsorTypeId { get; set; }
        public string SponsorImage { get; set; }
        public string SponsorImagePath { get { return Settings.GetSponsorImage(this.SponsorId, this.SponsorImage); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }

}
