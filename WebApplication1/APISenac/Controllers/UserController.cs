using APISenac.Services;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;


namespace APISenac.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController<User>
    {
        public UserController(UserService service) : base(service) { }
    }
}
