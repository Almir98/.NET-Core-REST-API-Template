using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Data;
using REST_API.Data.Requests;
using REST_API.Web_API.Interface;

namespace REST_API.Web_API.Controllers
{
    public class BookingController : BaseCRUDController<Data.Booking, BookingSearchRequest, BookingUpsert, BookingUpsert>
    {
        public BookingController(ICRUDService<Booking, BookingSearchRequest, BookingUpsert, BookingUpsert> service) : base(service)
        {
        }
    }
}