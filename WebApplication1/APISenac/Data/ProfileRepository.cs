using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data;

public class ProfileRepository : Repository<Profile>, IProfileRepository
{
    public ProfileRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}