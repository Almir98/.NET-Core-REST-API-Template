using AutoMapper;
using REST_API.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<CityRequest, Database.City>().ReverseMap();
            CreateMap<CustomerRequest, Database.Customer>().ReverseMap();
            CreateMap<CustomerRequest, CustomerUpsert>().ReverseMap();


        }



    }
}
