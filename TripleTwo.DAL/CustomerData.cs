using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;
using Dapper;
using DbFactory.Repositories;
using DbFactory;
using System.Data;
namespace TripleTwo.DAL
{
    public class CustomerData : DBGlobal
    {


       

        #region DropDowns
        public List<Countryddl> GetCountries()
        {
            DapperRepositry<Countryddl> _repo = new DapperRepositry<Countryddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            return _repo.GetList("GetCountryddl", param);
        }
        public List<Cityddl> GetCitybyCountryId(int cnid)
        {
            DapperRepositry<Cityddl> _repo = new DapperRepositry<Cityddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountryId", cnid, DbType.Int16, ParameterDirection.Input);
            return _repo.GetList("GetCityddlbyCountryId", param);
        }

        

        public List<Stateddl> GetStatebyCountryId(int cnid)
        {
            DapperRepositry<Stateddl> _repo = new DapperRepositry<Stateddl>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountryId", cnid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetStateddlbyCountryId", param);
        }

        public List<CustomerComNomineeParams> GetCustomerNominees(CustomerMoodParamsEntity p)
        {
            DapperRepositry<CustomerComNomineeParams> _repo = new DapperRepositry<CustomerComNomineeParams>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", p.CustomerId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetCustomerNominees", param);
        }

        public List<CustomerProfileNomineesResponse> GetCustomerProfileNominees(CustomerMoodParamsEntity p)
        {
            DapperRepositry<CustomerProfileNomineesResponse> _repo = new DapperRepositry<CustomerProfileNomineesResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", p.CustomerId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetCustomerNominees", param);
        }

        public AddUpdateCustomerResponse AddUpdateCustomer(AddUpdateCustomerParams p)
        {
            DapperRepositry<AddUpdateCustomerResponse> _repo = new DapperRepositry<AddUpdateCustomerResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", p.CustomerId, DbType.Int64, ParameterDirection.Input);
            param.Add("@Email", p.Email, DbType.String, ParameterDirection.Input);
            param.Add("@FirstName", p.FirstName, DbType.String, ParameterDirection.Input);
            param.Add("@LastName", p.LastName, DbType.String, ParameterDirection.Input);
            param.Add("@Mobile", p.Mobile, DbType.String, ParameterDirection.Input);
            param.Add("@Pin", p.pin, DbType.String, ParameterDirection.Input);
            param.Add("@PostCode", p.PostCode, DbType.String, ParameterDirection.Input);
            param.Add("@Status", p.Status, DbType.Int64, ParameterDirection.Input);
            return _repo.GetResult("AddUpdateCustomer", param);
        }

        #endregion

        #region CustomerProfile
        //public StatusResponse CustomerRegistration(CustomerEntity cEntity)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@OrgId", cEntity.orgid, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@FirstName", cEntity.fname, DbType.String, ParameterDirection.Input);
        //    param.Add("@LastName", cEntity.lname, DbType.String, ParameterDirection.Input);
        //    param.Add("@Mobile", cEntity.Mobile, DbType.String, ParameterDirection.Input);
        //    param.Add("@EmailId", cEntity.EmailId, DbType.String, ParameterDirection.Input);
        //    param.Add("@Password", cEntity.Password, DbType.String, ParameterDirection.Input);
        //    param.Add("@CountryId", cEntity.CountryId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@CityId", cEntity.CityId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@IsCmtMember", cEntity.IsCmtMember, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@ContactNumber1", cEntity.ContactNumber1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ContactName1", cEntity.ContactName1, DbType.String, ParameterDirection.Input);
        //    param.Add("@Contact1CountryId", cEntity.Contact1CountryId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@ContactNumber2", cEntity.ContactNumber2, DbType.String, ParameterDirection.Input);
        //    param.Add("@ContactName2", cEntity.ContactName2, DbType.String, ParameterDirection.Input);
        //    param.Add("@Contact2CountryId", cEntity.Contact2CountryId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@ProfessionalContactNumber1", cEntity.ProfessionalContactNumber1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContactName1", cEntity.ProfessionalContactName1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContact1Designation", cEntity.ProfessionalContact1Designation, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContact1CountryId", cEntity.ProfessionalContact1CountryId, DbType.Int32, ParameterDirection.Input);
        //    return _repo.GetResult("CustomerRegistration", param);
        //}

        public CustomerRegisterResponse RegisterCustomer(CustomerRegistrationParams p)
        {
            DapperRepositry<CustomerRegisterResponse> _repo = new DapperRepositry<CustomerRegisterResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountryId", p.CountryId, DbType.Int32, ParameterDirection.Input);
            param.Add("@OrganisationTypeId", p.OrganisationTypeId, DbType.Int32, ParameterDirection.Input);
            param.Add("@OrganisationGroupId", p.OrganisationGroupId, DbType.Int32, ParameterDirection.Input);
            param.Add("@FirstName", p.FirstName, DbType.String, ParameterDirection.Input);
            param.Add("@LastName", p.LastName, DbType.String, ParameterDirection.Input);
            param.Add("@Email", p.Email, DbType.String, ParameterDirection.Input);
            param.Add("@Mobile", p.Mobile, DbType.String, ParameterDirection.Input);
            param.Add("@Pin", p.Pin, DbType.String, ParameterDirection.Input);
            return _repo.GetResult("RegisterCustomer", param);
        }

        public CustomerLoginResponse CustomerLogin(CustomerLoginParams p)
        {
            DapperRepositry<CustomerLoginResponse> _repo = new DapperRepositry<CustomerLoginResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserName", p.UserName, DbType.String, ParameterDirection.Input);
            param.Add("@Pin", p.Pin, DbType.String, ParameterDirection.Input);
            param.Add("@DeviceId", p.DeviceId, DbType.String, ParameterDirection.Input);
            param.Add("@App", p.DeviceType, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("CustomerLogin", param);
        }
        public CustomerNomineeResponse AddCustomerNominees(CustomerNomineeParams p)
        {
            DapperRepositry<CustomerNomineeResponse> _repo = new DapperRepositry<CustomerNomineeResponse>(Settings.ProviederName, Settings.DbConnection);

            var param = new DynamicParameters();
            param.Add("@CustomerId", p.CustomerId, DbType.Int32, ParameterDirection.Input);
            param.Add("@NomineeName", p.NomineeName, DbType.String, ParameterDirection.Input);
            param.Add("@NomineeMobile", p.NomineeMobile, DbType.String, ParameterDirection.Input);
            return _repo.GetResult("AddCustomerNominees", param);
        }

        public CustomerNomineeResponse SetCustomerMood(CustomerMoodParamsEntity p)
        {
            DapperRepositry<CustomerNomineeResponse> _repo = new DapperRepositry<CustomerNomineeResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@CustomerId", p.CustomerId, DbType.Int32, ParameterDirection.Input);
            param.Add("@MoodId", p.MoodId, DbType.Int16, ParameterDirection.Input);
            param.Add("@Latitude", p.Latitude, DbType.String, ParameterDirection.Input);
            param.Add("@Longitude", p.Longitude, DbType.String, ParameterDirection.Input);
            param.Add("@Location", p.Location, DbType.String, ParameterDirection.Input);

            return _repo.GetResult("SetCustomerMood", param);
        }

        public CustomerEntity CustomerLogin(Int32 oid, string username, string password, string deviceid, int apptype)
        {
            DapperRepositry<CustomerEntity> _repo = new DapperRepositry<CustomerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", oid, DbType.Int32, ParameterDirection.Input);
            param.Add("@UserName", username, DbType.String, ParameterDirection.Input);
            param.Add("@Password", password, DbType.String, ParameterDirection.Input);
            param.Add("@DeviceId", deviceid, DbType.String, ParameterDirection.Input);
            param.Add("@App", apptype, DbType.Int16, ParameterDirection.Input);
            return _repo.GetResult("GetCustomerLogin", param);
        }
        public CustomerEntity GetCustomerDetailsById(Int32 cid)
        {
            DapperRepositry<CustomerEntity> _repo = new DapperRepositry<CustomerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetCustomerDetails", param);
        }


        public MobileCheckResponse VerifyCustomerMobile(string mob)
        {
            DapperRepositry<MobileCheckResponse> _repo = new DapperRepositry<MobileCheckResponse>(Settings.ProviederName, Settings.DbConnection);

            var parm = new DynamicParameters();

            parm.Add("@Mobile", mob, DbType.String, ParameterDirection.Input);

            return _repo.GetResult("VerifyCustomerMobile", parm);
        }

        public CustomerMoodResponse GetCustomerMood(Int32 cid)
        {
            DapperRepositry<CustomerMoodResponse> _repo = new DapperRepositry<CustomerMoodResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetCustomerMood", param);
        }

        public List<CustomerMoodContacts> GetCustomerMoodContacts(Int32 cid)
        {
            DapperRepositry<CustomerMoodContacts> _repo = new DapperRepositry<CustomerMoodContacts>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetCustomerMoodContacts", param);
        }

        //public StatusResponse UpdateCustomer(CustomerEntity cEntity)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@OrgId", cEntity.orgid, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@CustomerId", cEntity.CustomerId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@FirstName", cEntity.fname, DbType.String, ParameterDirection.Input);
        //    param.Add("@LastName", cEntity.lname, DbType.String, ParameterDirection.Input);
        //    param.Add("@Mobile", cEntity.Mobile, DbType.String, ParameterDirection.Input);
        //    param.Add("@EmailId", cEntity.EmailId, DbType.String, ParameterDirection.Input);
        //    param.Add("@CountryId", cEntity.CountryId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@CityId", cEntity.CityId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@Profession", cEntity.Profession, DbType.String, ParameterDirection.Input);
        //    param.Add("@Ministry", cEntity.Ministry, DbType.String, ParameterDirection.Input);
        //    param.Add("@CustomerImage", cEntity.CustomerImage, DbType.String, ParameterDirection.Input);
        //    param.Add("@ReferrerName", cEntity.ReferrerName, DbType.String, ParameterDirection.Input);
        //    param.Add("@SalvationInfo", cEntity.SalvationInfo, DbType.String, ParameterDirection.Input);
        //      param.Add("@ContactNumber1", cEntity.ContactNumber1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ContactName1", cEntity.ContactName1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ContactNumber2", cEntity.ContactNumber2, DbType.String, ParameterDirection.Input);
        //    param.Add("@ContactName2", cEntity.ContactName2, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContactNumber1", cEntity.ProfessionalContactNumber1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContactName1", cEntity.ProfessionalContactName1, DbType.String, ParameterDirection.Input);
        //    param.Add("@ProfessionalContact1Designation", cEntity.ProfessionalContact1Designation, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("UpdateCustomerDetails", param);
        //}
        public List<CustomerEntity> GetCustomerList(paggingCustomerEntity ps)
        {
            DapperRepositry<CustomerEntity> _repo = new DapperRepositry<CustomerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageSize", ps.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", ps.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@SearchMemberstr", ps.SearchMemberstr, DbType.String, ParameterDirection.Input);
            param.Add("@SearchEmailstr", ps.SearchEmailstr, DbType.String, ParameterDirection.Input);
            param.Add("@SearchMobilestr", ps.SearchMobilestr, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", ps.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@FromDate", ps.FromDate, DbType.String, ParameterDirection.Input);
            param.Add("@ToDate", ps.ToDate, DbType.String, ParameterDirection.Input);
            
            return _repo.GetList("GetCustomersList", param);
        }
        #endregion

        
        //public StatusResponse InsertCommunication(CommunicationEntity ce)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@CommunicationId", ce.CommunicationId, DbType.Int64, ParameterDirection.Input);
        //    param.Add("@OrgId", ce.OrgId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@FromId", ce.FromId, DbType.Int64, ParameterDirection.Input);
        //    param.Add("@FromType", ce.FromType, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@ToIds", ce.ToIds, DbType.String, ParameterDirection.Input);
        //    param.Add("@ToType", ce.ToType, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@SessionId", ce.SessionId, DbType.String, ParameterDirection.Input);
        //    param.Add("@Message", ce.Message, DbType.String, ParameterDirection.Input);
        //    param.Add("@LiveStream", ce.LiveStream, DbType.String, ParameterDirection.Input);
        //    param.Add("@IsLiveStream", ce.IsLiveStream, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@CommunicationTypeId", ce.CommunicationTypeId, DbType.Int16, ParameterDirection.Input);
        //    param.Add("@MarketingTypeId", ce.MarketingTypeId, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@MarketingItemId", ce.MarketingItemId, DbType.Int64, ParameterDirection.Input);
        //    param.Add("@ReceipentCount", ce.ReceipentCount, DbType.Int32, ParameterDirection.Input);
        //    param.Add("@TemplateId", ce.TemplateId, DbType.String, ParameterDirection.Input);
        //    param.Add("@IsCommericial", ce.IsCommericial, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("InsertCommunication", param);
        //}
        public List<CommunicationEntity> GetCommunicationByFromId(paggingEntity ps, Int64 fromid, int fromtype)
        {
            DapperRepositry<CommunicationEntity> _repo = new DapperRepositry<CommunicationEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageSize", ps.pgsize, DbType.Int16, ParameterDirection.Input);
            param.Add("@PageIndex", ps.pgindex, DbType.Int16, ParameterDirection.Input);
            param.Add("@Searchstr", ps.str, DbType.String, ParameterDirection.Input);
            param.Add("@SortBy", ps.sortby, DbType.Int16, ParameterDirection.Input);
            param.Add("@FromDate", ps.FromDate, DbType.String, ParameterDirection.Input);
            param.Add("@ToDate", ps.ToDate, DbType.String, ParameterDirection.Input);
            param.Add("@FromId", fromid, DbType.Int32, ParameterDirection.Input);
            param.Add("@FromType", fromtype, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetCommunicationsByFrom", param);
        }
        public CommunicationEntity GetCommunicationId(Int64 id)
        {
            DapperRepositry<CommunicationEntity> _repo = new DapperRepositry<CommunicationEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CommunicationId", id, DbType.Int64, ParameterDirection.Input);

            return _repo.GetResult("GetCommunicationById", param);
        }
        public List<CustomerEntity> GetAllCustomerIds(Int32 orgid)
        {
            DapperRepositry<CustomerEntity> _repo = new DapperRepositry<CustomerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@OrgId", orgid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetAllCustomerIds", param);
        }
        public List<CustomerEntity> GetCommunicationSelectedMembers(string ids)
        {
            DapperRepositry<CustomerEntity> _repo = new DapperRepositry<CustomerEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@Ids", ids, DbType.String, ParameterDirection.Input);
            return _repo.GetList("GetCommunicationSelectedMembers", param);
        }
        public AddOrRemoveFriendResponse AddOrRemoveFriend(AddOrRemoveFriendParam p)
        {
            DapperRepositry<AddOrRemoveFriendResponse> _repo = new DapperRepositry<AddOrRemoveFriendResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@CustomerId", p.CustomerId, DbType.Int64, ParameterDirection.Input);

            param.Add("@FriendCustomerId", p.CustomerFriendId, DbType.Int64, ParameterDirection.Input);

            param.Add("@Action", p.Action, DbType.Int16, ParameterDirection.Input);
            return _repo.GetResult("AddRemoveCustomerFriend", param);
        }
        public List<GetCustomerFriendsResponse> GetCustomerFriends(Int64 cid, int status, string srchname)
        {
            DapperRepositry<GetCustomerFriendsResponse> _repo = new DapperRepositry<GetCustomerFriendsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@CustomerId", cid, DbType.Int64, ParameterDirection.Input);
            param.Add("@Status", status, DbType.Int16, ParameterDirection.Input);
            param.Add("@SearchName", srchname, DbType.String, ParameterDirection.Input);
            return _repo.GetList("GetCustomerFriends", param);
        }
        public List<CustomerFriendEntity> GetCustomerSocialMembers(Int64 cid)
        {
            DapperRepositry<CustomerFriendEntity> _repo = new DapperRepositry<CustomerFriendEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@CustomerId", cid, DbType.Int64, ParameterDirection.Input);
            return _repo.GetList("GetALLSocialMembers", param);
        }
        public List<CustomerFriendEntity> GetFriendsByGroup(Int64 cgid)
        {
            DapperRepositry<CustomerFriendEntity> _repo = new DapperRepositry<CustomerFriendEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();

            param.Add("@GroupId", cgid, DbType.Int64, ParameterDirection.Input);
            return _repo.GetList("GetCustomersByGroupId", param);
        }
        //public StatusResponse CreateCustomerGroup(Int64 cid,string grpname,string members)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();

        //    param.Add("@CustomerId", cid, DbType.Int64, ParameterDirection.Input);
        //    param.Add("@GroupName", grpname, DbType.String, ParameterDirection.Input);
        //    param.Add("@GroupMembers", members, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("CreateCustomerGroup", param);
        //}
        //public StatusResponse AddorRemoveGroupMembers(Int64 cgid,string members,int IsRemove)
        //{
        //    DapperRepositry<StatusResponse> _repo = new DapperRepositry<StatusResponse>(Settings.ProviederName, Settings.DbConnection);
        //    DynamicParameters param = new DynamicParameters();

        //    param.Add("@GroupId", cgid, DbType.Int64, ParameterDirection.Input);
            
        //    param.Add("@GroupMembers", members, DbType.String, ParameterDirection.Input);
        //    param.Add("@IsRemove", IsRemove, DbType.String, ParameterDirection.Input);
        //    return _repo.GetResult("AddorRemoveGroupMembers", param);
        //}
        public List<CustomerGroupsEntity> GetCustomerChatGroups(Int32 cid)
        {
            DapperRepositry<CustomerGroupsEntity> _repo = new DapperRepositry<CustomerGroupsEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);

            return _repo.GetList("GetCustomerChatGroups", param);
        }

      

        public List<CustomerMoodContacts> GetMoodContacts(Int32 cid)
        {
            DapperRepositry<CustomerMoodContacts> _repo = new DapperRepositry<CustomerMoodContacts>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);

            return _repo.GetList("GetMoodContacts", param);
        }

        public List<string> GetMoodContactsNotRegisterCustomers(Int32 cid,string moodcontacts)
        {
            DapperRepositry<string> _repo = new DapperRepositry<string>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            param.Add("@moodContacts", moodcontacts, DbType.String, ParameterDirection.Input);
            return _repo.GetList("GetMoodContactsNotRegisterCustomers", param);
        }



        public CustomerProfileResponse GetCustomerProfile(Int64 cid)
        {
            DapperRepositry<CustomerProfileResponse> _repo = new DapperRepositry<CustomerProfileResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetAllCustomers", param);
        }


        public List<CustomerFriendEntity> GetSocial(Int32 cid, Int32 oid, int status, string SearchName)
        {
            DapperRepositry<CustomerFriendEntity> _repo = new DapperRepositry<CustomerFriendEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            param.Add("@Status", status, DbType.Int16, ParameterDirection.Input);
            param.Add("@SearchName", SearchName, DbType.String, ParameterDirection.Input);
            // param.Add("@OrganisationId", oid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetALLSocialMembers", param);
        }

        public List<CustomerMoodNotSetEntity> GetCustomersMoodNotSet()
        {
            DapperRepositry<CustomerMoodNotSetEntity> _repo = new DapperRepositry<CustomerMoodNotSetEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            return _repo.GetList("GetCustomersMoodNotSet", param);
        }

        public CustomerSettingsResponse UpdateCustomerProfileSettings(CustomerSettingsParams cs)
        {
            DapperRepositry<CustomerSettingsResponse> _repo = new DapperRepositry<CustomerSettingsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@ShowMood", cs.ShowMood, DbType.Boolean, ParameterDirection.Input);
            param.Add("@ShowProfileToAll", cs.ShowProfileToAll, DbType.Boolean, ParameterDirection.Input);
            param.Add("@ShowProfileToFriends", cs.ShowProfileToFriends, DbType.Boolean, ParameterDirection.Input);
            param.Add("@DoNotShowProfile", cs.DoNotShowProfile, DbType.Boolean, ParameterDirection.Input);
            param.Add("@CustomerId", cs.CustomerId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("UpdateCustomerProfileSettings", param);
        }

        public List<CustomerFriendEntity> GetAllCustomersForFriends(Int32 cid)
        {
            DapperRepositry<CustomerFriendEntity> _repo = new DapperRepositry<CustomerFriendEntity>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", cid, DbType.Int32, ParameterDirection.Input);
            return _repo.GetList("GetAllCustomersForFriends", param);
        }


    }
}
