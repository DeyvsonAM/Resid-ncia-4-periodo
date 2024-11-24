
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            if (entity is BaseEntity guidEntity && guidEntity.Id == Guid.Empty)
    {
        guidEntity.Id = Guid.NewGuid();
    }

        _context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
