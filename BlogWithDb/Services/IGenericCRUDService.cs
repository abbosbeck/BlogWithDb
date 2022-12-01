namespace BlogWithDb.Services
{
    public interface IGenericCRUDService<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Create(T model);
        Task<T> Get(int id);
        Task<T> Update(int id, T model);
        Task<bool> Delete(int id);
    }
}
