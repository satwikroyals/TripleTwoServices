using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TripleTwo.BAL;
using TripleTwo.Entities;
//using static TripleTwo.Entities.EventEntities;
//using static TripleTwo.Entities.Settings;

namespace TripleTwo.Services
{
    public class EventsController : ApiController
    {
        EventManager objsm = new EventManager();


        [Route("api/GetEventsList")]
        [HttpPost]
        public List<GetEventsListResponse> GetEventsList(GetEventsListParams p)
        {
            return objsm.GetEventsList(p);
        }

        [Route("api/AddEvent")]
        [HttpPost]
        public AddUpdateEventResponse AddEvent(AddUpdateEventParams p)
        {

            AddUpdateEventResponse res = new AddUpdateEventResponse();
            res= objsm.AddEvent(p);
            if(res.ResultID!=0)
            {
                int i = 1;
                foreach (string Image in p.Images)
                {
                    byte[] imagedata = Convert.FromBase64String(Image);
                    string generatefilename = p.Title+i.ToString();
                    i++;
                    string fileextence = ".jpg";
                    if (imagedata != null && imagedata.Length > 0 && res.ResultID > 0)
                    {
                        string strfilepath = System.Web.Hosting.HostingEnvironment.MapPath("~/content/events/" + res.ResultID.ToString() + "/") + generatefilename + fileextence;
                        FileStream targetStream = null;
                        MemoryStream ms = new MemoryStream(imagedata);
                        Stream Sourcestream = ms;
                        string uploadfolder = System.Web.Hosting.HostingEnvironment.MapPath("~/content/events/" + res.ResultID.ToString() + "/");
                        if (!Directory.Exists(uploadfolder))
                        {
                            Directory.CreateDirectory(uploadfolder);
                        }
                        string filename = generatefilename + fileextence;

                        
                        filename = Settings.GenerateRandomImgFileName(filename.Substring(filename.IndexOf('.')));
                        string filePath = Path.Combine(uploadfolder, filename);
                        // write file using stream.
                        using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            const int bufferLen = 4096;
                            byte[] buffer = new byte[bufferLen];
                            int count = 0;
                            int totalBytes = 0;
                            while ((count = Sourcestream.Read(buffer, 0, bufferLen)) > 0)
                            {

                                totalBytes += count;
                                targetStream.Write(buffer, 0, count);

                            }
                            EventMedia em = new EventMedia();
                            em.EventId = res.ResultID;
                            em.MediaType = 1;
                            em.Media = filename;
                            objsm.AddEventMedia(em);
                            targetStream.Close();

                            Sourcestream.Close();

                        }
                    }
                }

                if(p.VideoFilename!=""&&p.VideoBytes!="")
                {
                    byte[] imagedata = Convert.FromBase64String(p.VideoBytes);
                    string generatefilename = p.VideoFilename;
                    
                    if (imagedata != null && imagedata.Length > 0 && res.ResultID > 0)
                    {
                        string strfilepath = System.Web.Hosting.HostingEnvironment.MapPath("~/content/events/" + res.ResultID.ToString() + "/") + generatefilename ;
                        FileStream targetStream = null;
                        MemoryStream ms = new MemoryStream(imagedata);
                        Stream Sourcestream = ms;
                        string uploadfolder = System.Web.Hosting.HostingEnvironment.MapPath("~/content/events/" + res.ResultID.ToString() + "/");
                        if (!Directory.Exists(uploadfolder))
                        {
                            Directory.CreateDirectory(uploadfolder);
                        }
                        string filename = generatefilename ;
                        filename = Settings.GenerateRandomImgFileName(filename.Substring(filename.IndexOf('.')));
                        string filePath = Path.Combine(uploadfolder, filename);
                        // write file using stream.
                        using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            const int bufferLen = 4096;
                            byte[] buffer = new byte[bufferLen];
                            int count = 0;
                            int totalBytes = 0;
                            while ((count = Sourcestream.Read(buffer, 0, bufferLen)) > 0)
                            {

                                totalBytes += count;
                                targetStream.Write(buffer, 0, count);

                            }
                            EventMedia em = new EventMedia();
                            em.EventId = res.ResultID;
                            em.MediaType = 2;
                            em.Media = filename;
                            objsm.AddEventMedia(em);
                            targetStream.Close();

                            Sourcestream.Close();

                        }
                    }
                }

            }
            return res; 
        }

        [Route("api/GetEventDetailById")]
        [HttpGet]
        public GetEventDetailsResponse GetEventDetailById(Int32 eventId)
        {
            GetEventDetailsResponse res = new GetEventDetailsResponse();
            res = objsm.GetEventDetailById(eventId);
            
            return res; 
        }


        [Route("api/GetEventMedia")]
        [HttpGet]
        public GetEventMediaResponse GetEventMedia(Int32 eventId)
        {
            GetEventMediaResponse res = new GetEventMediaResponse();
            List<EventMediaResponse> EventMedia = new List<EventMediaResponse>();
            EventMedia = objsm.GetEventMediaById(eventId);
            List<GetEventImagesResponse> resimage = new List<GetEventImagesResponse>();
            foreach(EventMediaResponse er in EventMedia)
            {
                if (er.MediaType == 1)
                {
                    GetEventImagesResponse r = new GetEventImagesResponse();
                    r.EventId = er.EventId;
                    r.Image = er.Media;
                    r.ImagePath = er.MediaPath;
                    resimage.Add(r);
                }
            }
            res.EventImages = resimage;
            List<GetEventVideoResponse> resvideo = new List<GetEventVideoResponse>();
            foreach (EventMediaResponse er in EventMedia)
            {
                if (er.MediaType == 2)
                {
                    GetEventVideoResponse v = new GetEventVideoResponse();
                    v.EventId = er.EventId;
                    v.Video = er.Media;
                    v.VideoPath = er.MediaPath;
                    resvideo.Add(v);
                }
            }
            res.EventVideos = resvideo;
            return res;
        }

        [Route("api/InsertEventEnquiry")]
        [HttpPost]
        public CustomerEnquiryResponse InsertEventEnquiry(EventEnquiryParams p)
        {
            try
            {
                return objsm.InsertEventEnquiry(p);

            }
            catch
            {
                return new CustomerEnquiryResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }

        [Route("api/InsertCustomerSupport")]
        [HttpPost]
        public CustomerSupportResponse InsertCustomerSupport(CustomerSupportParams p)
        {
            try
            {
                return objsm.InsertCustomerSupport(p);

            }
            catch
            {
                return new CustomerSupportResponse { ResultID = 0, ResultMessage = Settings.BaseErrorMessage };
            }
        }
    }

    
}