﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Data.Requests;
using REST_API.Web_API.Interface;

namespace REST_API.Web_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Data.Customer>> Get([FromQuery]CustomerSearchRequest request)
        {
            return _service.Get(request);
        }

        [HttpGet("{id}")]
        public ActionResult<Data.Customer> GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public ActionResult<Data.Customer> Insert(CustomerUpsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public ActionResult<Data.Customer> Update(int id,CustomerUpsert request)
        {
            return _service.Update(id, request);
        }
    }
}