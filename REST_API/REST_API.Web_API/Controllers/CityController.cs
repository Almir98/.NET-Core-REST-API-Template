using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Data.Requests;
using REST_API.Interface;

namespace REST_API.Web_API.Controllers
{
    public class CityController : BaseController<CityRequest, object>
    {
        public CityController(IService<CityRequest, object> service) : base(service)
        {
        }
    }
}