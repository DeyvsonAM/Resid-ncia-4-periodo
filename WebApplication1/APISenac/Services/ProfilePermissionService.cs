


using APISenac.Data.DataContracts;
using APISenac.Models;
using APISenac.Services;
using APISenac.Services.Interfaces;
using AutoMapper;

public class ProfilePermissionService : BaseService<ProfilePermission>, IProfilePermissionService 
{
   

    public ProfilePermissionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

    public async Task AdicionarPermissoesAoPerfilAsync(Guid perfilId, List<Guid> permissoesIds)
{
    try
    {
        // Verificar se o perfil existe
        var perfil = await _unitOfWork.ProfileRepository.GetByIdAsync(perfilId);
        if (perfil == null)
        {
            throw new Exception("Perfil não encontrado.");
        }

        // Verificar se as permissões são válidas
        if (permissoesIds == null || permissoesIds.Count == 0)
        {
            throw new Exception("Nenhuma permissão fornecida.");
        }

        // Adicionar as permissões ao perfil
        await _unitOfWork.ProfilePermissionRepository.AdicionarPermissoesAoPerfilAsync(perfilId, permissoesIds);
        await _unitOfWork.CommitAsync();
    }
    catch (Exception ex)
    {
        await _unitOfWork.RollbackAsync();
        throw new Exception($"Erro ao adicionar permissões ao perfil: {ex.Message}");
    }
}


    public async Task RemoverPermissoesDoPerfilAsync(Guid perfilId, List<Guid> permissoesIds)
    {
        try
        {
            // Validar se o perfil existe, etc.
            // Caso queira adicionar mais lógicas de validação, adicione aqui

            await _unitOfWork.ProfilePermissionRepository.RemoverPermissoesDoPerfilAsync(perfilId, permissoesIds);
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            throw new Exception($"Erro ao remover permissões do perfil: {ex.Message}");
        }
    }

    public async Task<List<string>> ObterPermissoesDoPerfilAsync(Guid perfilId)
        {
            if (perfilId == Guid.Empty)
            {
                throw new ArgumentException("O ID do perfil não pode ser vazio.", nameof(perfilId));
            }

            try
            {
                return await _unitOfWork.ProfilePermissionRepository.ObterPermissoesPorPerfilAsync(perfilId);
            }
            catch (Exception ex)
            {
                // Log do erro pode ser feito aqui, se necessário
                throw new InvalidOperationException("Erro ao buscar permissões para o perfil.", ex);
            }
        }
}
