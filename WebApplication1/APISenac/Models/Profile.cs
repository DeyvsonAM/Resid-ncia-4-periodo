using APISenac.Models;


namespace APISenac.Models
{

    public class Profile : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 


    }
}