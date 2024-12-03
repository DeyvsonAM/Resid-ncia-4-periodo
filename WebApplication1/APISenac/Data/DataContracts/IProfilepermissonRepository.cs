using APISenac.Models;


namespace APISenac.Data.DataContracts
{
public interface IProfilePermissionRepository : IRepository<ProfilePermission>
{
    Task AdicionarPermissoesAoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);
    Task RemoverPermissoesDoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);

     Task<List<string>> ObterPermissoesPorPerfilAsync(Guid perfilId);
}
}