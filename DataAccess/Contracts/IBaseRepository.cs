 
using System.Collections.Generic; 
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Delete(int id); 
    }
}
