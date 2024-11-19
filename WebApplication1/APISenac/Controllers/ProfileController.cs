using APISenac.Services;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISenac.Controllers
{
    [Route("api/profile")]
    public class ProfileController : BaseController<Profile>
    {
        public ProfileController(ProfileService service) : base(service) { }
    }
}
