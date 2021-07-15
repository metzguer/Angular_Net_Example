using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbDataContext _context;

        public BaseRepository( DbDataContext context ) => _context = context;

        public async Task Add(T entity) => await _context.AddAsync<T>(entity);

        public async Task Delete(int id) => _context.Remove<T>( await Get(id) ); 

        public async Task<T> Get(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
        public async Task Update(T entity) => await Task.Run(() => _context.Update<T>(entity) );  
    }
}
