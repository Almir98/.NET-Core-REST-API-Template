using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
        }

        public int CustomerTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
