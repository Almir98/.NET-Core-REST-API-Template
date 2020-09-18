using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public string Description { get; set; }
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
