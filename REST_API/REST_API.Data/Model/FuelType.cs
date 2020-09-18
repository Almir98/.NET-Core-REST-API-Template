using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class FuelType
    {
        public int FuelTypeId { get; set; }
        public string FuelName { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
