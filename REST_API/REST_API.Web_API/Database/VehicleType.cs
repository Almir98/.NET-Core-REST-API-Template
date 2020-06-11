using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public int VehcileTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
