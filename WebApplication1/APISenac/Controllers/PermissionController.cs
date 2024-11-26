using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISenac.Controllers
{
    [Route("api/permission")]
    public class PermissionController : BaseController<Permission>
    {
        public PermissionController(IPermissionService service) : base(service) { }
    }
}
