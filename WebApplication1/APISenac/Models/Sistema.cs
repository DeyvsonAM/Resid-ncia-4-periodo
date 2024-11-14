namespace APISenac.Models;

public class Sistema : BaseEntity
{
   
    public string Nome { get; private set; } = string.Empty;
   

    public Sistema(string nome, DateTime lastUpdate)
    {
        Nome = nome;
        
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}