using APISenac.Data.DataContracts;
using APISenac.Models;
using Microsoft.EntityFrameworkCore;

namespace APISenac.Data;

public class ProfilePermissionRepository : Repository<ProfilePermission>, IProfilePermissionRepository
{
    public ProfilePermissionRepository(AppDbContext dbContext) : base(dbContext)
    {

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
        // Lógica para buscar permissões no banco de dados
        return await _context.ProfilePermissions
            .Where(pp => pp.ProfileId == perfilId)
            .Select(pp => pp.Permission.Nome)
            .ToListAsync();
    }


}