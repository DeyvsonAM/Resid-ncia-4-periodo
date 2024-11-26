using APISenac.Models;
using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class CustomAtributeService : BaseService<CustomAtribute>, ICustomAtributeService
    {
        public CustomAtributeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Custom_Atribute, se necessário
    }
}