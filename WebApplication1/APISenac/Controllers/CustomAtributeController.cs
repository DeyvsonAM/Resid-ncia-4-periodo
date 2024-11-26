using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISenac.Controllers
{
    [Route("api/CustomAtribute")]
    public class CustomAtributeController : BaseController<CustomAtribute>
    {
        public CustomAtributeController(ICustomAtributeService service) : base(service) { }
    }
}

