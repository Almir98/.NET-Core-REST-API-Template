using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class CustomerRequest
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int CityId { get; set; }
    }
}
