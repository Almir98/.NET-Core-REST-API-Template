using AutoMapper;
using Microsoft.EntityFrameworkCore;
using REST_API.Data.Requests;
using REST_API.Web_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class CommentService : BaseCRUDService<Data.Comment, CommentSearchRequest, Database.Comment, CommentUpsert, CommentUpsert>
    {
        public CommentService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Data.Comment> Get(CommentSearchRequest search)
        {
            var query = _context.Comment.Include(e => e.Customer)
                .Include(e => e.Vehicle)
                .Include(e => e.Vehicle.VehicleModel)
                .Include(e => e.Vehicle.VehicleModel.Manufacturer)
                .AsQueryable();

            if (search.DateOfComment != null)
            {
                var dateComment = search.DateOfComment.Value.Date;
                query = query.Where(e => e.DateOfComment.AddHours(8).Date == dateComment);
            }

            if (!string.IsNullOrEmpty(search.ManufacturerName))
            {
                query = query.Where(x => x.Vehicle.VehicleModel.Manufacturer.ManufacturerName.StartsWith(search.ManufacturerName));
            }

            if (!string.IsNullOrEmpty(search.ModelName))
            {
                query = query.Where(x => x.Vehicle.VehicleModel.ModelName.StartsWith(search.ModelName));
            }

            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(x => x.Customer.FirstName.StartsWith(search.FirstName));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(x => x.Customer.LastName.StartsWith(search.LastName));
            }

            if (search?.CustomerID.HasValue == true)
            {
                query = query.Where(x => x.Customer.CustomerId == search.CustomerID);
            }

            if (search?.VehicleId.HasValue == true)
            {
                query = query.Where(x => x.Vehicle.VehicleId == search.VehicleId);
            }
            query = query.OrderBy(x => x.DateOfComment);

            return _mapper.Map<List<Data.Comment>>(query.ToList());
        }
    }
}
