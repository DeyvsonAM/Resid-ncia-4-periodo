
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;



namespace APISenac.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController<User>
    {
        public UserController(IUserService service) : base(service) { }
    }
}
