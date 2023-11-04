using Dapper;
using DbFactory.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripleTwo.Entities;
//using static TripleTwo.Entities.EventEntities;
using static TripleTwo.Entities.Settings;

namespace TripleTwo.DAL
{
    public class EventData
    {
        public List<GetEventsListResponse> GetEventsList(GetEventsListParams p)
        {
            DapperRepositry<GetEventsListResponse> _repo = new DapperRepositry<GetEventsListResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", p.EventId, DbType.Int32, ParameterDirection.Input);
            param.Add("@PageIndex", p.pgindex, DbType.Int32, ParameterDirection.Input);
            param.Add("@PageSize", p.pgsize, DbType.Int32, ParameterDirection.Input);
            param.Add("@Searchstr", p.str, DbType.String, ParameterDirection.Input);
            return _repo.GetList("GetEvents", param);

        }

        public List<EventMediaResponse> GetEventMediaById(int eventId)
        {
            DapperRepositry<EventMediaResponse> _repo = new DapperRepositry<EventMediaResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", eventId, DbType.Int32, ParameterDirection.Input);
           return _repo.GetList("GetEventMediaById", param);
        }

        public AddUpdateEventResponse AddEvent(AddUpdateEventParams p)
        {
            DapperRepositry<AddUpdateEventResponse> _repo = new DapperRepositry<AddUpdateEventResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", p.EventId, DbType.Int32, ParameterDirection.Input);
            param.Add("@OrganisationTypeId", p.OrganisationTypeId, DbType.Int32, ParameterDirection.Input);
            param.Add("@PartnerId", p.PartnerId, DbType.Int32, ParameterDirection.Input);
            param.Add("@Title", p.Title, DbType.String, ParameterDirection.Input);
            param.Add("@StartDate", p.StartDate, DbType.DateTime, ParameterDirection.Input);
            param.Add("@EndDate", p.EndDate, DbType.DateTime, ParameterDirection.Input);
            param.Add("@Description", p.Description, DbType.String, ParameterDirection.Input);
            param.Add("@Location", p.Location, DbType.String, ParameterDirection.Input);
            //param.Add("@Image", p.Image, DbType.String, ParameterDirection.Input);
            //param.Add("@Video", p.Video, DbType.String, ParameterDirection.Input);
            param.Add("@Latitude", p.Latitude, DbType.String, ParameterDirection.Input);
            param.Add("@Longitude", p.Longitude, DbType.String, ParameterDirection.Input);
            param.Add("@StartDate", p.StartDate, DbType.DateTime, ParameterDirection.Input);
            param.Add("@EndDate", p.EndDate, DbType.DateTime, ParameterDirection.Input);
            param.Add("@ContactPerson", p.ContactPerson, DbType.String, ParameterDirection.Input);
            param.Add("@ContactPhone", p.ContactPhone, DbType.String, ParameterDirection.Input);
            param.Add("@ContactEmail", p.ContactEmail, DbType.String, ParameterDirection.Input);
            param.Add("@EventTypeId", p.EventTypeId, DbType.Int32, ParameterDirection.Input);
            param.Add("@Status", p.Status, DbType.Int32, ParameterDirection.Input);
            param.Add("@CountryId", p.CountryId, DbType.Int32, ParameterDirection.Input);
            param.Add("@StateId", p.StateId, DbType.Int32, ParameterDirection.Input);
            param.Add("@City", p.City, DbType.String, ParameterDirection.Input);
            param.Add("@PostCode", p.PostCode, DbType.String, ParameterDirection.Input);


            return _repo.GetResult("AddEvent", param);
        }

        public void AddEventMedia(EventMedia em)
        {
            DapperRepositry<GetEventDetailsResponse> _repo = new DapperRepositry<GetEventDetailsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", em.EventId, DbType.Int32, ParameterDirection.Input);
            param.Add("@MediaType", em.MediaType, DbType.Int32, ParameterDirection.Input);
            param.Add("@Media", em.Media, DbType.String, ParameterDirection.Input);
            _repo.GetResult("AddEventMedia", param);
        }

        public GetEventDetailsResponse GetEventDetailById(Int32 eventId)
        {
            DapperRepositry<GetEventDetailsResponse> _repo = new DapperRepositry<GetEventDetailsResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", eventId, DbType.Int32, ParameterDirection.Input);
            return _repo.GetResult("GetEventDetails", param);
        }


        public CustomerEnquiryResponse InsertEventEnquiry(EventEnquiryParams p)
        {
            DapperRepositry<CustomerEnquiryResponse> _repo = new DapperRepositry<CustomerEnquiryResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@EventId", p.CustomerId, DbType.Int64, ParameterDirection.Input);
            param.Add("@CustomerId", p.CustomerId, DbType.Int64, ParameterDirection.Input);
            param.Add("@Message", p.Message, DbType.String, ParameterDirection.Input);
            return _repo.GetResult("InsertEventEnquiry", param);
        }

        public CustomerSupportResponse InsertCustomerSupport(CustomerSupportParams p)
        {
            DapperRepositry<CustomerSupportResponse> _repo = new DapperRepositry<CustomerSupportResponse>(Settings.ProviederName, Settings.DbConnection);
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", p.CustomerId, DbType.Int64, ParameterDirection.Input);
            param.Add("@Subject", p.Message, DbType.String, ParameterDirection.Input);
            param.Add("@Message", p.Message, DbType.String, ParameterDirection.Input);

            return _repo.GetResult("InsertCustomerSupport", param);
        }
    }
}
