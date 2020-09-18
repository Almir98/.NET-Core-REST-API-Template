using AutoMapper;
using REST_API.Web_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class CityService : BaseService<Data.City, object, Database.City>
    {
        public CityService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
