using REST_API.Data.Requests;
using REST_API.Web_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Interface
{
    public interface ICustomerService
    {
        List<CustomerRequest> Get(CustomerSearchRequest request);

        CustomerRequest GetById(int id);

        CustomerRequest Insert(CustomerUpsert customer);

        CustomerRequest Update(int id, CustomerUpsert customer);

        Customer Authenticate(CustomerLoginRequest request);
    }
}
