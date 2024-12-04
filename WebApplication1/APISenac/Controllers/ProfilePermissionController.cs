using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;
using APISenac.Models.DTOs;





[Route("api/[controller]")]
[ApiController]
public class ProfilePermissionController : ControllerBase
{
    private readonly IProfilePermissionService _ProfilePermissionService;

    public ProfilePermissionController(IProfilePermissionService ProfilePermissionService)
    {
        _ProfilePermissionService = ProfilePermissionService;
    }

    [HttpPost]
    [Route("api/perfis/adicionar-permissoes")]
    public async Task<IActionResult> AdicionarPermissoesAoPerfil([FromBody] AdicionarPermissoesRequest request)
    {
        try
        {
            // Chama o serviço para adicionar permissões
            await _ProfilePermissionService.AdicionarPermissoesAoPerfilAsync(request.PerfilId, request.Permissoes);
            return Ok("Permissões adicionadas com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao adicionar permissões ao perfil: {ex.Message}");
        }
    }


    [HttpDelete("{perfilId}/permissoes")]
    public async Task<IActionResult> RemoverPermissoesDoPerfil(Guid perfilId, [FromBody] List<Guid> permissoesIds)
    {
        try
        {
            await _ProfilePermissionService.RemoverPermissoesDoPerfilAsync(perfilId, permissoesIds);
            return Ok("Permissões removidas do perfil com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro: {ex.Message}");
        }


    }

    [HttpGet("permissoes/{perfilId}")]
    public async Task<ActionResult<List<string>>> GetPermissoesPorPerfil(Guid perfilId)
    {
        try
        {
            var permissoes = await _ProfilePermissionService.ObterPermissoesDoPerfilAsync(perfilId);

            if (permissoes == null || permissoes.Count == 0)
            {
                return NotFound("Nenhuma permissão encontrada para este perfil.");
            }

            return Ok(permissoes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar permissões: {ex.Message}");
        }
    }
}





