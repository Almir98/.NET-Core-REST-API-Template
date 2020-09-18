using AutoMapper;
using REST_API.Web_API.Database;
using REST_API.Web_API.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class BaseCRUDService<TModel, Tsearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, Tsearch, TDatabase>, ICRUDService<TModel, Tsearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);
            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }
    }
}
