using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace REST_API.Data.Requests
{
    public class RatingUpsert
    {
        [Required]
        public int RatingValue { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        public DateTime? RatingDate { get; set; }
    }
}
