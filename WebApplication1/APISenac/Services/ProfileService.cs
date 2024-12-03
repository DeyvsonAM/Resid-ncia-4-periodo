using APISenac.Models;
using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class ProfileService : BaseService<BDProfile>, IBDProfileService
    {
        public ProfileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para BDProfile, se necessário
    }
}
