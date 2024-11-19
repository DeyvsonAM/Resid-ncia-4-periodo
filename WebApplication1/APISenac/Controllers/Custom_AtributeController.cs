using APISenac.Services;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

namespace APISenac.Controllers
{
    [Route("api/Custom_Atribute")]
    public class Custom_AtributeController : BaseController<Custom_Atribute>
    {
        public Custom_AtributeController(Custom_AtributeService service) : base(service) { }
    }
}
