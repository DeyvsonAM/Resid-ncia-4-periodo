namespace APISenac.Models.Base
{
    public class BaseEntity
    {
    public Guid Id { get; set; }
    public string UsuarioInserido { get;  set; } = string.Empty;
    public DateTime DataDeCriacao { get;  set; } = DateTime.Now;
    public DateTime LastUpdate { get; set; }  
    public bool Active { get; set; }

    }
}