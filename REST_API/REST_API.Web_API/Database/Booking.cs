﻿using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? CustomerId { get; set; }
        public int? VehicleId { get; set; }
        public bool? RatingStatus { get; set; }
        public bool? CommentStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
