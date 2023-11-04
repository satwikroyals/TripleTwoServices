using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;

namespace TripleTwo.Entities
{
    public class Settings
    {
        public static string BaseErrorMessage = "Some problem occured.";
        //private static string websiteurl = "http://localhost:1223/";
        //private static string websiteurl = "http://151.106.38.222:100/";
        private static string noimage = websiteurl + "content/images/no_image.jpg";

       
        public static string DbConnection
        {
            get
            {
                return ConfigurationManager.AppSettings["DbConn"];
               // return "Data Source=.\\KIRAN;Initial Catalog=halo;Persist Security Info=True;User ID=sa;Password=sa123";
                 //return "Data Source=LAPTOP-BF1V8FUV;Initial Catalog=Halo;Persist Security Info=True;User ID=sa;Password=anil";
              //  return "Data Source=151.106.38.222,1433,1433;Initial Catalog=Halo;Persist Security Info=True;User ID=sa;Password=Medi@1234";
            }
        }

        public class CalculateCartItemTotalPriceParams
        {
            public int Qty { get; set; }
            public decimal DealPrice { get; set; }
            public decimal OfferPrice { get; set; }
           
        }
        public static decimal CalculateCartItemTotalPrice(CalculateCartItemTotalPriceParams p)
        {
            decimal TotalDealPrice = 0.00m;
           
           
                TotalDealPrice = p.Qty * p.OfferPrice;
            
            return TotalDealPrice;
        }
        public class BaseResponse
        {
            public long ResultID { get; set; }
            public string ResultMessage { get; set; }
        }

        internal static string SetStatus(int status)
        {
            if (status == 0) return "Inactive"; else return "Active";
        }

        /// <summary>
        /// WebsiteUrl
        /// </summary>
        public static string websiteurl
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

        public static string GetItemsImagePath(Int64 itemid, string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/products/" + itemid.ToString() + "/" + filename);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/products/" + itemid.ToString() + "/" + filename;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }

        public static string SetOrderStatus(int stat)
        {
            string OrderStatus = "Processing";
            if (stat != null)
            {
                switch (stat)
                {
                    case 0: OrderStatus = "Processing"; break;
                    case 1: OrderStatus = "Completed"; break;
                    case -1: OrderStatus = "Cancelled"; break;
                }
            }
            return OrderStatus;
        }
        public static string SetPriceFormat(string price)
        {
            if (price != null && price != "")
            {
                return "$" + string.Format("{0:0.00}", Convert.ToDouble(price));
            }
            else { return "$" + "0.00"; }
        }
        public static string SetPriceFormatNoCurrency(string price)
        {
            if (price != null && price != "")
            {
                return string.Format("{0:0.00}", Convert.ToDouble(price));
            }
            else { return "0.00"; }
        }

        /// <summary>
        /// WebsiteUrlAdmin
        /// </summary>
        public static string WebsiteUrlAdmin
        {
            get
            {
                return websiteurl + "/Admin/";
            }
        }

        /// <summary>
        /// WebsiteUrlApi
        /// </summary>
        public static string WebsiteUrlApi
        {
            get
            {
                return websiteurl + "/api/";
            }

        }
        /// <summary>
        /// Database provider
        /// </summary>
        public static string ProviederName
        {
            get { return "MsSql"; }
        }

        /// <summary>
        /// Content Path
        /// </summary>
        public static string Contentpath
        {
            get { return "~/content/"; }
        }

        /// <summary>
        /// ThemeCssPath
        /// </summary>
        public static string ThemeCssPath
        {
            get { return "~/content/css/"; }
        }


        /// <summary>
        /// ThemeCssPath
        /// </summary>
        public static string ThemeImagesPath
        {
            get { return "~/content/images/"; }
        }
        /// <summary>
        /// To set font in Title case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Title Case Text</returns>
        public static string SetFont(string text)
        {
            return string.IsNullOrEmpty(text) == true ? "" : System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(text);
        }

