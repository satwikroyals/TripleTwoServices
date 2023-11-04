using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.DAL;
using TripleTwo.Entities;


namespace TripleTwo.BAL
{
    public class EventManager
    {

       
            EventData dal = new EventData();
            public List<GetEventsListResponse> GetEventsList(GetEventsListParams p)
            {
                return dal.GetEventsList(p);
            }

            public AddUpdateEventResponse AddEvent(AddUpdateEventParams p)
            {
                return dal.AddEvent(p);
            }

            public GetEventDetailsResponse GetEventDetailById(Int32 eventId)
            {
                return dal.GetEventDetailById(eventId);
            }

        public void AddEventMedia(EventMedia em)
        {
            dal.AddEventMedia(em);
        }

        public List<EventMediaResponse> GetEventMediaById(int eventId)
        {
            return dal.GetEventMediaById(eventId);
        }


        public CustomerEnquiryResponse InsertEventEnquiry(EventEnquiryParams p)
        {
            return dal.InsertEventEnquiry(p);
        }

        public CustomerSupportResponse InsertCustomerSupport(CustomerSupportParams p)
        {
            return dal.InsertCustomerSupport(p);
        }

    }

}
