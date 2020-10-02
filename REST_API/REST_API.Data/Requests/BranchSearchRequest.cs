using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class BranchSearchRequest
    {
        public int? CityId { get; set; }
        public string BranchName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
