using System;
using System.Collections.Generic;

namespace REST_API.Web_API.Database
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfComment { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
