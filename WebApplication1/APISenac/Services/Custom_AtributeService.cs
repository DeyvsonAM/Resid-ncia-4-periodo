using APISenac.Models;
using APISenac.Data.DataContracts;

namespace APISenac.Services
{
    public class CustomAtributeService : BaseService<CustomAtribute>
    {
        public CustomAtributeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Custom_Atribute, se necessário
    }
}