        internal static string GetMood(int moodId)
        {
            if (moodId == 1)
            {
                return "i'm well";
            }
            else if (moodId == 2)
            {
                return "i'm not good";
            }
            else if (moodId == 3)
            {
                return " i need help";
            }
            else
            {
                return "i'm in emergency";
            }
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
                return String.Format("{0:d/MMM/yyyy}", Convert.ToDateTime(dt));
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
                return String.Format("{0:d MMM, yyyy h:mm tt}", Convert.ToDateTime(dt));
            }
            else { return ""; }
        }
        /// <summary>
        /// To set Time Formate as in 12 hrs.
        /// </summary>
        /// <param name="dt">datetime</param>
        /// <returns>return 12hrs formate .if you want in 24 hrs formate remove tt.</returns>
        public static string SetTimeFormat(DateTime? dt)
        {
            if (dt != null)
            {
                return String.Format("{0:h:mm:ss tt}", Convert.ToDateTime(dt));
            }
            else { return ""; }
        }
        /// <summary>
        /// To Set DataBaseConnectionString Format.
        /// </summary>
        /// <param name="clientDbInfo">Client database information dictionary</param>
        /// <returns>ConnectionString Format</returns>
        public static string SetDbConnectionStringFormat(Dictionary<string, string> clientDbInfo)
        {
            switch (clientDbInfo["DBProviderType"].ToLower())
            {
                case "mssql": return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", clientDbInfo["DBServerUrl"],
                                                                                                     clientDbInfo["DBName"],
                                                                                                     clientDbInfo["DBUsername"],
                                                                                                     clientDbInfo["DBPassword"]);
                default: return "";
            }
        }


        public static string GetMoodIcon(string moodicon)
        {
            return websiteurl + "/content/moodicons/" + moodicon+".png";
        }

        public static string GetCustomerProfileImage(Int64 Cid, string imagename)
        {
            if (string.IsNullOrEmpty(imagename))
            {
                return websiteurl + "/content/images/Noprofileimage.png";
            }
            else
            {

                return websiteurl + "/content/CustomerImage/" + Cid.ToString() + "/" + imagename;

            }
        }
        public static string GetCountryImage(Int64 cnid, string imagename)
        {
            if (string.IsNullOrEmpty(imagename))
            {
                return "";
            }
            else
            {

                return websiteurl + "/content/country/" + cnid.ToString() + "/" + imagename;

            }
        }

        private static string nobusinesslogo = websiteurl + "content/images/nobusinesslogo.png";

        public static string GetBusinessLogoImage(long bid, string imagename)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/Business/" + bid.ToString() + "/" + imagename);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/Business/" + bid.ToString() + "/" + imagename;
                }
                else
                {
                    return nobusinesslogo;
                }
            }
            catch
            {

                return nobusinesslogo;
            }
        }


        public static string GetSponsorImage(long bid, string imagename)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/Sponsor/" + bid.ToString() + "/" + imagename);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/Sponsor/" + bid.ToString() + "/" + imagename;
                }
                else
                {
                    return nobusinesslogo;
                }
            }
            catch
            {

                return nobusinesslogo;
            }
        }

        public static string GetSupporterImage(long bid, string imagename)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/Supporter/" + bid.ToString() + "/" + imagename);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/Supporter/" + bid.ToString() + "/" + imagename;
                }
                else
                {
                    return nobusinesslogo;
                }
            }
            catch
            {

                return nobusinesslogo;
            }
        }



        public static string GetEventImage(Int64 evid, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/events/" + evid.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/events/" + evid.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }

        public static string GetMediaMainImage(Int32 mediaid, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/media/" + mediaid.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/media/" + mediaid.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }

        public static string GetMediaImages(Int32 mediaid, Int64 imgid, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/media/" + mediaid.ToString() + "/images/" + imgid.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/media/" + mediaid.ToString() + "/images/" + imgid.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetPartnerLogo(Int32 ptnrid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/partners/" + ptnrid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/partners/" + ptnrid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetPartnerImages(Int32 ptnrid, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/partners/" + ptnrid.ToString() + "/images/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/partners/" + ptnrid.ToString() + "/images" + imgname;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetGroupLogo(Int32 grid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/groups/" + grid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/groups/" + grid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetOrganisationLogo(int orgid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/organization/" + orgid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/organization/" + orgid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetOrganisationThemes(int orgid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return websiteurl + "/content/images/bg-4.png";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/organizationThemeimg/" + orgid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/organizationThemeimg/" + orgid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return websiteurl + "/content/images/bg-4.png";
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetGroupThemes(int grpid, int OrgId, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return websiteurl + "/content/images/loginbg.png";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/groupThemeimg/" + grpid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/groupThemeimg/" + grpid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return websiteurl + "/content/organizationThemeimg/" + OrgId.ToString() + "/" + logo;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetGroupMenuThemes(int grpid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/MenuBackImages/" + grpid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/MenuBackImages/" + grpid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string GetOrgMenuThemes(int OrgId, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/orgmenubackimage/" + OrgId.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/orgmenubackimage/" + OrgId.ToString() + "/" + logo;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string GetLoginbgImage(Int32 OrgId, string images)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/orgloginbgimages/" + OrgId.ToString() + "/" + images);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/orgloginbgimages/" + OrgId.ToString() + "/" + images;
                }
                else
                {
                    return "";
                }
            }
            catch
            {

                return "";
            }
        }
        public static string GetGroupLoginbgImage(Int32 GroupId, Int32 OrgId, string images)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/grouplogbgimages/" + GroupId.ToString() + "/" + images);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/grouplogbgimages/" + GroupId.ToString() + "/" + images;
                }
                else
                {
                    return websiteurl + "/content/orgloginbgimages/" + OrgId.ToString() + "/" + images;
                }
            }
            catch
            {

                return "";
            }
        }
        public static string GetSocialMediaLogo(Int32 MediaTypeId, string Logo)
        {
            string image = HttpContext.Current.Server.MapPath("~/content/eventmediaicons/" + MediaTypeId.ToString() + "/" + Logo);
            try
            {
                if (File.Exists(image))
                {
                    return websiteurl + "/content/eventmediaicons/" + MediaTypeId.ToString() + "/" + Logo;
                }
                else
                {
                    return noimage;
                }
            }
            catch
            {

                return noimage;
            }
        }
        public static string GetDailyDevotionImage(int DevotionId, string Image)
        {
            if (string.IsNullOrEmpty(Image))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/dailydevotion/" + DevotionId.ToString() + "/" + Image);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/dailydevotion/" + DevotionId.ToString() + "/" + Image;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string GetClientLogo(Int32 clientid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/clientlogo/" + clientid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/clientlogo/" + clientid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }

        public static string GetProjectImage(Int32 OrgId, string mainimage)
        {
            if (string.IsNullOrEmpty(mainimage))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/projects/" + OrgId.ToString() + "/" + mainimage);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/projects/" + OrgId.ToString() + "/" + mainimage;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetProjectImages(Int32 projectid, Int64 imgid, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/projects/" + projectid.ToString() + "/images/" + imgid.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/projects/" + projectid.ToString() + "/images/" + imgid.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string getsmartquizurl(Int32 id, Int64 orgid)
        {
            return websiteurl + "qr/smartquiz?id=" + id.ToString() + "_" + orgid.ToString() + "_3_4";
        }
        public static string getSmartQuizImage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/smartquizimages/" + id.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/smartquizimages/" + id.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }

        public static string getquizurl(Int32 id, Int64 orgid)
        {
            return websiteurl + "qr/quiz?id=" + id.ToString() + "_" + orgid.ToString() + "_6_4";
        }
        public static string getQuizImage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/quizimages/" + id.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/quizimages/" + id.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string getSmartuizAnswerImage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/smartquizimages/" + id.ToString() + "/answers/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/smartquizimages/" + id.ToString() + "/answers/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }

        public static string getMessageImages(Int32 id, string fname)
        {
            if (string.IsNullOrEmpty(fname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/groupmessage/" + id.ToString() + "/" + fname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/groupmessage/" + id.ToString() + "/" + fname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }

        }
        public static string getspellquizurl(Int32 id, Int64 orgid)
        {
            return websiteurl + "qr/spellquiz?id=" + id.ToString() + "_" + orgid.ToString() + "_6_4";
        }
        public static string getspellQuizImage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/spellingbeequizimages/" + id.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/spellingbeequizimages/" + id.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }

        public static string GetWellbeingQuizImage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/wellbeingquizimages/" +id+"/"+  imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/wellbeingquizimages/" + id + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }

        public static string GetWellbeingQuizAnswerImage(Int32 aid,string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/wellbeinganswers/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/wellbeinganswers/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }

        public static string getChattingImages(string fname)
        {
            if (string.IsNullOrEmpty(fname))
            {
                return "";
            }
            else
            {
                //string image = HttpContext.Current.Server.MapPath("~/content/messages/" + fname);
                //try
                //{
                //if (File.Exists(image))
                //{
                return websiteurl + "/content/messages/" + fname;
                //}
                //    else
                //    {
                //        return "";
                //    }
                //}
                //catch
                //{

                //    return "";
                //}

            }

        }
        /// <summary>
        /// converts seconds to hours foramate(hh:mm:ss)
        /// </summary>
        /// <param name="seconds">seconds</param>
        /// <returns>string in x hrs y min z sec formate</returns>
        public static string ConvertSecondsToHoursFormat(Int64 seconds)
        {
            string res = "";
            int sign = seconds < 0 ? -1 : 1;
            seconds = seconds * sign;
            Int64 days = 0;
            Int64 minitues;
            // Int64 seconds;
            Int64 hours;
            //set minitues
            minitues = seconds / 60;
            seconds = seconds % 60;  //seconds

            hours = minitues / 60;  //set hours
            minitues = minitues % 60; //set minitues
            days = hours / 24; //set days
            hours = hours % 24;
            // res = (hours < 10 ? "0" : "") + hours + ":" + (minitues < 10 ? "0" : "") + minitues + ":" + (seconds < 10 ? "0" : "") + seconds;
            //res = (hours < 10 ? "0" : "") + hours + ":" + (minitues < 10 ? "0" : "") + minitues + ":" + (seconds < 10 ? "0" : "") + seconds;
            if (hours > 0)
            {
                res += hours.ToString() + (hours == 1 ? "h" : "h") + " ";
            }
            if (minitues > 0)
            {
                res += minitues.ToString() + (minitues == 1 ? "m" : "m") + " ";
            }
            if (seconds > 0)
            {
                res += seconds.ToString() + (seconds == 1 ? "s" : "s");
            }
            return res;
            //  return sign == -1 ? "- " + res : res;
        }
        public static string getsurveyimage(Int32 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/surveyimages/" + id.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/surveyimages/" + id.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string getsurveyurl(Int32 id, Int64 bid)
        {
            return websiteurl + "qr/survey?id=" + id.ToString() + "_" + bid.ToString() + "_3_4";
        }
        public static string SocialMediaLinkIcon(string img)
        {
            return websiteurl + "/content/images/" + img;
        }
        public static string SetNullasEmpty(string text)
        {
            return string.IsNullOrEmpty(text) ? "" : text; //System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(text);
        }
        public static string[] getpromotiomagepaths(Int64 id, string imgnames, char delimiter)
        {
            int len = 1;
            if (!string.IsNullOrEmpty(imgnames)) { len = imgnames.Split(delimiter).Length; }
            string[] images = new string[len];
            int i = 0;
            if (!string.IsNullOrEmpty(imgnames))
            {
                foreach (string imname in imgnames.Split(delimiter))
                {
                    string imgname = imname.TrimStart(delimiter).TrimEnd(delimiter);
                    if (string.IsNullOrEmpty(imgname))
                    {
                        continue;
                    }
                    else
                    {
                        string image = HttpContext.Current.Server.MapPath("~/content/promotions/" + id.ToString() + "/images/" + imgname);
                        try
                        {
                            if (File.Exists(image))
                            {
                                images[i] = websiteurl + "/content/promotions/" + id.ToString() + "/images/" + imgname;
                                i++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch
                        {

                            continue;
                        }

                    }

                }
            }
            return images;
        }
        public static string getpromotionimagepath(Int64 id, string imgname)
        {
            if (string.IsNullOrEmpty(imgname))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/promotions/" + id.ToString() + "/" + imgname);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/promotions/" + id.ToString() + "/" + imgname;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string getpromotionurl(Int64 id, Int32 bid)
        {
            return websiteurl + "qr/promotion?id=" + id.ToString() + "_" + bid.ToString() + "_1_4";
        }
        /// <summary>
        /// convert double with fixed digits.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalplaces"></param>
        /// <returns></returns>
        public static string numofdecimalformate(double value, int decimalplaces)
        {
            //value = Math.Round(value, decimalplaces);
            //return value.ToString();
            string fmate = "{0:0.";
            for (int i = 0; i < decimalplaces; i++)
            {
                fmate += "0";
            }
            fmate += "}";
            return string.Format(fmate, value);
        }
        public static string GetGameImage(int gid, string img)
        {
            if (string.IsNullOrEmpty(img))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/gameimages/" + gid.ToString() + "/" + img);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/gameimages/" + gid.ToString() + "/" + img;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string GetGameunsuccessfullimg(int gid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return "";
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/gameunsuccessfullimages/" + gid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/gameunsuccessfullimages/" + gid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {

                    return "";
                }

            }
        }
        public static string GetPrizeimg(Int64 pid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/prizeimages/" + pid.ToString() + "/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/prizeimages/" + pid.ToString() + "/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        public static string GetScratchimg(int pid, string logo)
        {
            if (string.IsNullOrEmpty(logo))
            {
                return noimage;
            }
            else
            {
                string image = HttpContext.Current.Server.MapPath("~/content/ScratchImages/" + logo);
                try
                {
                    if (File.Exists(image))
                    {
                        return websiteurl + "/content/ScratchImages/" + logo;
                    }
                    else
                    {
                        return noimage;
                    }
                }
                catch
                {

                    return noimage;
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ppc">Primary Prize Count</param>
        /// <param name="spc">Secondary Prize Count</param>
        /// <param name="cpc">Consolation Prize Count</param>
        /// <param name="pwc">Primary Prize Win Count</param>
        /// <param name="swc">Secondary Prize Win Count</param>
        /// <param name="cwc">Consolation Prize Win Count</param>
        /// <returns></returns>
        public static int getPrizeNumber(int ppc, int spc, int cpc, int pwc, int swc, int cwc)
        {
            Int64 Tpc = ppc + spc + cpc; // Total Prize Count
            Int64 Twc = pwc + swc + cwc; // Total Win Count
            Random r = new Random();
            int randomnum = r.Next(1, 3); // Select Random Prize Number
            if (Twc == 0)
            {
                return 3;
            }
            if (ppc < 4)
            {
                randomnum = 3;
            }
            int prizeid = 4; // Initialize By Default Unsusseccfull
            decimal ppratio = Convert.ToDecimal(ppc) / Convert.ToDecimal(Tpc);
            decimal pwratio = Convert.ToDecimal(pwc) / Convert.ToDecimal(Twc);
            decimal spratio = Convert.ToDecimal(spc) / Convert.ToDecimal(Tpc);
            decimal swratio = Convert.ToDecimal(swc) / Convert.ToDecimal(Twc);
            decimal cpratio = Convert.ToDecimal(cpc) / Convert.ToDecimal(Tpc);
            decimal cwratio = Convert.ToDecimal(cwc) / Convert.ToDecimal(Twc);
            switch (randomnum)
            {
                case 1: if (pwratio < ppratio)
                    {
                        prizeid = 1;
                    }
                    else if (cwratio < cpratio)
                    {
                        prizeid = 3;
                    }
                    else if (swratio < spratio)
                    {
                        prizeid = 2;
                    }
                    else
                    {
                        prizeid = 4;
                    }
                    break;
                case 2: if (swratio < spratio)
                    {
                        prizeid = 2;
                    }
                    else if (cwratio < cpratio)
                    {
                        prizeid = 3;
                    }
                    else if (pwratio < ppratio)
                    {
                        prizeid = 1;
                    }
                    else
                    {
                        prizeid = 4;
                    }
                    break;
                case 3: if (cwratio < cpratio)
                    {
                        prizeid = 3;
                    }
                    else if (swratio < spratio)
                    {
                        prizeid = 2;
                    }
                    else if (pwratio < ppratio)
                    {
                        prizeid = 1;
                    }
                    else
                    {
                        prizeid = 4;
                    }
                    break;
                default: prizeid = 4;
                    break;
            }
            return prizeid;
        }

        public static string GenerateRandomImgFileName(string fileext)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return new String(stringChars) + "-" + DateTime.UtcNow.ToString("dd MMM yyyy HH:mm:ss.fff").Replace("/", "").Replace("-", "").Replace("@", "").Replace(" ", "").Replace(":", "").Replace(",", "").Replace(".", "") + fileext;
        }
        public static string getpostgroupImages(string fname)
        {
            if (string.IsNullOrEmpty(fname))
            {
                return "";
            }
            else
            {
                //string image = HttpContext.Current.Server.MapPath("~/content/messages/" + fname);
                //try
                //{
                //if (File.Exists(image))
                //{
                return websiteurl + "/content/postmessages/" + fname;
                //}
                //    else
                //    {
                //        return "";
                //    }
                //}
                //catch
                //{

                //    return "";
                //}

            }
        }
    }
}
