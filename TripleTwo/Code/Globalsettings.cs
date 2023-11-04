using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripleTwo.Entities;

using System.Web.Security;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using TripleTwo.BAL;
using System.Configuration;
using System.Security.Cryptography;
using System.Collections.Specialized;
using SendGrid;
using System.Net.Mail;

namespace TripleTwo.Code
{
    public class Globalsettings
    {
        //private static string _websiteurl = Settings.websiteurl;
        public static string _websiteurl
        {
            get
            {
                // return "http://www.mstechnologies.com.au/smartdeals.co.nz/";
                // return "http://localhost:5275/";
                string url = HttpContext.Current.Request.Url.Authority + "/";
                if (url.IndexOf("http") == -1)
                {
                    url = "http://" + url;
                }
                return url;
            }
        }
        public static string GetGoogleKey()
        {
           
                return ConfigurationManager.AppSettings["GoogleKey"];
            
        }
        public static string GetAppUrl()
        {

            return ConfigurationManager.AppSettings["AppUrl"];

        }
        public static string adminassetspath(string file)
        {
            return _websiteurl + "/Content/assets/" + file;
        }
        public static string admincsspath(string file)
        {
            return _websiteurl + "/Content/assets/plugins/lobipanel/css/" + file;
        }
        public static string appcsspath(string file)
        {
            return _websiteurl + "assets/plugins/lobipanel/css/" + file;
        }

        public static string MobileAppUrl
        {
            get { return ConfigurationManager.AppSettings["MobileAppUrl"]; }

        }
        public static string GetGoogleMapsApi
        {
            get { return ConfigurationManager.AppSettings["GeoAddressApi"]; }
        }
      
        public static string PromotionQrcombinepath(string promoid)
        {
            return "~/content/promotions/" + promoid + "/";
        }
        public static string SurveyQrcodepath(string surveyid)
        {
            return "~/content/surveyimages/" + surveyid + "/";
        }
        public static string SmartquizQrcodepath(string quizid)
        {
            return "~/content/smartquizimages/" + quizid + "/";
        }
        public static string SpellingBeequizQrcodepath(string quizid)
        {
            return "~/content/spellingbeequizimages/" + quizid + "/";
        }
        public static string quizQrcodepath(string quizid)
        {
            return "~/content/quizimages/" + quizid + "/";
        }
        public static string GameQrcodepath(string gameid)
        {
            return "~/content/gameimages/" + gameid + "/";
        }
        public static string grappcsspath(string file)
        {
            return _websiteurl + "groupcontent/css/" + file;
        }

        public static string appjspath(string file)
        {
            return _websiteurl + "content/js/" + file;
        }

        public static string grappjspath(string file)
        {
            return _websiteurl + "groupcontent/js/" + file;
        }
        public static string appimagespath(string file)
        {
            return _websiteurl + "content/images/" + file;
        }

        public static string grappimagespath(string file)
        {
            return _websiteurl + "groupcontent/images/" + file;
        }

        public static string SetFont(string text)
        {
            return string.IsNullOrEmpty(text) == true ? "" : System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(text);
        }

        /// <summary>
        /// To set dateformat.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Dateformat(mmm d, yyyy)</returns>
        public static string SetDateFormat(DateTime? dt)
        {
            if (dt != null)
            {
                return String.Format("{0:d MMM, yyyy}", Convert.ToDateTime(dt));
            }
            else { return ""; }
        }

