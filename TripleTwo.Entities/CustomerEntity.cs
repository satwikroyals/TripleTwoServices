using System;
using System.Collections.Generic;
using static TripleTwo.Entities.Settings;

namespace TripleTwo.Entities
{
    public class CustomerEntity
    {
        public Int64 CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string pin { get; set; }
        public string ProfilePic { get; set; }
        public string ProfilePicPath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.ProfilePic); } }

        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int Status { get; set; }

        public int TotalRecords { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string Statusstr { get { return Settings.SetStatus(this.Status); } }

        public string ModifiedDatestr => Settings.SetDateFormat(this.ModifiedDate);

    }

    public class CustomerSettingsParams
    {
        public Int64 CustomerId { get; set; }
        public bool ShowMood { get; set; }

        public bool ShowProfileToAll { get; set; }
        public bool ShowProfileToFriends { get; set; }
        public bool DoNotShowProfile { get; set; }

    }
    public class CustomerSettingsResponse : BaseResponse
    {

    }


    public class CustomerRegistrationParams
    {
        public long CountryId { get; set; }
        public long OrganisationTypeId { get; set; }

        public long OrganisationGroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Pin { get; set; }
    }

    public class CustomerNominees
    {
        
        public Int32 CustomerId { get; set; }
        public string NomineeMobile { get; set; }
        public string NomineeName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class CustomerNomineeParams
    {
       
        public string NomineeMobile { get; set; }
        public string NomineeName { get; set; }
        public Int32 CustomerId { get; set; }
    }

    public class CustomerProfileNomineesResponse
    {

        public string NomineeMobile { get; set; }
        public string NomineeName { get; set; }
    }
        public class CustomerComNomineeParams
    {

        public string NomineeMobile { get; set; }
        public string NomineeName { get; set; }
        public Int32 CustomerId { get; set; }
        public string EmailId { get; set; }
        public string DeviceId { get; set; }
        public int DeviceType { get; set; }
        public string AndroidPushKey { get; set; }
        public string IphonePushKey { get; set; }
    }

    public class MobileCheckParams
    {
        public string Mobile { get; set; }
    }
    public class CustomerRegisterResponse : BaseResponse
    {
    }
    public class MobileCheckResponse : BaseResponse
    {
    }
    public class CustomerNomineeResponse : BaseResponse
    {
    }
   
    public class CustomerLoginResponse : BaseResponse
    {
        public long CustomerId { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganisationTypeId { get; set; }
        public string OrgName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        
        public string ProfilePic { get; set; }
        public string ProfilePicPath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.ProfilePic); } }
    }

    public class CustomerProfileResponse
    {
        public long CustomerId { get; set; }
        public int NomineeCount { get; set; }

        public bool ShowMood { get; set; }
        public bool ShowProfileToAll { get; set; }
        public bool ShowProfileToFriends { get; set; }
        public bool DoNotShowProfile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganisationTypeId { get; set; }
        public string OrgName { get; set; }
         
        public List<CustomerProfileNomineesResponse> Nominees { get; set; }
        public string OrgGroupName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ProfilePic { get; set; }
        public string ProfilePicPath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.ProfilePic); } }
    }

    public class CustomerLoginParams
    {
        public string UserName { get; set; }
        public string Pin { get; set; }

        public string DeviceId { get; set; }
        public int DeviceType { get; set; }
    }


    public class CountryEntity
    {
        public Int32 CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class OrganisationType
    {
        public Int32 OrganisationTypeId { get; set; }
        public String OrgName { get; set; }
    }

    public class OrganisationGroups
    {
        public Int32 OrganisationGroupId { get; set; }
        public String GroupTitle { get; set; }
    }

}
