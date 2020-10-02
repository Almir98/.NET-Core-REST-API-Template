using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace REST_API.Data.Requests
{
    public class CommentUpsert
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required]
        public DateTime DateOfComment { get; set; }
        public bool? CommentStatus { get; set; }
    }
}
