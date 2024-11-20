using APISenac.Data;
using APISenac.Models;

namespace APISenac.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(AppDbContext context) : base(context) { }
    }
}
