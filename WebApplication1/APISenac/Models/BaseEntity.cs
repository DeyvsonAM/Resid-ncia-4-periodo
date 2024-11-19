namespace APISenac.Models
{
    public class BaseEntity
    {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UsuarioInserido { get;  set; } = string.Empty;
    public DateTime DataDeCriacao { get;  set; } = DateTime.Now;
    public DateTime LastUpdate { get; set; }  = DateTime.Now; 
    public bool Active { get; set; }

    }
}