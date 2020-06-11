using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int RatingValue { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
