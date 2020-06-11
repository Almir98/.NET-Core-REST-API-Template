using System;
using System.Collections.Generic;
using System.Text;

namespace REST_API.Data.Requests
{
    public class CustomerLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
