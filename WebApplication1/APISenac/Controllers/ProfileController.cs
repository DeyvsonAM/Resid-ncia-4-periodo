
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;


namespace APISenac.Controllers
{
    [Route("api/profile")]
    public class ProfileController : BaseController<Profile>
    {
        public ProfileController(IProfileService service) : base(service) { }
    }
}
