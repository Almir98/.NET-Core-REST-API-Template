using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class VehicleModel
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
