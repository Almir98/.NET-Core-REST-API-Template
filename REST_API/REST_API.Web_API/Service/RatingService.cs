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
    public class RatingService : BaseCRUDService<Data.Rating, RatingSearchRequest, Database.Rating, RatingUpsert, RatingUpsert>
    {
        public RatingService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Data.Rating> Get(RatingSearchRequest search)
        {
            var query = _context.Set<Database.Rating>()
               .Include(x => x.Customer)
               .Include(e => e.Vehicle)
               .Include(e => e.Vehicle.VehicleModel)
               .Include(e => e.Vehicle.VehicleModel.Manufacturer)
               .AsQueryable();

            if (search?.RatingValue.HasValue == true)
            {
                query = query.Where(x => x.RatingValue == search.RatingValue);
            }

            if (!string.IsNullOrWhiteSpace(search.ManufacturerName))
            {
                query = query.Where(x => x.Vehicle.VehicleModel.Manufacturer.ManufacturerName.StartsWith(search.ManufacturerName));
            }

            if (!string.IsNullOrWhiteSpace(search.ModelName))
            {
                query = query.Where(x => x.Vehicle.VehicleModel.ModelName.StartsWith(search.ModelName));
            }

            if (!string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.Customer.FirstName.StartsWith(search.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.Customer.LastName.StartsWith(search.LastName));
            }

            if (search?.CustomerID.HasValue == true)
            {
                query = query.Where(x => x.Customer.CustomerId == search.CustomerID);
            }

            if (search.VehicleId.HasValue == true)
            {
                query = query.Where(x => x.Vehicle.VehicleId == search.VehicleId);
            }

            query = query.OrderBy(x => x.RatingValue);

            return _mapper.Map<List<Data.Rating>>(query.ToList());
        }
    }
}
