using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class BookingSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? VehicleID { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string ManufacturerName { get; set; }
        public string ModelName { get; set; }
    }
}
