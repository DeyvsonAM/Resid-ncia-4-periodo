using APISenac.Entities.Base;
using WebApplication1.Entities.sistemas;

namespace APISenac.Entities.Profile
{
    public class Profile : BaseEntity
    {
        public String Nome { get; set; }

        public virtual Sistema Sistema {get; set;}


    }
}