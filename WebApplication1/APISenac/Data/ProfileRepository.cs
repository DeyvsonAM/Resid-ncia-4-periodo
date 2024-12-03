using APISenac.Data.DataContracts;
using APISenac.Models;
using Microsoft.EntityFrameworkCore;

namespace APISenac.Data;

public class ProfileRepository : Repository<BDProfile>, IProfileRepository
{
    public ProfileRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
    
   
}