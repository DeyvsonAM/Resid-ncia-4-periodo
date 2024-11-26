using APISenac.Models;
using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;

namespace APISenac.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para User, se necessário
    }
}