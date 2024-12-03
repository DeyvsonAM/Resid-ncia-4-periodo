using APISenac.Data.DataContracts;
using APISenac.Models;
using Microsoft.EntityFrameworkCore;


namespace APISenac.Data;

public class CustomAtributeRepository : Repository<CustomAtribute>, ICustomAtributeRepository
{
    public CustomAtributeRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
     public async Task<List<CustomAtribute>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Set<CustomAtribute>()
                                 .Where(x => ids.Contains(x.Id))
                                 .ToListAsync();
        }
}