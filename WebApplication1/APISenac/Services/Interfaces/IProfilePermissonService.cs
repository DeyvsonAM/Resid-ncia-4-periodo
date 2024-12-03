
using APISenac.Models;

namespace APISenac.Services.Interfaces

{
    public interface IProfilePermissionService : IBaseService<ProfilePermission>
    {
        Task AdicionarPermissoesAoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);
        Task RemoverPermissoesDoPerfilAsync(Guid perfilId, List<Guid> permissoesIds);
        Task<List<string>> ObterPermissoesDoPerfilAsync(Guid perfilId);
    }
}