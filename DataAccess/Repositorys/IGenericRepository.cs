using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Create(T element);
        Task<T> Get(int id);
        Task<T> Update(int id, T element);
        Task<bool> Delete(int id);
    }
}
