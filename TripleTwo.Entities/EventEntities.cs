using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTwo.Entities
{
        public class EventMedia
        {
        public int EventMediaId { get; set; }
        public long EventId { get; set; }
        public int MediaType { get; set; }
        public string Media { get; set; }
        }
    public class GetEventsListParams:paggingEntity
    {
        public long EventId { get; set; }
    }

    public class GetEventsListResponse
    {
        public Int32 EventId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }

        public string StartDateString { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDateString { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string Image { get; set; }
        public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
        public string Description { get; set; }
    }

    public class EventEnquiryParams
    {
        public Int32 EventId { get; set; }
        public Int32 CustomerId { get; set; }
        public string Message { get; set; }

    }
    public class CustomerEnquiryResponse : Settings.BaseResponse
    {

    }
    public class CustomerSupportParams
    {
        public Int32 CustomerId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

    }
    public class CustomerSupportResponse : Settings.BaseResponse
    {

    }

    public class AddUpdateEventParams
        {
        public Int32 EventId { get; set; }
        public Int32 OrganisationTypeId { get; set; }
        public Int32 PartnerId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public List<string> Images { get; set; }
        //public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
        public string VideoFilename { get; set; }
        public string VideoBytes { get; set; }
        //public string EventVideoPath { get { return Settings.GetEventImage(this.EventId, this.Video); } }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public Int32 StateId { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int EventTypeId { get; set; }
        public int Status { get; set; }
        public int CountryId { get; set; }

    }

    
    public class AddUpdateEventResponse : Settings.BaseResponse
     {
     }

    public class EventMediaResponse
    {
        public Int32 EventId { get; set; }
        public int MediaType { get; set; }
        public string MediaPath { get { return Settings.GetEventImage(this.EventId, this.Media); } }
        public string Media { get; set; }
    }


    public class GetEventMediaResponse
    {
        public List<GetEventImagesResponse> EventImages { get; set; }

        public List<GetEventVideoResponse> EventVideos { get; set; }
    }

    public class GetEventImagesResponse
    {
        public Int32 EventId { get; set; }
        public string ImagePath { get; set; }
        public string Image { get; set; }
    }

    public class GetEventVideoResponse
    {
        public Int32 EventId { get; set; }
        public string VideoPath { get; set; }
        public string Video { get; set; }
    }



    public class GetEventDetailsResponse 
    {
        public Int32 EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        //public List<EventMediaResponse> EventMedia { get; set; }
        public DateTime? StartDate { get; set; }

        public string StartDateString { get { return Settings.SetDateTimeFormat(this.StartDate); } }
        public DateTime? EndDate { get; set; }
        public string EndDateString { get { return Settings.SetDateTimeFormat(this.EndDate); } }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
    }
    public class EventsEntityParams
        {
            public Int32 EventId { get; set; }
            public Int32 OrganisationTypeId { get; set; }
            public Int32 PartnerId { get; set; }
            public string Title { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }

            public string Image { get; set; }
            public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
            public string Video { get; set; }
            public string EventVideoPath { get { return Settings.GetEventImage(this.EventId, this.Video); } }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string ContactPerson { get; set; }
            public string ContactPhone { get; set; }
            public string ContactEmail { get; set; }
            public Int32 StateId { get; set; }
            public string City { get; set; }
            public string PostCode { get; set; }
            public int EventTypeId { get; set; }
            public int Status { get; set; }
            public int CountryId { get; set; }


        }

    public class EventsEntity
    {
        public Int32 EventId { get; set; }
        public Int32 OrganisationTypeId { get; set; }
        public Int32 PartnerId { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public string Image { get; set; }
        public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
        public string Video { get; set; }
        public string EventVideoPath { get { return Settings.GetEventImage(this.EventId, this.Video); } }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public Int32 StateId { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public int EventTypeId { get; set; }
        public int Status { get; set; }
        public int CountryId { get; set; }


    }
    public class EventDetailsEntity
        {

            public Int32 EventId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Video { get; set; }
            public string EventVideoPath { get { return Settings.GetEventImage(this.EventId, this.Video); } }
            public string Image { get; set; }

            public string EventImagePath { get { return Settings.GetEventImage(this.EventId, this.Image); } }
            public DateTime? StartDate { get; set; }

            public string StartDateString { get { return Settings.SetDateTimeFormat(this.StartDate); } }
            public DateTime? EndDate { get; set; }
            public string EndDateString { get { return Settings.SetDateTimeFormat(this.EndDate); } }
            public string ContactPerson { get; set; }
            public string ContactPhone { get; set; }
            public string ContactEmail { get; set; }
            public string Location { get; set; }

        }


}
