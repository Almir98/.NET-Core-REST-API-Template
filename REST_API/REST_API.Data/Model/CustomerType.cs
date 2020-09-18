using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class CustomerType
    {
        public int CustomerTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}
