
namespace APISenac.Models.DTOs{
public class AdicionarPermissoesRequest
{
    public Guid PerfilId { get; set; }
    public List<Guid> Permissoes { get; set; }
}
}