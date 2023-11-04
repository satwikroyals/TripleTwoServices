using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;
using static TripleTwo.Entities.Settings;

namespace TripleTwo.Entities
{

    

    public class AppEntity
    {
        public Int64 OrgId { get; set; }
        public Int64 PartnerId { get; set; }
        public string AndroidAppLink { get; set; }
        public string IosAppLink { get; set; }
        public string DeviceId { get; set; }
        public int DeviceType { get; set; }
        public Int64 CustomerId { get; set; }

    }

    public class AddUpdateCustomerResponse : BaseResponse
    {

    }

    public class AddUpdateCustomerParams
    {
        public Int64 CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string pin { get; set; }
        public string PostCode { get; set; }
        public int Status { get; set; }
    }
    public class CustomerMoodNotSetEntity
    {
        public Int32 CustomerId { get; set; }        
        public string fname { get; set; }
        public string lname { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string Profession { get; set; }
        public string CustomerImage { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Int32 CityId { get; set; }      
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.CustomerImage); } }
        public int DeviceType { get; set; }
        public string DeviceId { get; set; }
    }
  
    
    public class CustomerLoginEntity
    {
        public Int32 CustomerId { get; set; }
        public Int32 OrgId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public int AppType { get; set; }
    }
    public class Countryddl
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryFalgimg { get; set; }
        public string CountryImagePath { get { return Settings.GetCountryImage(this.CountryId, this.CountryFalgimg); } }
        public string TelephoneCode { get; set; }
    }
    public class Stateddl
    {
        public int CountryId { get; set; }
        public Int32 StateId { get; set; }
        public string State { get; set; }
    }
    public class Cityddl
    {
        public Int32 CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
    }
   
    
    public class EventSocialMediaEntity
    {
        public Int32 ESMediaId { get; set; }
        public Int32 EventId { get; set; }
        public int MediaTypeId { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaLogo { get; set; }
        public string SocialMediaLogopath { get { return Settings.GetSocialMediaLogo(this.MediaTypeId, this.SocialMediaLogo); } }
        public string SocialMediaLink { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
    }
    public class EventEntity
    {
        public Int32 EventId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 PartnerId { get; set; }
        public string OrgName { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
        public DateTime? StartDate { get; set; }
        public string StartDateString { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDateString { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CountryId { get; set; }
        public Int32 StateId { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public int EventTypeId { get; set; }
        public int IsBookingNeeded { get; set; }
        public double TicketPrice { get; set; }
        public int TicketsAvailable { get; set; }
        public int TicketsPerPerson { get; set; }
        public int TicketsBooked { get; set; }
        public string MediaTypeId { get; set; }
        public string SocialMediaLink { get; set; }
        public List<EventSocialMediaEntity> SocialMedia { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateString { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }
        public int Status { get; set; }
        public int EventAccess { get; set; }
        public string Sponsors { get; set; }
        public string Sponserdetails { get; set; }
        public string imgextension { get; set; }
       
    }
    
    public class MediaEntity
    {
        public Int32 MediaId { get; set; }
        public Int32 OrgId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string MediaImage { get { return Settings.GetMediaMainImage(this.MediaId, this.Image); } }
        public DateTime CreatedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string FormatedModifiedDate { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public int TotalRecords { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int imgcount { get; set; }
        public int vidcount { get; set; }
    }
    public class MediaDetailsEntity
    {
        public MediaEntity MediaDetails { get; set; }
        public List<MediaImagesEntity> Images { get; set; }
        public List<MediaImagesEntity> Videos { get; set; }
    }
    public class MediaImagesEntity
    {
        public Int64 MediaimgId { get; set; }
        public Int32 MediaId { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Thumbnailpath { get { return this.Type == 2 ? Settings.GetMediaImages(this.MediaId, this.MediaimgId, this.Thumbnail) : Thumbnail; } }
        public string path { get; set; }
        public string Imgpath { get { return this.Type == 1 ? Settings.GetMediaImages(this.MediaId, this.MediaimgId, this.path) : path; } }
        public DateTime CreatedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string FormatedModifiedDate { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }
        public int TotalRecords { get; set; }
    }
    public class PartnerEntity
    {
        #region private variable
        string _prname;
        string _orgname;
        string _email;
        string _phone;
        string _location;
        string _cname;
        string _ctname;
        string _postcode;
        string _website;
        string _desc;
        string _lvstream;
        string _msn;
        string _wsite;
        string _ptname;
        #endregion
        public Int32 PartnerId { get; set; }
        public string PartnerName { get { return this._prname; } set { _prname = Settings.SetNullasEmpty(value); } }
        public int OrgId { get; set; }
        public string OrgName { get { return this._orgname; } set { _orgname = Settings.SetNullasEmpty(value); } }
        public string Logo { get; set; }
        public string LogoPath { get { return Settings.GetPartnerLogo(this.PartnerId, this.Logo); } }
        // public string Images { get; set; }
        public string EmailId { get { return this._email; } set { _email = Settings.SetNullasEmpty(value); } }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get { return this._phone; } set { _phone = Settings.SetNullasEmpty(value); } }
        public string Location { get { return this._location; } set { _location = Settings.SetNullasEmpty(value); } }
        public int CountryId { get; set; }
        public string CountryName { get { return this._cname; } set { _cname = Settings.SetNullasEmpty(value); } }
        public int CityId { get; set; }
        public string CityName { get { return this._ctname; } set { _ctname = Settings.SetNullasEmpty(value); } }
        public Int32 StateId { get; set; }
        public string PostCode { get { return this._postcode; } set { _postcode = Settings.SetNullasEmpty(value); } }
        public string Website { get { return this._wsite; } set { _wsite = Settings.SetNullasEmpty(value); } }
        public string Description { get { return this._desc; } set { _desc = Settings.SetNullasEmpty(value); } }
        public string MediaTypeId { get; set; }
        public int PartnerTypeId { get; set; }
        public string PartnerType { get { return this._ptname; } set { _ptname = Settings.SetNullasEmpty(value); } }
        public string LiveStreaming { get { return this._lvstream; } set { _lvstream = Settings.SetNullasEmpty(value); } }
        public string Mission { get { return this._msn; } set { _msn = Settings.SetNullasEmpty(value); } }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string FormatedModifiedDate { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }
        public List<PartnerSocilaMediaLinksEntity> SocilaMediaLinks { get; set; }

    }
    public class PartnerImageEntity
    {
        public Int64 PImageId { get; set; }
        public Int32 PartnerId { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get { return Settings.GetPartnerImages(this.PartnerId, this.ImageName); } }
        public DateTime CreatedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string FormatedModifiedDate { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }

    }
    public class paggingEntity
    {
        public int pgsize { get; set; }
        public int pgindex { get; set; }
        public string str { get; set; }
        public int sortby { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Committee { get; set; }
    }

    public class paggingCustomerEntity
    {
        public int pgsize { get; set; }
        public int pgindex { get; set; }
        public string SearchMemberstr { get; set; }
        public string SearchEmailstr { get; set; }
        public string SearchMobilestr { get; set; }
        public int sortby { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
       
    }
    public class OrgEntity
    {
        public Int32 OrgId { get; set; }
        public int ComunionId { get; set; }
        public Int32 OrgTypeId { get; set; }
        public string OrgName { get; set; }
        public string OrganizerName { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public string LogoPath { get { return Settings.GetOrganisationLogo(this.OrgId, this.Logo); } }
        public string Website { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public Int32 StateId { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Description { get; set; }
        public int TotalRecords { get; set; }
        public string BackgroundImage { get; set; }
        public string BackgroundImagepath { get { return Settings.GetOrganisationThemes(this.OrgId, this.BackgroundImage); } }
        public string BannerImage { get; set; }
        public string BannerImagepath { get { return Settings.GetOrganisationThemes(this.OrgId, this.BannerImage); } }
        public string MenuBackImage { get; set; }
        public string MenuBackImagePath { get { return Settings.GetOrgMenuThemes(this.OrgId, this.MenuBackImage); } }
        public string Logbgimg { get; set; }
        public string LoginbgImagepath { get { return Settings.GetLoginbgImage(this.OrgId, this.Logbgimg); } }
        public string Primarycolor { get; set; }
        public string Secondarycolor { get; set; }
        public string Thirdcolor { get; set; }
        public string Textcolor { get; set; }
        public string Loginstring { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public string FormatedModifiedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }

        public string AndroidPushKey { get; set; }
        public string IphonePushKey { get; set; }
        public string SMSHeader { get; set; }
        public string AndroidAppSchema { get; set; }
        public string IosAppSchema { get; set; }
        public List<LoginbgimageEntity> Images { get; set; }
    }
    public class LoginbgEntity
    {
        public OrgEntity LoginDetails { get; set; }
        public string AndroidPushKey { get; set; }
        public List<LoginbgimageEntity> Images { get; set; }
    }
    public class LoginbgimageEntity
    {
        public Int32 OrgId { get; set; }
        public string Logbgimg { get; set; }
        public string LoginbgImagepath { get { return Settings.GetLoginbgImage(this.OrgId, this.Logbgimg); } }
    }
  
    public class MessageEntity
    {
        public Int32 GMSGId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 CustomerId { get; set; }
        public string Message { get; set; }
        public string CustomerImage { get; set; }
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.CustomerImage); } }
        public DateTime PostedDate { get; set; }
        public string FormatedPostedDate { get { return Settings.SetDateTimeFormat(this.PostedDate); } }
        public DateTime ApprovedDate { get; set; }
        public string FosmatedApprovedDate { get { return Settings.SetDateTimeFormat(this.ApprovedDate); } }
        public int Status { get; set; }
        public string SenderName { get; set; }
        public int Sender { get; set; }
        public string PostImage { get; set; }
        public string Imagepath { get { return Settings.getChattingImages(this.PostImage); } }
        public string PostVideo { get; set; }
        public string Videopath { get { return Settings.getChattingImages(this.PostVideo); } }
    }
    public class Organizationddl
    {
        public Int32 OrgId { get; set; }
        public string OrgName { get; set; }
        public Int32 OrgTypeId { get; set; }
        public string OrgType { get; set; }
    }
    public class MessageRequestEntity
    {
        public Int32 CSubId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 CustomerId { get; set; }
        public string FullName { get; set; }
        public string PImage { get; set; }
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.PImage); } }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int PostMessage { get; set; }
        public int TotalRecords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDateString { get { return Settings.SetDateFormat(this.ModifiedDate); } }
    }
  
    public class SearchTagddl
    {
        public int SearchTagIds { get; set; }
        public string SearchTag { get; set; }
    }
    public class TradeServiceTypeEntity
    {
        public Int32 CategoryId { get; set; }
        public Int32 ParentCatId { get; set; }
        public string Name { get; set; }
    }
    public class ServiceAtTimeddl
    {
        public Int32 ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
    }
    public class CustomerTradeServiceEntity
    {
        public Int32 CSTId { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 ServiceTypeId { get; set; }
        public Int32 TrademenId { get; set; }
        public string CategoryIds { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public string FormatedModifiedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
    }
    public class TrademenEntiy
    {
        public Int32 TrademenId { get; set; }
        public string TradeName { get; set; }
        public string Postcode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
    public class DailyDevotionEntity
    {
        public Int32 DevotionId { get; set; }
        public Int32 OrgId { get; set; }
        public DateTime? Date { get; set; }
        public string Datestring { get { return Settings.SetDateFormat(this.Date); } }
        public string Image { get; set; }
        public string Imagepath { get { return Settings.GetDailyDevotionImage(this.DevotionId, this.Image); } }
        public string Reference { get; set; }
        public string Title { get; set; }
        public int TotalRecords { get; set; }
        public string Links { get; set; }
        public string[] Linkobj
        {
            get { return Links.Split(','); }
        }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
    }
    public class ClientLinkEntity
    {
        public Int32 LinkId { get; set; }
        public Int32 ClientTyeId { get; set; }
        public Int32 ClientId { get; set; }
        public int ParentLinkId { get; set; }
        public string Name { get; set; }
        public string LinkUrl { get; set; }
        public List<ClientLinkEntity> SubLink { get; set; }
        public string Order { get; set; }
    }
    public class Cliententity
    {
        public Int32 ClientId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Logopath { get { return Settings.GetClientLogo(this.ClientId, this.Logo); } }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string ServerName { get; set; }
        public string UserId { get; set; }
        public string ServerPassword { get; set; }
        public string Address { get; set; }
        public Int16 CountryId { get; set; }
        public string CountryName { get; set; }
        public Int32 StateId { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int TotalRecords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
    }
    public class AdminEntity
    {
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class ProjectEntity
    {
        public Int32 ProjectId { get; set; }
        public Int32 OrgId { get; set; }
        public string ProjectName { get; set; }
        public string OrphanageName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public string Image { get; set; }
        public string ImagePath { get { return Settings.GetProjectImage(this.OrgId, this.Image); } }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
    }
    public class ProjectImgEntity
    {
        public ProjectEntity Project { get; set; }
        public List<ProjectImages> Images { get; set; }
    }
    public class ProjectImages
    {
        public Int32 ProjectimgId { get; set; }
        public Int32 ProjectId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Imgpath { get { return Settings.GetProjectImages(this.ProjectId, this.ProjectimgId, this.Image); } }
    }
    public class SmartQuizEntity : AppEntity
    {
        #region private variables
        string _smqname;
        string _smscode;
        string _qrcode;
        string _question;
        string _answer;
        string _qandqvalues;
        string _smquizcode;
        #endregion
        public Int32 SmartQuizId { get; set; }
        public string SmartQuizName { get { return Settings.SetFont(this._smqname); } set { _smqname = value; } }
        public Int32 SmartQuizQuestionId { get; set; }
        public Int32 SmartQuizAnswerId { get; set; }
        public string SmartQuizCode { get { return Settings.SetFont(_smquizcode); } set { _smquizcode = value; } }
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string SmsCode { get { return Settings.SetFont(this._smscode); } set { _smscode = value; } }
        public string SmartQuizImage { get; set; }
        public string SmartQuizImagepath { get { return Settings.getSmartQuizImage(this.SmartQuizId, this.SmartQuizImage); } }
        public string QRCode { get { return Settings.SetFont(this._qrcode); } set { _qrcode = value; } }
        public string QrcodePath { get { return Settings.getSmartQuizImage(SmartQuizId, QRCode); } }
        public string smartQuizurlpath { get { return Settings.getsmartquizurl(this.SmartQuizId, this.OrgId); } }
        public int IsReferFriend { get; set; }
        public string Question { get { return Settings.SetFont(_question); } set { _question = value; } }
        public int Status { get; set; }
        public string Answer { get { return Settings.SetFont(this._answer); } set { _answer = value; } }
        public string QandAValues { get { return Settings.SetFont(this._qandqvalues); } set { _qandqvalues = value; } }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }
        public Int64 StartedIn { get; set; }
        public Int64 EndedIn { get; set; }
        public int GameStatus
        {
            get
            {
                return StartedIn > 0 ? 1 : EndedIn > 0 ? 2 : 3;
            }
        }
        public string StartedInText
        {
            get { return StartedIn < 0 ? "" : Settings.ConvertSecondsToHoursFormat(StartedIn); }
        }
        public string EndedInText { get { return EndedIn < 0 ? "" : Settings.ConvertSecondsToHoursFormat(EndedIn); } }
        public int IsFinished { get; set; }
    }
    public class SmartQuizCustomerQuestion
    {
        public Int32 SmartQuizQuestionId { get; set; }
        public Int32 SmartQuizId { get; set; }
        public string Question { get; set; }
        public Int32 QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        public Int32 Correctanswer { get; set; }
        //   public DateTime CreatedDate { get; set; }
        public int IsquestionAvailable { get; set; }
        public List<SmartQuizAnswers> answers { get; set; }
    }
    public class SmartQuizAnswers
    {
        public Int32 SmartQuizAnswerId { get; set; }
        public Int32 SmartQuizQuestionId { get; set; }
        public Int32 QuestionNumber { get; set; }
        public Int32 SmartQuizId { get; set; }
        public Int32 AnswerNumber { get; set; }
        public Int32 QestionNumber { get; set; }
        public string AnswerImage { get; set; }
        public string AnswerImagePath { get { return Settings.getSmartuizAnswerImage(this.SmartQuizId, this.AnswerImage); } }
        //  public DateTime CreatedDate { get; set; }
    }

    public class SmartQuizQuestionAndAnswer
    {
        public SmartQuizEntity SmartQuizDetails { get; set; }
        public List<SmartQuizQuestions> Question { get; set; }
    }
    public class SmartQuizQuestions
    {
        public Int32 SmartQuizQuestionId { get; set; }
        public Int32 SmartQuizId { get; set; }
        public Int32 QuestionId { get; set; }
        public Int32 SurveyId { get; set; }
        public string Question { get; set; }
        public int QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        public Int32 Correctanswer { get; set; }
        //  public DateTime CreatedDate { get; set; }
        public List<SmartQuizAnswers> answers { get; set; }
    }

    public class SmartquizResultEntity
    {
        public Int32 SmartQuizResultId { get; set; }
        public Int32 SmartQuizId { get; set; }
        public int AnsweredCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string SmartQuizName { get; set; }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public Int32 TotalRecords { get; set; }
    }
    public class PostMessage
    {
        public Int32 orgid { get; set; }
        public Int32 cid { get; set; }
        public string msg { get; set; }
        public string Pimage { get; set; }
        public string Pvideo { get; set; }
        public string imgextension { get; set; }
        public string vidextension { get; set; }
    }
    public class ChatPostMessage
    {
        public Int32 orgid { get; set; }
        public Int64 frmid { get; set; }
        public Int64 toid{get;set;}
        public string toids { get; set; }
        public int ismultiple { get; set; }
        public int isgroup { get; set; }
        public string msg { get; set; }
        public string Pimage { get; set; }
        public string Pvideo { get; set; }
        public string imgextension { get; set; }
        public string vidextension { get; set; }
        public Int64 chatid{get;set;}
    }
    public class ChatList
    {
        public Int64 ChatId { get; set; }
        public Int64 CustomerId { get; set; }
        public int IsGroup { get; set; }
        public Int64 LastMessageId { get; set; }
        public  string MessageText{get;set;}
        public string Image{get;set;}
        public string ImagePath{get{return Settings.getChattingImages(Image);}}
        public string Video{get;set;}
        public  string VideoPath{get{return Settings.getChattingImages(Video);}}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get { return this.FirstName+" "+this.LastName;}}
        public string PImage{get;set;}
        public string ProfileImage { get { return Settings.GetCustomerProfileImage(CustomerId, PImage); } }

        public DateTime LastMessageDate { get; set; }
        public string LastMessageDatestring { get { return Settings.SetDateTimeFormat(this.LastMessageDate); } }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }

    }
    public class ChatMessages
    {
        public Int64 SenderId{get;set;}
        public string SenderName{get;set;}
        public string SenderImage{get;set;}
        public string SenderImagePath{get{return Settings.GetCustomerProfileImage(SenderId,SenderImage);}}
        public Int64 ReceiverId{get;set;}
        public string ReceiverName{get;set;}
        public string ReceiverImage{get;set;}
        public string ReceiverImagePath{get{return Settings.GetCustomerProfileImage(ReceiverId,ReceiverImage);}}
        public Int64 ChatId{get;set;}
        public Int64 MessageId{get;set;}
        public string MessageText{get;set;}
        public string Image{get;set;}
        public string ImagePath{get{return Settings.getChattingImages(Image);}}
        public string Video{get;set;}
        public  string VideoPath{get{return Settings.getChattingImages(Video);}}
        public int IsSender{get;set;}
        public DateTime? CreatedDate { get; set; }
        public string CreatedDateString { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
    }
    public class SurveyEntity : AppEntity
    {
        public Int32 SurveyId { get; set; }
        public Int32 SurveyquestionId { get; set; }
        public Int32 SurveyanswerId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateFormat(this.EndDate); } }
        public string SmsCode { get; set; }
        public string Surveyimage { get; set; }
        public string Surveyimagepath { get { return Settings.getsurveyimage(this.SurveyId, this.Surveyimage); } }
        public string QRCode { get; set; }
        public string QrcodePath { get { return Settings.getsurveyimage(SurveyId, QRCode); } }
        public string surveyurlpath { get { return Settings.getsurveyurl(this.SurveyId, this.PartnerId); } }
        public int IsReferFriend { get; set; }
        public string Question { get; set; }
        public int Status { get; set; }
        public string Answer { get; set; }
        public string QandAValues { get; set; }
        public string SurveyquestionIds { get; set; }
        public int Generalpublic { get; set; }
        public int Selectmember { get; set; }
        public string SurveyanswerIds { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public string TotalRecords { get; set; }
    }
    public class SurveyQuestions
    {
        public Int32 SurveyquestionId { get; set; }
        public Int32 questionId { get; set; }
        public Int32 SurveyId { get; set; }
        public string Question { get; set; }
        public string QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        public Int32 Correctanswer { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SurveyAnswers> answers { get; set; }
    }
    public class SurveyAnswers
    {
        public Int32 SurveyanswerId { get; set; }
        public Int32 SurveyquestionId { get; set; }
        public string Answer { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class SurveyQuestionandAnswer
    {
        public SurveyEntity SurveyDetails { get; set; }
        public List<SurveyQuestions> question { get; set; }
        //public List<SurveyAnswers> answers { get; set; }
    }
    public class SurveyReportEntity
    {
        public Int32 SurveyId { get; set; }
        public string SurveyName { get; set; }
        public string SurveyCode { get; set; }
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateFormat(this.EndDate); } }
        public string SmsCode { get; set; }
        public string Surveyimage { get; set; }
        public string Surveyimagepath { get { return Settings.getsurveyimage(this.SurveyId, this.Surveyimage); } }
        public string QRCode { get; set; }
        public int IsReferFriend { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public string TotalRecords { get; set; }
        public int Attempted { get; set; }
    }
    public class SurveyCustomerReportResult
    {
        public Int64 SurveyResultId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 SurveyId { get; set; }
        public int CorrectAnswerCount { get; set; }
        public int AnsweredCount { get; set; }
        public DateTime StartTime { get; set; }
        public string StartTimeString { get { return Settings.SetDateTimeFormat(this.StartTime); } }
        public DateTime EndTime { get; set; }
        public string EndTimeString { get { return Settings.SetDateTimeFormat(this.StartTime); } }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string TotalRecords { get; set; }
    }
    public class SurveyCustomerQuestion
    {
        public Int32 SurveyquestionId { get; set; }
        public Int32 SurveyId { get; set; }
        public string Question { get; set; }
        public string QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        public Int32 Correctanswer { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsquestionAvailable { get; set; }
        public List<SurveyAnswers> answers { get; set; }
    }
    public class SurveyResult
    {
        public Int64 SurveyResultId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int32 SurveyquestionId { get; set; }
        public Int32 SurveyId { get; set; }
        public string Question { get; set; }
        public string QuestionNum { get; set; }
        public string Answer { get; set; }
    }
    public class PartnerTypeddl
    {
        public Int32 PartnerTypeId { get; set; }
        public string PartnerType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class PartnerSocilaMediaLinksEntity
    {
        #region private variable
        string _scmedia;
        string _scmlink;
        #endregion
        public Int64 PMediaId { get; set; }
        public Int32 PartnerId { get; set; }
        public int MediaTypeId { get; set; }
        public string SocialMediaLink { get { return this._scmlink; } set { _scmlink = Settings.SetNullasEmpty(value); } }
        public string SocialMedia { get { return this._scmedia; } set { _scmedia = Settings.SetNullasEmpty(value); } }
        public string SocialMediaLogo { get; set; }
        public string MediaImage { get { return Settings.SocialMediaLinkIcon(this.SocialMediaLogo); } }
        public DateTime CreatedDate { get; set; }
        public string FormatedCreatedDate { get { return Settings.SetDateTimeFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string FormatedModifiedDate { get { return Settings.SetDateTimeFormat(this.ModifiedDate); } }
    }

    public class Attributes
    {
        public Int64 AttributeId { get; set; }
        public int PartnerTypeId { get; set; }
        public string Attribute { get; set; }
        public string AttributeName { get; set; }
        public string[] values { get; set; }
    }
    public class PromotionEntity
    {
        public Int64 PromotionId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerLogo { get; set; }
        public string PartnerLogoPath { get { return Settings.GetPartnerLogo(this.PartnerId, this.PartnerLogo); } }
        public string PartnerEmail { get; set; }
        public string PartnerMobile { get; set; }
        public string Locations { get; set; }
        public string PromotionName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? Startdate { get; set; }
        public string StartDatestring { get { return Settings.SetDateFormat(this.Startdate); } }
        public DateTime? Enddate { get; set; }
        public string EndDatestring { get { return Settings.SetDateFormat(this.Enddate); } }
        public string SMSCode { get; set; }
        public string YoutubeShareLink { get; set; }
        public int PromotioinPrivacy { get; set; }
        public int BuyingStyle { get; set; }
        public int IsReferFrnd { get; set; }
        public int IsAddressRequire { get; set; }
        public string PromotionImage { get; set; }
        public string PromotionMultiImages { get; set; }
        public string[] PromotionMuttiInagePaths { get { return Settings.getpromotiomagepaths(PromotionId, PromotionMultiImages, ';'); } }
        public string PromotionImagePath { get { return Settings.getpromotionimagepath(PromotionId, PromotionImage); } }
        public string QRcode { get; set; }
        public string QrcodePath { get { return Settings.getpromotionimagepath(PromotionId, QRcode); } }
        public string promotionurlpath { get { return Settings.getpromotionurl(this.PromotionId, this.OrgId); } }
        public string Conditions { get; set; }
        public string Description { get; set; }
        public double RetailPrice { get; set; }
        public double CostofGoods { get; set; }
        public double DiscountPrice { get; set; }
        public double SellingPrice { get; set; }
        public double Weight { get; set; }
        public int Status { get; set; }
        public string PromoCode { get; set; }
        public int TotalRecords { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public List<PromotionImages> PromotionImages { get; set; }
        public string Attributes { get; set; }
        public string AttributeVales { get; set; }
        public Int64 AttributeId { get; set; }
        public string AttributeName { get; set; }
        public List<Attributes> Attrlist
        {
            get
            {
                if (string.IsNullOrEmpty(AttributeVales))
                {
                    return new List<Attributes>();
                }
                string[] at = AttributeVales.TrimEnd(']').Split(']');
                List<Attributes> al = new List<Attributes>();
                foreach (string x in at)
                {
                    Attributes a = new Attributes();
                    a.AttributeId = Convert.ToInt64(x.Split('_')[0]);
                    a.Attribute = x.Split('_')[1].Split('[')[0];
                    a.values = x.Split('_')[1].Split('[')[1].TrimEnd(';').TrimStart(';').Split(';');
                    al.Add(a);
                }

                return al;
            }
        }
    }
    public class PromotionImages
    {
        public Int64 PromotionImgId { get; set; }
        public Int64 PromotionId { get; set; }
        public string ImageName { get; set; }
    }
    public class PromotionCategoryEntity
    {
        public Int64 CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Int64 ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public int IsActive { get; set; }
    }
    public class COrderItems : AppEntity
    {
        public Int64 CorderId { get; set; }

        public Int64 PromotionId { get; set; }
        public double ItemCost { get; set; }
        public int ItemQty { get; set; }
        public double ItemTotalCost { get; set; }
        public string Attributes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class RedeemPromotionEntity
    {

        public Int64 COrderId { get; set; }
        public Int64 OrderItemId { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemTotalCost { get; set; }
        public int ItemQty { get; set; }
        public Int64 PromotionId { get; set; }
        public string Attributes { get; set; }
        public string RedeemCode { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerLogo { get; set; }
        public string PromotionName { get; set; }
        public string PromotionImage { get; set; }
        public string CustomerName { get; set; }
        public int OrderStatus { get; set; }
        public int TotalRecords { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public string PromotionImagePath { get { return Settings.getpromotionimagepath(PromotionId, PromotionImage); } }
        public string PartnerLogoPath { get { return Settings.GetPartnerLogo(this.PartnerId, this.PartnerLogo); } }
    }
    public class PartnerLocationEntity
    {
        public Int64 LocationId { get; set; }
        public Int32 PartnerId { get; set; }
        public string LocationName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Int32 StateId { get; set; }
        public Int32 CountryId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int TotalRecords { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
    }


    public class GameEntity : AppEntity
    {
        public Int32 GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameImage { get; set; }
        public string GameImagepath { get { return Settings.GetGameImage(this.GameId, this.GameImage); } }
        public string BusinessLocations { get; set; }
        public string GameDescription { get; set; }
        public string ConditionsApply { get; set; }
        public DateTime? Startdate { get; set; }
        public string StartDatestring { get { return Settings.SetDateFormat(this.Startdate); } }
        public DateTime? Enddate { get; set; }
        public string EndDatestring { get { return Settings.SetDateFormat(this.Enddate); } }
        public int ChanceCount { get; set; }
        public int Status { get; set; }
        public int PrimaryWinImageId { get; set; }
        public int SecondaryWinImageId { get; set; }
        public int ConsolationImageId { get; set; }
        public string ScratchImage { get; set; }
        public int ScratchCoverImageId { get; set; }
        public string ScratchImagePath { get { return Settings.GetScratchimg(this.ScratchCoverImageId, this.ScratchImage); } }
        public string QRCode { get; set; }
        public int LimitCount { get; set; }
        public Int32 OnceIn { get; set; }
        public string PrimaryWinMessage { get; set; }
        public string SecondaryWinMessage { get; set; }
        public string ConsolationMessage { get; set; }
        public int PointsAwarded { get; set; }
        public string PermitNumber { get; set; }
        public string ClassNumber { get; set; }
        public Int32 PrimaryPrizeCount { get; set; }
        public Int32 SecondaryPrizeCount { get; set; }
        public Int32 ConsolationPrizeCount { get; set; }
        public int IsPayment { get; set; }
        public double PaymentAmount { get; set; }
        public string UnSuccessfulImage { get; set; }
        public string Unsuccessfullimagepath { get { return Settings.GetGameunsuccessfullimg(this.GameId, this.UnSuccessfulImage); } }
        public string PrimaryImage { get; set; }
        public string PrimaryImagePath { get { return Settings.GetPrizeimg(this.PrimaryWinImageId, this.PrimaryImage); } }
        public string SecondaryImage { get; set; }
        public string SecondaryImagePath { get { return Settings.GetPrizeimg(this.SecondaryWinImageId, this.SecondaryImage); } }
        public string ConsolationImage { get; set; }
        public string ConsolationImagePath { get { return Settings.GetPrizeimg(this.ConsolationImageId, this.ConsolationImage); } }
        public string ExpiryText { get; set; }
        public int ReferFriend { get; set; }
        public int GameTypeId { get; set; }
        public int BrandGameFrequencyId { get; set; }
        public int IsReferaFriendConditional { get; set; }
        public string SmsCode { get; set; }
        public int IntervalId { get; set; }
        public string Interval { get; set; }
        public int PrimaryPrizeWinCount { get; set; }
        public int SecondaryPrizeWinCount { get; set; }
        public int ConsolationPrizeWinCount { get; set; }
        public int TotalBalCount { get; set; }
        public int TotalEntries { get; set; }
        public int TotalRecords { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatesrting { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public int GameStarted { get; set; }
    }
    public class ScratchImagesEntity
    {
        public int ScratchCoverImageId { get; set; }
        public string ScratchImage { get; set; }
    }
    public class GamePrizeEntity
    {
        public Int32 GamePrizeId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 PartnerId { get; set; }
        public string PrizeName { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int IsConditioned { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string PrizeImage { get; set; }
        public string PrizeImagePath { get { return Settings.GetPrizeimg(this.GamePrizeId, this.PrizeImage); } }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GameFrequencyEntity
    {
        public Int32 GameFrequencyId { get; set; }
        public string Frequency { get; set; }
    }
    public class GameResult
    {
        public Int32 GameId { get; set; }
        public Int32 CustomerGameFrequencyId { get; set; }
        public int PrizeNumber { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public string ConditionsApply { get; set; }
        public Int64 PrizeId { get; set; }
        public string WinMessage { get; set; }
        public string PrizeImgName { get; set; }
        public string UnSuccessfulImage { get; set; }
        public string PrizeImagePath { get { return PrizeId == -1 ? Settings.GetGameunsuccessfullimg(this.GameId, this.UnSuccessfulImage) : Settings.GetPrizeimg(this.PrizeId, this.PrizeImgName); } }
        public string ScratchImage { get; set; }
        public int ScratchCoverImageId { get; set; }
        public string ScratchImagePath { get { return Settings.GetScratchimg(this.ScratchCoverImageId, this.ScratchImage); } }
        public Int64 CustomerId { get; set; }
        public string Interval { get; set; }
        public Int64 IntervalId { get; set; }
    }
    public class CustomerGamePrizes
    {
        public Int64 CustomerGameFrequencyId { get; set; }
        public Int32 CustomerId { get; set; }
        public Int16 FrequencyId { get; set; }
        public DateTime EndDate { get; set; }
        public string Finished { get { return Settings.SetDateFormat(this.EndDate); } }
        public int PrizeNumber { get; set; }
        public Int64 PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string PrizeImage { get; set; }
        public string PrizeImagePath { get { return Settings.GetPrizeimg(this.PrizeId, this.PrizeImage); } }
    }

    public class CommunicationEntity
    {
        public Int64 CommunicationId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 FromId { get; set; }
        public Int16 FromType { get; set; }
        public string ToIds { get; set; }
        public Int16 ToType { get; set; }
        public string SessionId { get; set; }
        public string Message { get; set; }
        public int CommunicationTypeId { get; set; }
        public string CommunicationType { get; set; }
        public Int16 MarketingTypeId { get; set; }
        public Int64 MarketingItemId { get; set; }
        public Int64 ReceipentCount { get; set; }
        public Int64 TemplateId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LiveStream { get; set; }
        public int IsLiveStream { get; set; }
        public int IsCommericial { get; set; }
        public string CreatedDateString { get { return Settings.SetDateFormat(CreatedDate); } }
        public Int32 TotalRecords { get; set; }
    }

    public class UsersLists
    {
        public string ci;
        public string rcpt;
        public string name;
        public string navurl;
        public string ressession;
    }



    public class QuizEntity : AppEntity
    {
        #region private variables
        string _smqname;
        string _smscode;
        string _qrcode;
        string _question;
        string _answer;
        string _qandqvalues;
        string _smquizcode;
        #endregion
        public Int32 QuizId { get; set; }
        public string QuizName { get { return Settings.SetFont(this._smqname); } set { _smqname = value; } }
        public Int32 QuizQuestionId { get; set; }
        public Int32 QuizAnswerId { get; set; }
        public string QuizCode { get { return Settings.SetFont(_smquizcode); } set { _smquizcode = value; } }
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string SmsCode { get { return Settings.SetFont(this._smscode); } set { _smscode = value; } }
        public string QuizImage { get; set; }
        public string QuizImagepath { get { return Settings.getQuizImage(this.QuizId, this.QuizImage); } }
        public string QRCode { get { return Settings.SetFont(this._qrcode); } set { _qrcode = value; } }
        public string QrcodePath { get { return Settings.getQuizImage(QuizId, QRCode); } }
        public string Quizurlpath { get { return Settings.getsmartquizurl(this.QuizId, this.OrgId); } }
        public int IsReferFriend { get; set; }
        public string Question { get { return Settings.SetFont(_question); } set { _question = value; } }
        public int Status { get; set; }
        public string Answer { get { return Settings.SetFont(this._answer); } set { _answer = value; } }
        public string QandAValues { get { return Settings.SetFont(this._qandqvalues); } set { _qandqvalues = value; } }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }

        public Int64 StartedIn { get; set; }
        public Int64 EndedIn { get; set; }
        public int GameStatus
        {
            get
            {
                return StartedIn > 0 ? 1 : EndedIn > 0 ? 2 : 3;
            }
        }
        public string StartedInText
        {
            get { return StartedIn > 0 ? "" : Settings.ConvertSecondsToHoursFormat(StartedIn); }
        }
        public string EndedInText { get { return EndedIn > 0 ? "" : Settings.ConvertSecondsToHoursFormat(EndedIn); } }
        public int IsFinished { get; set; }
    }
    public class QuizCustomerQuestion
    {
        public Int32 QuizQuestionId { get; set; }
        public Int32 QuizId { get; set; }
        public string Question { get; set; }
        public Int32 QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        public Int32 Correctanswer { get; set; }
        //   public DateTime CreatedDate { get; set; }
        public int IsquestionAvailable { get; set; }
        public List<QuizAnswers> answers { get; set; }
    }
    public class QuizAnswers
    {
        public Int32 QuizAnswerId { get; set; }
        public Int32 QuizQuestionId { get; set; }
        public Int32 QuestionNumber { get; set; }
        public Int32 QuizId { get; set; }
        public Int32 AnswerNumber { get; set; }
        public Int32 QestionNumber { get; set; }
        public string Answer { get; set; }
        //  public DateTime CreatedDate { get; set; }
    }

    public class QuizQuestionAndAnswer
    {
        public QuizEntity QuizDetails { get; set; }
        public List<QuizQuestions> Question { get; set; }
    }
    public class QuizQuestions
    {
        public Int32 QuizQuestionId { get; set; }
        public Int32 QuizId { get; set; }
        public Int32 QuestionId { get; set; }
        public string Question { get; set; }
        public int QuestionNum { get; set; }
        public Int32 CorrectAnswerId { get; set; }
        public int IsActive { get; set; }
        //public Int32 Correctanswer { get; set; }
        //  public DateTime CreatedDate { get; set; }
        public List<QuizAnswers> answers { get; set; }
    }

    public class quizResultEntity
    {
        public Int32 QuizResultId { get; set; }
        public Int32 QuizId { get; set; }
        public int AnsweredCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string QuizName { get; set; }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public Int32 TotalRecords { get; set; }
        public Int64 Rank { get; set; }
        public int IsSelf { get; set; }
    }

    public class smartquizresultEntity
    {
        public Int32 SmartQuizResultId { get; set; }
        public Int32 SMartQuizId { get; set; }
        public int AnsweredCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string SmartQuizName { get; set; }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public Int32 TotalRecords { get; set; }
        public Int64 Rank { get; set; }
        public int IsSelf { get; set; }
    }

    public class SpellingBeeQuizEntity : AppEntity
    {
        #region private variables
        string _smqname;
        string _smscode;
        string _qrcode;
        string _question;
        string _answer;
        string _qandqvalues;
        string _smquizcode;
        #endregion
        public Int32 SpellingBeeQuizId { get; set; }
        public string QuizName { get { return Settings.SetFont(this._smqname); } set { _smqname = value; } }
        public Int32 QuizQuestionId { get; set; }
        public Int32 QuizAnswerId { get; set; }
        public string QuizCode { get { return Settings.SetFont(_smquizcode); } set { _smquizcode = value; } }
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string SmsCode { get { return Settings.SetFont(this._smscode); } set { _smscode = value; } }
        public string SpellingBeeImage { get; set; }
        public string SpellingBeeImagepath { get { return Settings.getspellQuizImage(this.SpellingBeeQuizId, this.SpellingBeeImage); } }
        public string QRCode { get { return Settings.SetFont(this._qrcode); } set { _qrcode = value; } }
        public string QrcodePath { get { return Settings.getspellQuizImage(SpellingBeeQuizId, QRCode); } }
        public string Quizurlpath { get { return Settings.getspellquizurl(this.SpellingBeeQuizId, this.OrgId); } }
        public int IsReferFriend { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }

        public Int64 StartedIn { get; set; }
        public Int64 EndedIn { get; set; }
        public int GameStatus
        {
            get
            {
                return StartedIn > 0 ? 1 : EndedIn > 0 ? 2 : 3;
            }
        }
        public string StartedInText
        {
            get { return StartedIn > 0 ? "" : Settings.ConvertSecondsToHoursFormat(StartedIn); }
        }
        public string EndedInText { get { return EndedIn > 0 ? "" : Settings.ConvertSecondsToHoursFormat(EndedIn); } }
        public Int64 ResultId { get; set; }
        public int IsFinished { get; set; }
        public int Duration { get; set; }
    }
    public class SpellingBeeQuestions
    {
        public Int32 SpellingBeeQuestionId { get; set; }
        public Int32 SpellingBeeQuizId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        public string Hint1 { get; set; }
        public string Hint2 { get; set; }
    }
    public class SpellingBeeQuizAndQuestions
    {
        public SpellingBeeQuizEntity QuizDetails { get; set; }
        public List<SpellingBeeQuestions> Qestions { get; set; }
    }

    public class SpellingBeeResultEntity
    {
        public Int32 SpellingBeeQuizResultId { get; set; }
        public Int32 SpellingBeeQuizId { get; set; }
        public int AnsweredCount { get; set; }
        public int CorrectAnswerCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string QuizName { get; set; }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public Int32 TotalRecords { get; set; }
        public Int64 Rank { get; set; }
        public int IsSelf { get; set; }
        public int Points { get; set; }
    }

    public class SpellingBeeCustAnswers
    {
        public Int64 QuestionId { get; set; }
        public int QuestionNumber { get; set; }
        public string Answer { get; set; }
        public int IsCorrect { get; set; }
        public int UsedHints { get; set; }
        public int Points { get; set; }
    }
    public class SpellingBeeCustQuizAnswers
    {
        public Int64 QuizId { get; set; }
        public Int64 CustomerId { get; set; }
        public int Duration { get; set; }
        public int CorrectAnsweredCount { get; set; }
        public int AnsweredCount { get; set; }
        public int Points { get; set; }
        public List<SpellingBeeCustAnswers> Answers { get; set; }
    }
    public class Quizddl
    {
        public Int64 QuizId { get; set; }
        public string QuizName { get; set; }
    }
    public class CustomerFriendEntity 
    {
        public Int32 CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CustomerImage { get; set; }
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.CustomerImage); } }
        public int IsFriend { get; set; }
        public Int32 MoodId { get; set; }
        public string MoodIcon { get { return Settings.GetMoodIcon(this.MoodId.ToString()); } }
        public string Mood { get { return Settings.GetMood(this.MoodId); } }
    }

    public class GetCustomerFriendsResponse
    {
        public Int32 CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CustomerImage { get; set; }
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.CustomerImage); } }
        public int Requestsent { get; set; }
        public string RequestStatus { get; set; }
    }

    public class AddOrRemoveFriendParam
    {
        public Int32 CustomerId { get; set; }
        public Int32 CustomerFriendId { get; set; }

            public Int32 Action { get; set; }
    }

    public class AddOrRemoveFriendResponse:BaseResponse
    {

    }

    public class BusinessDetailEntity
    {
        public string BusinessName { get; set; }
        public string BusinessLogo { get; set; }
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

    public class BusinessDetailResponse
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessLogo { get; set; }
        public string BusinessLogoPath { get { return Settings.GetBusinessLogoImage(this.BusinessId, this.BusinessLogo); } }
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
        //public string WebSiteUrl { get; set; }
    }


    public class BusinessListParam: paggingEntity
    {
        public int BusinessId { get; set; }
    }
    public class BusinessListResponse
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessLogo { get; set; }
        public string BusinessLogoPath { get { return Settings.GetBusinessLogoImage(this.BusinessId, this.BusinessLogo); } }
        public string Location { get; set; }
    }
    public class BusinessListEntity
    {


        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public Int32 BusinessTypeId { get; set; }
        public string BusinessLogo { get; set; }
        public string BusinessLogoPath { get { return Settings.GetBusinessLogoImage(this.BusinessId, this.BusinessLogo); } }
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
    public class MessagePostEntity
    {
        public Int32 GMSGId { get; set; }
        public Int32 OrgId { get; set; }
        public Int32 CustomerId { get; set; }
        public string Message { get; set; }
        public string CustomerImage { get; set; }
        public string CustomerImagePath { get { return Settings.GetCustomerProfileImage(this.CustomerId, this.CustomerImage); } }
        public DateTime PostedDate { get; set; }
        public string FormatedPostedDate { get { return Settings.SetDateTimeFormat(this.PostedDate); } }
        public DateTime ApprovedDate { get; set; }
        public string FosmatedApprovedDate { get { return Settings.SetDateTimeFormat(this.ApprovedDate); } }
        public int Status { get; set; }
        public string SenderName { get; set; }
        public int Sender { get; set; }
        public string PostImage { get; set; }
        public string Imagepath { get { return Settings.getpostgroupImages(this.PostImage); } }
        public string PostVideo { get; set; }
        public string Videopath { get { return Settings.getpostgroupImages(this.PostVideo); } }
    }
    public class CustomerQuizAnswers
    {
        public Int64 QuizId { get; set; }
        public Int64 CustomerId { get; set; }
        public int Duration { get; set; }
        public int CorrectAnsweredCount { get; set; }
        public int AnsweredCount { get; set; }
        public List<CustomerAnswers> Answers { get; set; }
    }
    public class CustomerAnswers
    {
        public Int64 QuestionId { get; set; }
        public Int16 QuestionNumber { get; set; }
        public Int64 AnswerId { get; set; }
        public Int16 AnswerNumber { get; set; }
        public int IsCorrect { get; set; }
    }
    public class CustomerGroupsEntity
    {
        public Int32 CGId { get; set; }
        public Int32 CustomerId { get; set; }
        public string GroupName { get; set; }
        public string GroupMembers { get; set; }
    }

    public class CustomerMoodParamsEntity
    {
        public Int32 CustomerMoodId { get; set; }
        public Int32 CustomerId { get; set; }
        public int MoodId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location{ get; set; }
        public DateTime AddedDate { get;set; }
        public string AddedDateDisplay { get { return Settings.SetDateFormat(this.AddedDate); } }
        public Int32 OrganisationId { get; set; }
    }

    public class CustomerMoodReportParamsEntity:paggingEntity
    {
        public Int32 OrganisationId { get; set; }        
        public int MoodId { get; set; }
        public string Name { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
      
    }

    public class CustomerMoodContacts
    {
        public Int32 MoodContactId { get; set; }
        public Int32 CustomerId { get; set; }
        public string ContactNumber { get; set; }
        public string ContactName { get; set; }
        public int IsProfessional { get; set; }
        public string ProfessionalDesignation { get; set; }
        public Int32 ContactCustomerId { get; set; }
        public int DeviceType{ get; set; }
        public string DeviceId { get; set; }
    }

    public class CustomerMoodEntity
    {
        private string profileImage = "";
        //private string moodIcon = "";

        public Int32 MoodId { get; set; }
        public Int32 CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public string ProfileImage { 
            get { return profileImage;} 
            set
            { 
             profileImage= Settings.GetCustomerProfileImage(this.CustomerId, value); 
            }
        }
        public string MoodIcon { get { return Settings.GetMoodIcon(this.MoodId.ToString()); } }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedDateDisplay { get { return Settings.SetDateTimeFormat(this.AddedDate); } }
        public Int32 TotalRecords { get; set; }
    }

    public class CustomerMoodResponse
    {
       

        public Int32 MoodId { get; set; }
       
       
        public string MoodIcon { get { return Settings.GetMoodIcon(this.MoodId.ToString()); } }

        public string Mood { get { return Settings.GetMood(this.MoodId); } }

        public DateTime AddedDate { get; set; }
        public string AddedDateDisplay { get { return Settings.SetDateTimeFormat(this.AddedDate); } }
        
    }


    public class ResourceCategories
    {
        public Int32 OrganisationId { get; set; }
        public Int32 ResourceCatId { get; set; }
        public string CatName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestr { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestr { get { return Settings.SetDateFormat(this.ModifiedDate); } }

    }

    public class GetResourceParams
    {
        public Int32 OrganisationId { get; set; }
        

    }

    public class Resources
    {
        public Int32 OrganisationId { get; set; }
        public Int32 ResourceId { get; set; }
        public Int32 ResourceCatId { get; set; }
        public string CatName { get; set; }
        public string Title { get; set; }
        public string VideoLink { get; set; }
        public int VideoSourceId { get; set; }
        public string VideoSource { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestr { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestr { get { return Settings.SetDateFormat(this.ModifiedDate); } }

    }

    public class ResourcesResult
    {
        public Int32 ResourceCatId { get; set; }
        public string CatName { get; set; }
        public List<Resources> Resources { get; set; }

    }


    public class WellbeingQuizEntity : AppEntity
    {
        #region private variables
        string _smqname;
        string _smscode;
        string _qrcode;
        string _question;
        string _answer;
        string _qandqvalues;
        string _smquizcode;
        #endregion
        public Int32 QuizId { get; set; }
        public string QuizName { get { return Settings.SetFont(this._smqname); } set { _smqname = value; } }       
        public DateTime? StartDate { get; set; }
        public string StartDatestring { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDatestring { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string SmsCode { get { return Settings.SetFont(this._smscode); } set { _smscode = value; } }
        public string Image { get; set; }
        public string Imagepath { get { return Settings.GetWellbeingQuizImage(this.QuizId, this.Image); } }
        public string QRCode { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public Int64 TotalRecords { get; set; }
    }


    public class WellbeingQuestions
    {
        public Int32 QuestionId { get; set; }
        public Int32 QuizId { get; set; }
        public string Question { get; set; }
        public int QuestionNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
        public List<WellbeingQuestionAnswers> AnswersList { get; set; }
    }

    public class WellbeingQuestionAnswers
    {
        public Int32 AnswerId { get; set; }
        public Int32 QuestionId { get; set; }    
        public string AnswerText { get; set; }
        public string AnswerImage { get; set; }
        public string AnswerImagePath { get { return Settings.GetWellbeingQuizAnswerImage(this.AnswerId, this.AnswerImage); } }
        public int AnswerNumber { get; set; }
        public int IsConsider { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDatestring { get { return Settings.SetDateFormat(this.CreatedDate); } }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedDatestring { get { return Settings.SetDateFormat(this.ModifiedDate); } }
    }

    public class WellbeingQA
    {        
        public List<WellbeingQuestions> Qestions { get; set; }
        public List<WellbeingQuestionAnswers> Answers { get; set; }
    }

    public class WellbeingResultEntity
    {
        public Int32 QuizResultId { get; set; }
        public Int32 QuizId { get; set; }
        public Int32 CustomerId { get; set; }
        public int AnsweredCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string CustomerName { get; set; }
        public string Mobile { get; set; }
        public string QuizName { get; set; }
        public Int64 Duration { get; set; }
        public string DurationString { get { return Settings.ConvertSecondsToHoursFormat(this.Duration); } }
        public Int32 TotalRecords { get; set; }     
    }

    public class WellbeingQuizCustAnswered
    {
        public Int32 QuizResultId { get; set; }
        public Int32 CustomerId { get; set; }
        public Int32 QuizId { get; set; }
        public int AnsweredCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Int64 Duration { get; set; }
        public int IsFinished { get; set; }
        public int NeedtoContact { get; set; }
        public List<WellbeingCustAnswers> Answers { get; set; }
    }

    public class WellbeingCustAnswers
    {
        public Int32 CustomerAnswerId { get; set; }
        public Int32 QuizResultId { get; set; }
        public Int32 QuestionId { get; set; }        
        public string AnswerId { get; set; }
        public int AnswerNumber { get; set; }
        public string Reason { get; set; } 
    }

    public class WellbeingCustQuizAnswers
    {
        public Int64 QuizId { get; set; }
        public Int64 CustomerId { get; set; }
        public int Duration { get; set; }
        public int AnsweredCount { get; set; }
        public List<SpellingBeeCustAnswers> Answers { get; set; }
    }



}
