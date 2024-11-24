using APISenac.Services;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISenac.Controllers
{
    [Route("api/permition")]
    public class PermitionController : BaseController<Permission>
    {
        public PermitionController(PermitionService service) : base(service) { }
    }
}
