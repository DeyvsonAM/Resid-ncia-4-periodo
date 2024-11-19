using WebApplication1.Data;
using APISenac.Models;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class SistemaService : BaseService<Sistema>, ISistemaService
    {
        public SistemaService(AppDbContext context) : base(context) { }
    }
}
