using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data;

public class SistemaRepository : Repository<Sistema>, ISistemaRepository
{
    public SistemaRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}