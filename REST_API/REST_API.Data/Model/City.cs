using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Branch> Branch { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
    }
}
