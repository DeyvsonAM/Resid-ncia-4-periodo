using WebApplication1.Data;
using APISenac.Models;

namespace APISenac.Services
{
    public class Custom_AtributeService : BaseService<Custom_Atribute>
    {
        public Custom_AtributeService(AppDbContext context) : base(context) { }
    }
}
