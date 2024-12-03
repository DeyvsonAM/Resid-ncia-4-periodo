using Microsoft.EntityFrameworkCore;

using APISenac.Data.DataContracts;
using APISenac.Models;


namespace APISenac.Data;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(AppDbContext dbContext) : base(dbContext)
    {
       
    }
     public async Task<List<Permission>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Set<Permission>()
                                 .Where(x => ids.Contains(x.Id))
                                 .ToListAsync();
        }
}