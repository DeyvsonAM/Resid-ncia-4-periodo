using APISenac.Data;
using APISenac.Models;

namespace APISenac.Services
{
    public class Custom_AtributeService : BaseService<CustomAtribute>
    {
        public Custom_AtributeService(AppDbContext context) : base(context) { }
    }
}
