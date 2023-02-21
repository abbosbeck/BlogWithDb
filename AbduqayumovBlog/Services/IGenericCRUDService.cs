namespace BlogWithDb.Services
{
    public interface IGenericCRUDService<T, T2> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Create(T2 model);
        Task<T> Get(int id);
        Task<T> Update(int id, T model);
        Task<bool> Delete(int id);
    }
}
