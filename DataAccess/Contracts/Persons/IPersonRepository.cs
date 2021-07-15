
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Contracts.Persons
{
    public interface IPersonRepository<T> : IBaseRepository<T> where T : class
    { 

    }
}
