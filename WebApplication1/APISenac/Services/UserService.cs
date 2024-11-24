using APISenac.Models;
using APISenac.Data.DataContracts;

namespace APISenac.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        // Métodos adicionais específicos para User, se necessário
    }
}