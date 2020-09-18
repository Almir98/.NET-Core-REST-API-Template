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
        List<Data.Customer> Get(CustomerSearchRequest request);

        Data.Customer GetById(int id);

        Data.Customer Insert(CustomerUpsert customer);

        Data.Customer Update(int id, CustomerUpsert customer);

        Customer Authenticate(CustomerLoginRequest request);
    }
}
