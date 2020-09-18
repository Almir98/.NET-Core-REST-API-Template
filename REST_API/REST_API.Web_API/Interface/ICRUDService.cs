using REST_API.Interface;

namespace REST_API.Web_API.Interface
{
    public interface ICRUDService<TModel, Tsearch, TInsert, TUpdate> : IService<TModel, Tsearch>
    {
        TModel Insert(TInsert request);

        TModel Update(int id, TUpdate request);
    }
}
