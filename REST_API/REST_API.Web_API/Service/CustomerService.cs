using AutoMapper;
using Helper;
using Microsoft.EntityFrameworkCore;
using REST_API.Data.Requests;
using REST_API.Interface;
using REST_API.Web_API.Database;
using REST_API.Web_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class CustomerService : ICustomerService
    {
        protected readonly RentaCarContext _context;
        protected readonly IMapper _mapper;
        
        public CustomerService(RentaCarContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Customer Authenticate(CustomerLoginRequest request)
        {
            var customer = _context.Customer.FirstOrDefault(x => x.Username == request.Username);

            if (customer != null)
            {
                var newHash = HashGenerator.GenerateHash(customer.PasswordSalt, request.Password);

                if (customer.PasswordHash == newHash)
                {
                    return _mapper.Map<Customer>(customer);
                }
            }
            return null;
        }

        public List<Data.Customer> Get(CustomerSearchRequest request)
        {
            var query = _context.Customer.Include(x => x.City).AsQueryable();

            if(!string.IsNullOrWhiteSpace(request.FirstName) || !string.IsNullOrWhiteSpace(request.LastName))
            {
                query = query.Where(x => x.FirstName.StartsWith(request.FirstName) || x.LastName.StartsWith(request.LastName));
            }

            if(!string.IsNullOrWhiteSpace(request.CityName))
            {
                query = query.Where(x => x.City.CityName.StartsWith(request.CityName));
            }
            query = query.OrderBy(x => x.FirstName);

            return _mapper.Map<List<Data.Customer>>(query.ToList());
        }

        public Data.Customer GetById(int id)
        {
            return _mapper.Map<Data.Customer>(_context.Customer.Find(id));
        }

        public Data.Customer Insert(CustomerUpsert customer)
        {
            var entity = _mapper.Map<Customer>(customer);

            if(customer.Password != customer.PasswordConfirm)
            {
                throw new Exception("Password and password confirm don't match !");
            }

            entity.PasswordSalt = HashGenerator.GenerateSalt();
            entity.PasswordHash = HashGenerator.GenerateHash(entity.PasswordSalt, customer.Password);

            _context.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Customer>(entity);
        }

        public Data.Customer Update(int id, CustomerUpsert customer)
        {
            var entity = _context.Customer.Find(id);

            _context.Customer.Attach(entity);
            _context.Customer.Update(entity);

            _mapper.Map(customer, entity);
            _context.SaveChanges();

            return _mapper.Map<Data.Customer>(entity);
        }
    }
}
