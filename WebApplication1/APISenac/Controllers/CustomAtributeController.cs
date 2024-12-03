using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APISenac.Models.DTOs;

namespace APISenac.Controllers
{
    [Route("api/CustomAtribute")]
    public class CustomAtributeController : BaseController<CustomAtribute, CreateCustomAtributeDTO>
    {
        public CustomAtributeController(ICustomAtributeService service, IMapper mapper) : base(service, mapper) { }
    }
}

