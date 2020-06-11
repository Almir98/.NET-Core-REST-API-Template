using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API.Interface
{
    public interface IService<TModel,Tsearch>
    {
        TModel Get(Tsearch search);
        TModel GetById(int id);
    }
}
