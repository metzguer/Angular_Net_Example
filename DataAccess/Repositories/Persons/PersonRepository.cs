using DataAccess.Contracts.Persons;
using System; 
using System.Threading.Tasks;

namespace DataAccess.Repositories.Persons
{
    public class PersonRepository<T> : BaseRepository<T>, IPersonRepository<T> where T : class
    {
        public PersonRepository(DbDataContext context) : base(context)
        {

        }
         
    }
}
