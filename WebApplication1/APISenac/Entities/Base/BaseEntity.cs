namespace APISenac.Entities.Base
{
    public class BaseEntity
    {
    public Guid Id { get; init; }
    public string UsuarioInserido { get; private set; }
    public DateTime DataDeCriacao { get; private set; } = DateTime.Now;
    public DateTime LastUpdate { get; private set; }  
    public bool Active { get; private set; }

    }
}