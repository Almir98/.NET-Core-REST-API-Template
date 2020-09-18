using System;
using System.Collections.Generic;

namespace REST_API.Data
{
    public partial class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public virtual ICollection<VehicleModel> VehicleModel { get; set; }
    }
}
