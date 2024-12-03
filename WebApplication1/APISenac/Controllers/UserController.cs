using APISenac.Models.DTOs;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;

using AutoMapper;



namespace APISenac.Controllers
{
    [Route("api/user")]
    public class UserController : BaseController<User, CreateUserDTO>
    {
        public UserController(IUserService service, IMapper mapper) : base(service, mapper) { }
    }
}
