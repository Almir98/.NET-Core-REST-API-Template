using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class CustomerSearchRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
    }
}
