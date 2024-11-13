namespace APISenac.Models;

public class Sistema
{
    public Guid Id { get; init; }
    public string Nome { get; private set; } = string.Empty;
    public DateTime DataHora { get; private set; } = DateTime.Now;
    public DateTime LastUpdate { get; private set; }  
    public bool Active { get; private set; }

    public Sistema(string nome, DateTime lastUpdate)
    {
        Nome = nome;
        Id = Guid.NewGuid();
        Active = true;
        LastUpdate = lastUpdate; 
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}