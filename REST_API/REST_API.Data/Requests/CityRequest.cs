using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class CityRequest
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }
    }
}
