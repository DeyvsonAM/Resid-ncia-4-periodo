using APISenac.Models.Base;
using WebApplication1.Models.sistemas;

namespace APISenac.Models.Profile
{
    public class Profile : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 


    }
}