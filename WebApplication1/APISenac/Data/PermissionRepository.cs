using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data;

public class PermissionRepository : Repository<Permission>, IPermissionRepository
{
    public PermissionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}