        /// <summary>
        /// To set datetimeformat.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>Datetimeformat(mmm d, yyyy HH:mm)</returns>
        public static string SetDateTimeFormat(DateTime? dt)
        {
            if (dt != null)
            {
                return String.Format("{0:d MMM, yyyy h:mm:ss tt}", Convert.ToDateTime(dt));
            }
            else { return ""; }
        }
//----------------- groups log  functions-----------------------------//
       
//---------------- group log functions-------------------//
        public bool IsOrgLoggedIn()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                if (HttpContext.Current.Request.Cookies["_org"] != null)
                {
                    return true;
                }
                else
                {
                    DoOrgLogOut();
                    return false;
                }
            }
            else
            {
                if (HttpContext.Current.Request.Cookies["_org"] != null)
                {
                    DoOrgLogOut();
                }
                return false;
            }
        }
        public static void DoOrgLogOut()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies["_org"] != null)
                {
                    HttpCookie oCookie = (HttpCookie)HttpContext.Current.Request.Cookies["_org"];
                    oCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(oCookie);
                    HttpContext.Current.Request.Cookies.Remove("_org");
                }
                FormsAuthentication.SignOut();
            }
            catch { }
        }
        /// <summary>
        /// Get logged in organisation details.
        public Dictionary<string ,string> OrgLoggedInDetails()
        {
            HttpCookie oCookie = (HttpCookie)HttpContext.Current.Request.Cookies["_org"];
            if (oCookie == null)
            {
                return null;
            }
            else
            {
                Dictionary<string, string> det = new Dictionary<string, string>();
                det.Add("orgid", Convert.ToString(oCookie["orgid"]));
                det.Add("orgn", Convert.ToString(oCookie["orgn"]));
                det.Add("orgl", Convert.ToString(oCookie["orgl"]));
                det.Add("orgprimary", Convert.ToString(oCookie["orgprimary"]));
                det.Add("orgsecondary", Convert.ToString(oCookie["orgsecondary"]));
                det.Add("orgbtns", Convert.ToString(oCookie["orgbtns"]));
                det.Add("orgtxt", Convert.ToString(oCookie["orgtxt"]));
                det.Add("orgbackgroundimg", Convert.ToString(oCookie["orgbackgroundimg"]));
                det.Add("orgbannerimg", Convert.ToString(oCookie["orgbannerimg"]));
                det.Add("orgmenuimg", Convert.ToString(oCookie["orgmenuimg"]));
                det.Add("loginstring", Convert.ToString(oCookie["loginstring"]));
                return det;
            }
        }



        public bool IsPartnerLoggedin()
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                if (HttpContext.Current.Request.Cookies["_222prtn"] != null)
                {
                    return true;
                }
                else
                {
                    DoPartnerLogOut();
                    return false;
                }
            }
            else
            {
                if (HttpContext.Current.Request.Cookies["_222prtn"] != null)
                {
                    DoPartnerLogOut();
                }
                return false;
            }
        }

        internal static void IPhonePushNotifications(string toappledeviceids, object iphonePushKey, string message, string title, string pmess)
        {
            throw new NotImplementedException();
        }

        internal static void IPhonePushNotifications(object did, object iphonePushKey, string message, string title, string pmess)
        {
            throw new NotImplementedException();
        }

        internal static void AndroidPushNotifications(string toandroiddeviceid, string message, string title, string pmess, object androidPushKey)
        {
            throw new NotImplementedException();
        }

        internal static void DoPartnerLogOut()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies["_222prtn"] != null)
                {
                    HttpCookie oCookie = (HttpCookie)HttpContext.Current.Request.Cookies["_222prtn"];
                    oCookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(oCookie);
                    HttpContext.Current.Request.Cookies.Remove("_222prtn");
                }
                FormsAuthentication.SignOut();
            }
            catch { }
        }
        /// <summary>
        /// Get logged in admin details.
        public Dictionary<string, string> PartnerLoggedInDetails()
        {
            HttpCookie oCookie = (HttpCookie)HttpContext.Current.Request.Cookies["_222prtn"];
            if (oCookie == null)
            {
                return null;
            }
            else
            {
                Dictionary<string, string> det = new Dictionary<string, string>();
                det.Add("pid", Convert.ToString(oCookie["pid"]));
                det.Add("pn", Convert.ToString(oCookie["pn"]));
                det.Add("pl", Convert.ToString(oCookie["pl"]));
                det.Add("orgid", Convert.ToString(oCookie["orgid"]));
                return det;
            }
        }


        public static int SaveFile(string filedata, string filename, string servermappath)
        {
            int res = 1;
            byte[] imagedata = Convert.FromBase64String(filedata);
            string generatefilename = filename; //surveyimg.SurveyId.ToString() + "_" + surveyimg.ImageTypeId.ToString();
            //  string fileextence = ".jpg";
            if (imagedata != null && imagedata.Length > 0)
            {
                try
                {

                    //  ImageName = joborderid + joballotmentid + "box.jpeg";
                    string strFilePath = System.Web.Hosting.HostingEnvironment.MapPath(servermappath) + generatefilename;
                    // string strFilePath = "D:\\APSSAAT\\Content\\images\\Beneficiary\\" + surveyimg.SurveyId.ToString() + "//" + generatefilename + fileextence;
                    FileStream targetStream = null;
                    MemoryStream ms = new MemoryStream(imagedata);
                    Stream sourceStream = ms;
                    string uploadFolder = System.Web.Hosting.HostingEnvironment.MapPath(servermappath);
                    //   string uploadFolder = "D:\\APSSAAT\\Content\\images\\Beneficiary\\" + surveyimg.SurveyId.ToString();
                    // string uploadFolder = "C:\\Inetpub\\wwwroot\\Content\\Agents\\" + Agent.AgentId + "\\";
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }
                    //  string filename = generatefilename + fileextence;

                    string filePath = Path.Combine(uploadFolder)+filename;
                    // write file using stream.
                    using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {

                        const int bufferLen = 4096;
                        byte[] buffer = new byte[bufferLen];
                        int count = 0;
                        int totalBytes = 0;
                        while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                        {

                            totalBytes += count;
                            targetStream.Write(buffer, 0, count);

                        }

                        targetStream.Close();

                        sourceStream.Close();

                    }


                }

                catch (Exception ex)
                {
                    res = -1;
                    return res;
                    // ExceptionUtility.LogException(ex, "Agent Business logo Uploaded-Agentserevices", "Agent");

                }

            }
            return res;
        }
        /// <summary>
        /// generate 4 digit random number
        /// </summary>
        /// <returns></returns>
        public static string RandomNumber()
        {
            Random r = new Random();
            string s = Convert.ToString(r.Next(1000, 10000));
            return s;
        }
        // Generate a random string with a given size 
        /// <summary>
        /// Generate a random string with a given size with datetime milleseconds..
        /// </summary>
        /// <param name="append"></param>
        /// <returns></returns>
        public static string RandomString(string append)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < 2; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            append += builder.ToString().ToLower();
            string unixTimestamp = Convert.ToString((DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).Replace(".", "");
            return append + unixTimestamp;
        }
        public static string GetCountryTeleCode()
        {
            return "61";
            //return ConfigurationManager.AppSettings["TeleCode"].ToString();
        }
        public static string GetSMSServer()
        {
            return "https://my.smscentral.com.au/wrapper/sms";
            //return ConfigurationManager.AppSettings["SMSServer"].ToString();
        }

        public static string GetSMSApiServer()
        {
            return "https://my.smscentral.com.au/wrapper/sms";
            //return ConfigurationManager.AppSettings["SMSApiServer"].ToString();
        }

        public static string GetSMSUsername()
        {
            return "admin@mstechnologies.com.au";
            //return ConfigurationManager.AppSettings["SMSUsername"].ToString();
        }

        public static string GetSMSPassword()
        {
            return "Paul@1962";
            //return ConfigurationManager.AppSettings["SMSPassword"].ToString();
        }

        public static string GetSMSHeader()
        {
            return "Halo";
           // return ConfigurationManager.AppSettings["SMSHeader"].ToString();
        }

        public static void SendSMSMessage(string SMSTo, string ReplyMessage, string Header = "Halo")
        {
            if (!string.IsNullOrEmpty(SMSTo))
            {
                WebRequest WebRequest;
                // object for WebRequest
                WebResponse WebResonse;                
                string Server = GetSMSServer();
                //string Port = "";
                string UserName = GetSMSUsername();
                string Password = GetSMSPassword();

                string sourceto = Header == "" ? GetSMSHeader() : Header;
                string Source = sourceto;
                int telecodelen = GetCountryTeleCode().Length;
                string Destination = SMSTo;// SMSTo[0] == '0' ? SMSTo.Substring(1) : SMSTo;
               // Destination = Destination.Substring(0, telecodelen) == GetCountryTeleCode() ? Destination : GetCountryTeleCode() + Destination;
                string WebResponseString = "";
                string URL = (
                             (Server + ("?USERNAME="
                            + (UserName + ("&PASSWORD="
                            + (Password + ("&ACTION="
                            + ("send" + ("&RECIPIENT="
                            + (Destination + ("&ORIGINATOR="
                            + (Source + ("&MESSAGE_TEXT="
                            + (ReplyMessage + ""))))))))))))));

                WebRequest = HttpWebRequest.Create(URL);
                // Hit URL Link
                WebRequest.Timeout = 25000;
                try
                {
                    WebResonse = WebRequest.GetResponse();
                    // Get Response
                    StreamReader reader = new StreamReader(WebResonse.GetResponseStream());
                    WebResponseString = reader.ReadToEnd();
                    WebResonse.Close();
                }
                catch
                {
                    WebResponseString = "Request Timeout";
                }
            }
        }

        public static string sendbulksms(string fpath, string fname, string smsheader)
        {
            string result = "";
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("ACTION", "send");
            nvc.Add("USERNAME", GetSMSUsername());
            nvc.Add("PASSWORD", GetSMSPassword());
            nvc.Add("ORIGINATOR", smsheader);
            nvc.Add("FILE_LIST", fname);
            nvc.Add("FILE_HASH", GetFileMD5(fpath));
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(GetSMSApiServer());
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream rs = wr.GetRequestStream();
            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            foreach (string key in nvc.Keys)
            {
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string formitem = string.Format(formdataTemplate, key, nvc[key]);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                rs.Write(formitembytes, 0, formitembytes.Length);
            }
            string file = fpath;
            rs.Write(boundarybytes, 0, boundarybytes.Length);
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "FILE_LIST", fname, "application/zip");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[100000000];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();
            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                result = reader2.ReadToEnd();
            }
            catch
            {


                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }
            finally
            {
                wr = null;
            }
            return result;
        }
        protected static string GetFileMD5(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static string Iospushfile(string folder)
        {

            return Convert.ToString(ConfigurationManager.AppSettings["IosPushRoot"]) + folder + "/simplepush.php";

        }

        public static void AndroidPushNotifications(string[] deviceid, string message, string title, string navurl, string appkey)
        {
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            //tRequest.ContentType = "application/x-www-form-urlencoded";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", appkey));
            String collaspeKey = Guid.NewGuid().ToString("n");
            title = string.IsNullOrEmpty(title) ? "Halo" : title;
            var result = string.Join("\",\"", deviceid);
            try
            {
                var postmsg = new
                {
                    registration_ids = deviceid,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = message,
                        title = title.Replace(":", ""),
                        navurl = string.IsNullOrEmpty(navurl) ? "" : navurl
                    },
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(postmsg);
                //string testdata = string.Format("registration_id={0}&data.contentTitle={1}&data.message={2}&data.collapse_Key={3}", deviceid[0], title, message, collaspeKey);
                //string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse tResponse = tRequest.GetResponse();
                Stream dataStreamResponce = tResponse.GetResponseStream();

                //dataStream = tResponse.GetResponseStream();
                StreamReader tReader = new StreamReader(dataStreamResponce);
                String sResponseFromFirebaseServer = tReader.ReadToEnd();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch
            {
            }
        }

        public static void IPhonePushNotifications(string deviceid, string pushfolder, string message, string title, string navurl)
        {
            try
            {
                pushfolder=string.IsNullOrEmpty(pushfolder)?"halo":pushfolder;
                title = string.IsNullOrEmpty(title) ? "Halo" : title;
                WebRequest request = null;
                if (navurl == "")
                {
                    request = WebRequest.Create(Iospushfile(pushfolder) + "?did=" + deviceid + "&mess=" + message);
                }
                else
                {
                    request = WebRequest.Create(Iospushfile(pushfolder) + "?did=" + deviceid + "&mess=" + message + "&url=" + navurl);
                }
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch { }
        }

        public static string GetEmailTemplate()
        {
            WebClient webClient = new WebClient();
            string path = "";
            path = Settings.websiteurl + "/emailcomminications/emailtemplate-2.html";
            Stream stream = webClient.OpenRead(path);
            StreamReader reader = new StreamReader(stream);
            string readFile = reader.ReadToEnd();
            string StrContent = "";
            StrContent = readFile;
            return StrContent;
        }
        public static bool SendEmail(string to, string subject, string bodyText, string fromName, string bodyHtml, string file = null)
        {
            bool issend = false;

            string uname = SendGridEmailCredentials()["uname"].ToString();
            string pwd = SendGridEmailCredentials()["pwd"].ToString();
            string key = SendGridEmailCredentials()["key"].ToString();
            string from = "noreply@gtcm.com";
            //string fromName = "Gamesnatcherz";
            var message = new SendGridMessage();

            message.Subject = subject;
            message.From = new MailAddress(from, fromName);
            if (bodyHtml != null)
            {
                message.Html = bodyHtml;
            }
            if (bodyText != null)
            {
                message.Text = bodyText;
            }
            if (string.IsNullOrEmpty(to))
            {
                return false;
            }
            if (!string.IsNullOrEmpty(file))
            {
                message.AddAttachment(file);
            }
            message.AddTo(to);
            var transportInstance = new Web(key);
            message.EnableBypassListManagement();
            transportInstance.DeliverAsync(message);
            return true;

        }
        public static Dictionary<string, string> SendGridEmailCredentials()
        {
            Dictionary<string, string> cred = new Dictionary<string, string>();

            cred.Add("uname", ConfigurationManager.AppSettings["SendGridEmailUname"].ToString());
            cred.Add("pwd", ConfigurationManager.AppSettings["SendGridEmailPassword"].ToString());
            cred.Add("key", ConfigurationManager.AppSettings["SendGridKey"].ToString());

            return cred;
        }

        

    }

    public class AppMessages
    {
        public const string CreateItemSuccess = "Promotion created successfully.";
        public const string UpdateItemSuccess = "Promotion details updated successfully.";
        public const string DeletePromotionConfirm = @"Are you sure to delete the {productname}? Proceed to continue";
        public static string DeletePromotionSuccess = "Promotion deleted successfully.";
        public const string DeleteBusinessConfirm = @"Are you sure to delete the {businessname}? Proceed to continue";
        public static string DeleteBusinessSuccess = "Business deleted successfully.";
        public const string DeleteCustomerConfirm = @"Are you sure to delete the {name}? Proceed to continue";
        public static string DeleteCustomerSuccess = "Customer deleted successfully.";
        public const string AddBusinessSuccess = "Outlet added successfully.";
        public const string UpdateBusinessSuccess = "Outlet details updated successfully.";
        public const string SignUpBusinessSuccess = "SignUp process has been completed successfully.";
        public const string UpdateProfileSuccess = "Profile details updated successfully.";
        public const string ChangePasswordSuccess = "Password changed successfully.";
        public static string ProcessOrderSuccess = "Order processed successfully.";
        public const string DeleteSurveyConfirm = @"Are you sure to delete the {surveyname}? Proceed to continue";
        public static string DeleteSurveySuccess = "Survey deleted successfully.";
        public const string CreateSurveySuccess = "Survey created successfully.";
        public const string UpdateSurveySuccess = "Survey details updated successfully.";
        public const string DeleteSwipeandWinConfirm = @"Are you sure to delete the {title}? Proceed to continue";
        public static string DeleteSwipeandWinSuccess = "SwipeandWin deleted successfully.";
        public const string CreateSwipeandWinSuccess = "SwipeandWin created successfully.";
        public const string UpdateSwipeandWinSuccess = "SwipeandWin details updated successfully.";
    }

    public class PlaceHolders
    {
        public const string EmailId = "Email ID";
        public const string BusinessName = "BusinessName";
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string UserName = "Username";
        public const string Password = "Password";
        public const string ProductName = "Item Name";
        public const string ProductPrice = "Price";
        public const string OfferPrice = "Offer Price";
        public const string Coins = "Coins";
        public const string CoinsLimit = "Coins Limit";
        public const string Description = "Description";
        public const string Conditions = "Conditions";
        public const string QtyLimit = "Quantity Limit";
        public const string StartDate = "Start Date";
        public const string EndDate = "End Date";
        public const string OutletName = "Store Name";
        public const string OutletNo = "Store Number";
        public const string Address = "Address";
        public const string City = "City";
        public const string PostCode = "Postal / Zip Code";
        public const string ContactName = "Contact Name";
        public const string ContactEmail = "Contact EmailID";
        public const string ContactNumber = "Contact Number";
        public const string MallName = "Mall Name";
        public const string OldPassword = "Old Password";
        public const string NewPassword = "New Password";
        public const string NewConfirmPassword = "New Confirm Password";
        public const string Phone = "Phone";
        public const string ReasonAny = "Reason Any?";
        public const string SurveyName = "Survey Name";
        public const string SwipeandWinTitle = "Title";
        public const string SwipeandWinFirstPrizeTitle = "First Prize Title";
        public const string SwipeandWinSecondPrizeTitle = "Second Prize Title";
        public const string SwipeandWinThirdPrizeTitle = "Third Prize Title";
        public const string SwipeandWinFirstPrizeCount = "First Prize Title";
        public const string SwipeandWinSecondPrizeCount = "Second Prize Title";
        public const string SwipeandWinThirdPrizeCount = "Third Prize Title";
        public const string SwipeandWinFirstPrizeTerms = "First Prize Terms";
        public const string SwipeandWinSecondPrizeTerms = "Second Prize Terms";
        public const string SwipeandWinThirdPrizeTerms = "Third Prize Terms";
    }

    public class ValExpressions
    {
        //Email regular expression.
        public const string Email = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,}$";        //@"^(?=.{1,64}@)[A-Za-z0-9_-]+(\.[A-Za-z0-9_-]+)*@[^-][A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,})$";

    }

    public class Constraints
    {
        public const byte EmailMax = 200;
        public const byte PwdMax = 50;
        public const byte ProductName = 150;
        public const byte Price = 10;
        public const byte ProductQtyLimit = 8;
        public const byte Coins = 10;
        public const byte CoinsLimit = 8;
        public const int ProductDescription = 2000;
        public const int ProductConditions = 2000;
        public const int Description = 1000;
        public const int Address = 1000;
        public const int City = 50;
        public const int PostCode = 8;
        public const int Name = 50;
        public const int Phone = 15;
        public const int UserName = 50;
        public const int Pwd = 30;
        public const int BusinessName = 100;
        public const int FirstName = 50;
        public const int LastName = 50;
        public const byte SurveyName = 150;
        public const int SurveyDescription = 2000;
        public const int SurveyConditions = 2000;
        public const byte SwipeandWinTitle = 150;
        public const byte SwipeandWinFirstPrizeTitle = 150;
        public const byte SwipeandWinSecondPrizeTitle = 150;
        public const byte SwipeandWinThirdPrizeTitle = 150;
        public const byte SwipeandWinFirstPrizeCount = 8;
        public const byte SwipeandWinSecondPrizeCount = 8;
        public const byte SwipeandWinThirdPrizeCount = 8;
        public const int SwipeandWinFirstPrizeTerms = 2000;
        public const int SwipeandWinSecondPrizeTerms = 2000;
        public const int SwipeandWinThirdPrizeTerms = 2000;
    }

    public class ValMessages
    {
        public const string EmailReq = "Please enter emailid.";
        public const string InvalidEmail = "Please enter valid emailid.";
        public const string EmailMax = "EmailId is too long.";
        public const string FirstNameReq = "Please enter first name.";
        public const string FirstNameMax = "First name is too long.";
        public const string LastNameReq = "Please enter last name.";
        public const string LastNameMax = "Last name is too long.";
        public const string PasswordReq = "Please enter password.";
        public const string UserNameReq = "Please enter username.";
        public const string ProductNameReq = "Please enter promotion name.";
        public const string ProductDescriptionReq = "Please enter description.";
        public const string ProductDescriptionMax = "Description is too long.";
        public const string ProductConditionsMax = "Conditions is too long.";
        public const string ProductQtyLimitReq = "Please enter quantity limit (0 - unlimited).";
        public const string ProductQtyLimitMax = "Quantity limit is too long.";
        public const string ProductPriceReq = "Please enter price.";
        public const string ProductPriceMax = "Price is too long.";
        public const string BusinessNameReq = "Please enter Outlet name.";
        public const string BusinessNameMax = "Outlet name is too long.";
        public const string AddressReq = "Please enter address.";
        public const string AddressMax = "Address is too long.";
        public const string CityReq = "Please enter city name.";
        public const string CityMax = "City name is too long.";
        public const string PostCodeReq = "Please enter post code.";
        public const string PostCodeMax = "Post code is too long.";
        public const string ContactNameReq = "Please enter contact name.";
        public const string ContactNameMax = "Contact name is too long.";
        public const string ContactEmailReq = "Please enter contact emailid.";
        public const string ContactEmailMax = "Emailid is too long.";
        public const string ContactNoReq = "Please enter contact number.";
        public const string ContactNoMax = "Contact number is too long.";
        public const string ConfirmNewPwdReq = "Please enter confirm new password.";
        public const string ConfirmNewPwdMax = "Confirm new password is too long.";
        public const string NewPwdReq = "Please enter new password.";
        public const string NewPwdMax = "New password is too long.";
        public const string OldPwdMax = "Old password is too long.";
        public const string OldPwdReq = "Please enter old password.";
        public const string PhoneReq = "Please enter phone number.";
        public const string PhoneMax = "Phone number is too long.";
        public const string DdlBusinessTypeRequried = "Please select business type.";
        public const string SurveyNameReq = "Please enter survey name.";
        public const string SurveyDescriptionReq = "Please enter description.";
        public const string SurveyDescriptionMax = "Description is too long.";
        public const string SurveyConditionsMax = "Conditions is too long.";

    }



}