using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;

namespace TripleTwo.BAL
{
    public class CustomerManager
    {
        CustomerData cd = new CustomerData();
        // public CustomerRegisterResponse RegisterCustomer(CustomerRegistrationParams p)
        // {
        //     return dal.RegisterCustomer(p);
        // }

        //public MobileCheckResponse VerifyCustomerMobile(string mob)
        // {
        //     return dal.VerifyCustomerMobile(mob);
        // }

        // public CustomerNomineeResponse AddCustomerNominees(CustomerNomineeParams p)
        // {
        //     return dal.AddCustomerNominees(p);
        // }
        public MobileCheckResponse VerifyCustomerMobile(string mob)
        {
            return cd.VerifyCustomerMobile(mob);
        }

        public CustomerMoodResponse GetCustomerMood(Int32 cid)
        {
            return cd.GetCustomerMood(cid);
        }

        public List<CustomerEntity> GetCustomerList(paggingCustomerEntity ps)
        {
            return cd.GetCustomerList(ps);
        }

        public CustomerEntity GetCustomerDetailsById(int cid)
        {
            return cd.GetCustomerDetailsById(cid);
        }

        public CustomerRegisterResponse RegisterCustomer(CustomerRegistrationParams p)
        {
            return cd.RegisterCustomer(p);
        }

        public CustomerLoginResponse CustomerLogin(CustomerLoginParams p)
        {
            return cd.CustomerLogin(p);
        }

        public CustomerNomineeResponse AddCustomerNominees(CustomerNomineeParams p)
        {
            return cd.AddCustomerNominees(p);
        }

        public CustomerProfileResponse GetCustomerProfile(Int32 Cid)
        {
            return cd.GetCustomerProfile(Cid);
        }


        public CustomerNomineeResponse SetCustomerMood(CustomerMoodParamsEntity p)
        {
            return cd.SetCustomerMood(p);
        }

        public List<CustomerComNomineeParams> GetCustomerNominees(CustomerMoodParamsEntity p)
        {
            return cd.GetCustomerNominees(p);
        }

        public List<CustomerProfileNomineesResponse> GetCustomerProfileNominees(CustomerMoodParamsEntity p)
        {
            return cd.GetCustomerProfileNominees(p);
        }

        public CustomerSettingsResponse UpdateCustomerProfileSettings(CustomerSettingsParams cs)
        {
            return cd.UpdateCustomerProfileSettings(cs);
        }

        public List<CustomerFriendEntity> GetAllCustomersForFriends(Int32 cid)
        {
            return cd.GetAllCustomersForFriends(cid);
        }

        public AddUpdateCustomerResponse AddUpdateCustomer(AddUpdateCustomerParams p)
        {
            return cd.AddUpdateCustomer(p);
        }

        public AddOrRemoveFriendResponse AddOrRemoveFriend(AddOrRemoveFriendParam p)
        {
            return cd.AddOrRemoveFriend(p);
        }

        public List<GetCustomerFriendsResponse> GetCustomerFriends(Int64 cid, int status, string srchname)
        {
            return cd.GetCustomerFriends(cid, status, srchname);
        }

    }
   
}
