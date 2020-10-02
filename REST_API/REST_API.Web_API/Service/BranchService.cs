using AutoMapper;
using REST_API.Data.Requests;
using REST_API.Web_API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Web_API.Service
{
    public class BranchService : BaseCRUDService<Data.Branch, BranchSearchRequest, Database.Branch, BranchUpsert, BranchUpsert>
    {
        public BranchService(RentaCarContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Data.Branch> Get(BranchSearchRequest search)
        {
            var query = _context.Set<Branch>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.BranchName))
            {
                query = query.Where(x => x.BranchName.StartsWith(search.BranchName));
            }

            if (!string.IsNullOrWhiteSpace(search.PhoneNumber))
            {
                query = query.Where(x => x.PhoneNumber.StartsWith(search.PhoneNumber));
            }

            if (search?.CityId.HasValue == true)
            {
                query = query.Where(e => e.CityId == search.CityId);
            }
            query = query.OrderBy(e => e.BranchName);

            return _mapper.Map<List<Data.Branch>>(query.ToList());
        }
    }
}
