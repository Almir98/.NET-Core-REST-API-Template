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
    public class BookingService : BaseCRUDService<Data.Booking, BookingSearchRequest, Database.Booking, BookingUpsert, BookingUpsert>
    {
        public BookingService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Data.Booking> Get(BookingSearchRequest search)
        {
            var query = _context.Set<Database.Booking>()
                .Include(e => e.Customer)
                .Include(e => e.Vehicle)
                .Include(e => e.Vehicle.VehicleModel)
                .Include(e => e.Vehicle.VehicleModel.Manufacturer)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName))
            {
                query = query.Where(e => e.Customer.FirstName.StartsWith(search.FirstName));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                query = query.Where(e => e.Customer.LastName.StartsWith(search.LastName));
            }

            if (!string.IsNullOrEmpty(search.ModelName))
            {
                query = query.Where(e => e.Vehicle.VehicleModel.ModelName.StartsWith(search.ModelName));
            }

            if (!string.IsNullOrEmpty(search.ManufacturerName))
            {
                query = query.Where(e => e.Vehicle.VehicleModel.Manufacturer.ManufacturerName.StartsWith(search.ManufacturerName));
            }

            if (search?.VehicleID.HasValue == true)
            {
                query = query.Where(x => x.Vehicle.VehicleId == search.VehicleID);
            }

            if(search.StartDate!=null && search.EndDate != null)
            {
                query = query.Where(e => e.StartDate.Date >= search.StartDate.Value && e.EndDate.Date <= search.EndDate.Value);
            }

            query = query.OrderBy(e => e.VehicleId);

            return _mapper.Map<List<Data.Booking>>(query.ToList());
        }

        public override Data.Booking GetById(int id)
        {
            var booking = _context.Booking
                .Include(e => e.Customer)
                .Include(e => e.Vehicle)
                .Include(e => e.Vehicle.VehicleModel)
                .Include(e => e.Vehicle.VehicleModel.Manufacturer)
                .FirstOrDefault(e => e.BookingId == id);

            return _mapper.Map<Data.Booking>(booking);
        }
    }
}
