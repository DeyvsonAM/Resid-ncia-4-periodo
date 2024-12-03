using System.Linq.Expressions;

namespace APISenac.Data.DataContracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task AdicionarPermissoesAoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);
        Task RemoverPermissoesDoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);

        Task<List<string>> ObterPermissoesPorPerfilAsync(Guid perfilId);
        
    }
}
