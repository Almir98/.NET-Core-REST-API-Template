using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class VehicleType
    {
        public int VehcileTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
