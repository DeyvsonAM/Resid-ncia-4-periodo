using WebApplication1.Data;
using APISenac.Models;

namespace APISenac.Services
{
    public class ProfileService : BaseService<Profile>
    {
        public ProfileService(AppDbContext context) : base(context) { }
    }
}
