using APISenac.Models;
using APISenac.Data.DataContracts;

namespace APISenac.Services
{
    public class ProfileService : BaseService<Profile>
    {
        public ProfileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Profile, se necessário
    }
}