using APISenac.Models;
using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class SistemaService : BaseService<Sistema>, ISistemaService
    {
        public SistemaService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Sistema, se necessário
    }
}
