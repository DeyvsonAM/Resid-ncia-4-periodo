
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

        public async Task AdicionarPermissoesAoPerfilAsync(Guid perfilId, List<Guid> permissoesIds)
        {
            foreach (var PermissionId in permissoesIds)
            {
                var perfilPermission = new ProfilePermission
                {
                    ProfileId = perfilId,
                    PermissionId = PermissionId
                };
                await _context.ProfilePermissions.AddAsync(perfilPermission);
            }
        }

        public async Task RemoverPermissoesDoPerfilAsync(Guid perfilId, List<Guid> permissoesIds)
        {
            var ProfilePermissions = await _context.ProfilePermissions
                .Where(pp => pp.ProfileId == perfilId && permissoesIds.Contains(pp.PermissionId))
                .ToListAsync();

            _context.ProfilePermissions.RemoveRange(ProfilePermissions);
        }

        public async Task<List<string>> ObterPermissoesPorPerfilAsync(Guid perfilId)
        {
            // Obtém o perfil e suas permissões associadas
            var permissoes = await _context.ProfilePermissions
                                            .Where(pp => pp.ProfileId == perfilId)
                                            .Include(pp => pp.Permission) // Inclui as permissões associadas ao perfil
                                            .Select(pp => pp.Permission.Nome) // Assume que Permission tem uma propriedade Name
                                            .ToListAsync();

            return permissoes;
        }

    }
}
