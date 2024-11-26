using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data;

public class CustomAtributeRepository : Repository<CustomAtribute>, ICustomAtributeRepository
{
    public CustomAtributeRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}