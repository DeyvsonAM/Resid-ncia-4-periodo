using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services;

namespace APISenac.Controllers
{
    [Route("api/sistema")]
    public class SistemaController : BaseController<Sistema>
    {
        public SistemaController(ISistemaService service) : base(service) { }
    }
}
