using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using TripleTwo.BAL;
using TripleTwo.Code;
using TripleTwo.Entities;


namespace TripleTwo.Services
{
    public class CustomersController : ApiController
    {
        CustomerManager cb = new CustomerManager();

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}

        [Route("api/GetCustomerList")]
        [HttpGet]
        public List<CustomerEntity> GetCustomerList([FromUri] paggingCustomerEntity es)
        {
            try
            {
                return cb.GetCustomerList(es);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "CustomerController", "GetCustomerList-Services");
                return new List<CustomerEntity>();
            }
        }


      

        [Route("api/GetCustomerDetailsById")]
        [HttpGet]
        public CustomerEntity GetCustomerDetailsById(int cid)
        {
            try
            {
                return cb.GetCustomerDetailsById(cid);
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "CustomerController", "GetCustomerDetailsById-Services");
                return new CustomerEntity();
            }
        }

        [Route("api/AddUpdateCustomer")]
        [HttpPost]
        public AddUpdateCustomerResponse AddUpdateCustomer(AddUpdateCustomerParams p)
        {
            try
            {
                //if (HttpContext.Current.Request.Form.HasKeys())
                //{
                //var data = HttpContext.Current.Request.Form["data"];
                //if (data != null)
                //{
                //    AddUpdateCustomerParams p = JsonConvert.DeserializeObject<AddUpdateCustomerParams>(data);
                return cb.AddUpdateCustomer(p);

                //}
                //}
                //return new AddUpdateCustomerResponse();
            }
            catch(Exception ex)
            {
                return new AddUpdateCustomerResponse();
            }
        }


        [Route("api/VerifyCustomerMobile")]
        [HttpGet]
        public MobileCheckResponse VerifyCustomerMobile(string mob)
        {
            try
            {
                return cb.VerifyCustomerMobile(mob);

            }
            catch
            {
                return new MobileCheckResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }


        [Route("api/GetCustomerMood")]
        [HttpGet]
        public CustomerMoodResponse GetCustomerMood(Int32 cid)
        {
            return cb.GetCustomerMood(cid);
        }

        [HttpPost]
        [Route("api/CustomerLogin")]
        public CustomerLoginResponse CustomerLogin(CustomerLoginParams p)
        {
            try
            {
                var response = cb.CustomerLogin(p);
                if (response == null)
                {
                    response = new CustomerLoginResponse { ResultID = 0, ResultMessage = "Invalid Mobile Number / Pin." };
                }
                return response;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "Customers", "CustomerLogin-Services");
                return new CustomerLoginResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }

        [Route("api/RegisterCustomer")]
        [HttpPost]
        public CustomerRegisterResponse RegisterCustomer(CustomerRegistrationParams p)
        {
            try
            {
                return cb.RegisterCustomer(p);

            }
            catch
            {
                return new CustomerRegisterResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }

        [Route("api/AddCustomerNominees")]
        [HttpPost]
        public List<CustomerNomineeResponse> AddCustomerNominees(List<CustomerNomineeParams> p)
        {
            try
            {
                List<CustomerNomineeResponse> res = new List<CustomerNomineeResponse>();
                CustomerNomineeResponse a = new CustomerNomineeResponse();
                foreach (CustomerNomineeParams item in p)
                {
                    a =cb.AddCustomerNominees(item);
                    res.Add(a);
                }
                return res;

            }
            catch
            {
                return new List<CustomerNomineeResponse> ();
            }


        }

        [Route("api/GetCustomerProfile")]
        [HttpGet]
        public CustomerProfileResponse GetCustomerProfile(Int32 cid)
        {
            CustomerProfileResponse res = new CustomerProfileResponse();
            List<CustomerProfileNomineesResponse> listnominees = new List<CustomerProfileNomineesResponse>();
            CustomerMoodParamsEntity p = new CustomerMoodParamsEntity();
            p.CustomerId = cid;
            listnominees = cb.GetCustomerProfileNominees(p);
            
            res = cb.GetCustomerProfile(cid);
            res.Nominees = listnominees;
            return res;
        }


        [Route("api/SetCustomerMood")]
        [HttpPost]
        public CustomerNomineeResponse SetCustomerMood(CustomerMoodParamsEntity p)
        {
            try
            {
                CustomerNomineeResponse res = new CustomerNomineeResponse();
                res= cb.SetCustomerMood(p);
                if(res.ResultID!=0&&(p.MoodId==3|| p.MoodId == 4))
                {
                    if (p.MoodId == 3) {
                        SendRedMoodCommunication(p);
                            }
                    else if (p.MoodId == 4)
                    {
                        SendBlackMoodCommunication(p);
                    }
                }
                return res;
            }
            catch
            {
                return new CustomerNomineeResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };

            }

        }

        private void SendBlackMoodCommunication(CustomerMoodParamsEntity p)
        {
            CustomerNomineeResponse res = new CustomerNomineeResponse();
            List<CustomerComNomineeParams> listnominees =new List<CustomerComNomineeParams>();
            listnominees = cb.GetCustomerNominees(p);
            string tomail, tomobile, toandroiddeviceid = "", toappledeviceids = "", message="", title="", pmess="";
            string to="", subject="", bodyText = "", fromName = "", bodyHtml = "", file = "";
            string fname = "";
            StringBuilder txtsmsfiledata = new StringBuilder();
            //CustomerNomineeParams nominee = new CustomerNomineeParams();
            foreach (CustomerComNomineeParams nominee in listnominees)
            {
                tomail = nominee.EmailId;
                tomobile = nominee.NomineeMobile;
                
                if (nominee.EmailId!=null&&nominee.EmailId!="")
                {
                    Globalsettings.SendEmail(to, subject, bodyText, fromName, bodyHtml, file);
                }
               else if (nominee.NomineeMobile != null && nominee.NomineeMobile != "")
                {
                    fname = "TripleTwo" + "-" + Convert.ToString(System.DateTime.Now).Replace("-", "").Replace(":", "").Replace(" ", "").Replace(@"\", "").Replace(@"/", "");
                    string folderpath = "";
                    folderpath = "communications";
                    //string mmi = Convert.ToString(Request.Cookies["_222prtn"]["orgid"]);
                    string dir = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string path = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/"  + fname + ".txt");
                    if (!System.IO.File.Exists(path))
                    {

                        System.IO.File.Create(path).Dispose();
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(txtsmsfiledata);
                            sw.Close();
                        }
                    }
                    if (System.IO.File.Exists(path))
                    {
                        using (ZipFile zip = new ZipFile())
                        {
                            string[] files = new string[1];
                            files[0] = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/"  + fname + ".txt");
                            zip.AddFiles(files, "");
                            zip.Save(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/"  + fname + ".zip"));
                        }

                        if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".zip")))
                        {
                            Globalsettings.sendbulksms(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".zip"), fname + ".zip", Convert.ToString("TripleTwo"));
                        }
                    }
                }
                else if (nominee.DeviceId != null && nominee.DeviceId != "")
                {
                    if(nominee.DeviceType==1)
                    {
                        toandroiddeviceid = nominee.DeviceId;
                        Globalsettings.AndroidPushNotifications(toandroiddeviceid, message, title, pmess, nominee.AndroidPushKey);
                    }
                    else if (nominee.DeviceType == 2)
                    {
                        toappledeviceids = nominee.DeviceId;
                        Globalsettings.IPhonePushNotifications(toappledeviceids, nominee.IphonePushKey, message, title, pmess);
                    }
                }
            }
        }

        private void SendRedMoodCommunication(CustomerMoodParamsEntity p)
        {
            CustomerNomineeResponse res = new CustomerNomineeResponse();
            List<CustomerComNomineeParams> listnominees = new List<CustomerComNomineeParams>();
            listnominees = cb.GetCustomerNominees(p);
            string tomail, tomobile, toandroiddeviceid = "", toappledeviceids = "", message = "", title = "", pmess = "";
            string to = "", subject = "", bodyText = "", fromName = "", bodyHtml = "", file = "";
            string fname = "";
            StringBuilder txtsmsfiledata = new StringBuilder();
            //CustomerNomineeParams nominee = new CustomerNomineeParams();
            foreach (CustomerComNomineeParams nominee in listnominees)
            {
                tomail = nominee.EmailId;
                tomobile = nominee.NomineeMobile;

                if (nominee.EmailId != null && nominee.EmailId != "")
                {
                    Globalsettings.SendEmail(to, subject, bodyText, fromName, bodyHtml, file);
                }
                else if (nominee.NomineeMobile != null && nominee.NomineeMobile != "")
                {
                    fname = "TripleTwo" + "-" + Convert.ToString(System.DateTime.Now).Replace("-", "").Replace(":", "").Replace(" ", "").Replace(@"\", "").Replace(@"/", "");
                    string folderpath = "";
                    folderpath = "communications";
                    //string mmi = Convert.ToString(Request.Cookies["_222prtn"]["orgid"]);
                    string dir = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string path = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".txt");
                    if (!System.IO.File.Exists(path))
                    {

                        System.IO.File.Create(path).Dispose();
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(txtsmsfiledata);
                            sw.Close();
                        }
                    }
                    if (System.IO.File.Exists(path))
                    {
                        using (ZipFile zip = new ZipFile())
                        {
                            string[] files = new string[1];
                            files[0] = System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".txt");
                            zip.AddFiles(files, "");
                            zip.Save(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".zip"));
                        }

                        if (System.IO.File.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".zip")))
                        {
                            Globalsettings.sendbulksms(System.Web.Hosting.HostingEnvironment.MapPath("~/content/organization/" + folderpath + "/" + fname + ".zip"), fname + ".zip", Convert.ToString("TripleTwo"));
                        }
                    }
                }
                else if (nominee.DeviceId != null && nominee.DeviceId != "")
                {
                    if (nominee.DeviceType == 1)
                    {
                        toandroiddeviceid = nominee.DeviceId;
                        Globalsettings.AndroidPushNotifications(toandroiddeviceid, message, title, pmess, nominee.AndroidPushKey);
                    }
                    else if (nominee.DeviceType == 2)
                    {
                        toappledeviceids = nominee.DeviceId;
                        Globalsettings.IPhonePushNotifications(toappledeviceids, nominee.IphonePushKey, message, title, pmess);
                    }
                }
            }
        }


        [Route("api/UpdateCustomerProfileSettings")]
        [HttpPost]
        public CustomerSettingsResponse UpdateCustomerProfileSettings( CustomerSettingsParams cs)
        {
            try
            {
                return cb.UpdateCustomerProfileSettings( cs);

            }
            catch
            {
                return new CustomerSettingsResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }

        }


        [Route("api/GetAllCustomersForFriends")]
        [HttpGet]
        public List<CustomerFriendEntity> GetAllCustomersForFriends(Int32 cid)
        {
            return cb.GetAllCustomersForFriends(cid);
        }

        [Route("api/AddOrRemoveFriend")]
        [HttpPost]
        public AddOrRemoveFriendResponse AddOrRemoveFriend(AddOrRemoveFriendParam p)
        {
            try
            {
                AddOrRemoveFriendResponse res = cb.AddOrRemoveFriend(p);
                return res;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "CustomerController", "AddOrRemoveFriend-Services");
                return new AddOrRemoveFriendResponse { ResultID = 0 };
            }
        }


        [Route("api/GetCustomerFriends")]
        [HttpGet]
        public List<GetCustomerFriendsResponse> GetCustomerFriends(Int64 cid, int status, string srchname)
        {
            try
            {
                List<GetCustomerFriendsResponse> cfl = new List<GetCustomerFriendsResponse>();
                cfl = cb.GetCustomerFriends(cid, status, srchname);

                return cfl;
            }
            catch (Exception ex)
            {
                ExceptionUtility.LogException(ex, "CustomerController", "GetCustomerFriends-Services");
                return new List<GetCustomerFriendsResponse>();
            }
        }

    }

}
