using AutoMapper;
using REST_API.Interface;
using REST_API.Web_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class BaseService<TModel, Tsearch, TDatabase> : IService<TModel, Tsearch> where TDatabase: class
    {
        protected readonly RentaCarContext _context;
        protected readonly IMapper _mapper;

        public BaseService(RentaCarContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<TModel> Get(Tsearch search)
        {
            return _mapper.Map<List<TModel>>(_context.Set<TDatabase>().ToList());
        }

        public TModel GetById(int id)
        {
            return _mapper.Map<TModel>(_context.Set<TDatabase>().Find(id));
        }
        public void Delete(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            if (entity == null)
            {
                throw new ArgumentException();
            }
            else
            {
                _context.Set<TDatabase>().Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
