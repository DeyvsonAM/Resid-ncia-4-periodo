using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}