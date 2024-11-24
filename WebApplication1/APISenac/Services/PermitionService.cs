using APISenac.Models;
using APISenac.Data.DataContracts;

namespace APISenac.Services
{
    public class PermitionService : BaseService<Permission>
    {
        public PermitionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Permition, se necessário
    }
}
