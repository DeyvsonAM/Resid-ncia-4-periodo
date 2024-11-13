

namespace APISenac.Models
{

    public class User : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;
         public string Email { get; set; } = string.Empty;
         private string Senha { get; set; } = string.Empty;
         private string Cpf {get; set;} =string.Empty;
        
    }
}