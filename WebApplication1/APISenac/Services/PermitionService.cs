using APISenac.Data;
using APISenac.Models;

namespace APISenac.Services
{
    public class PermitionService : BaseService<Permition>
    {
        public PermitionService(AppDbContext context) : base(context) { }
    }
}
