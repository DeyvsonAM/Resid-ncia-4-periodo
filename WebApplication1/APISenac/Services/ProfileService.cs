using APISenac.Models;
using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class ProfileService : BaseService<Profile>, IProfileService
    {
        public ProfileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para Profile, se necessário
    }
}