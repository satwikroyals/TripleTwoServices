using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTwo.Entities
{
    public class SupporterEntity
    {
    }
    public class SupporterDetailEntity
    {
        public string SupporterName { get; set; }
        public string SupporterImage { get; set; }
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

    public class SupporterDetailResponse
    {
        public long SupporterId { get; set; }
        public string SupporterName { get; set; }
        public string SupporterImage { get; set; }
        public string SupporterImagePath { get { return Settings.GetSupporterImage(this.SupporterId, this.SupporterImage); } }
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


    public class SupporterListParam : paggingEntity
    {
        public long SupporterId { get; set; }
    }
    public class SupporterListResponse
    {
        public long SupporterId { get; set; }
        public string SupporterName { get; set; }
        public string SupporterImage { get; set; }
        public string SupporterImagePath { get { return Settings.GetSupporterImage(this.SupporterId, this.SupporterImage); } }
        public string Location { get; set; }
    }
    public class SupporterListEntity
    {


        public int SupporterId { get; set; }
        public string SupporterName { get; set; }
        public Int32 SupporterTypeId { get; set; }
        public string SupporterImage { get; set; }
        public string SupporterImagePath { get { return Settings.GetSupporterImage(this.SupporterId, this.SupporterImage); } }
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
