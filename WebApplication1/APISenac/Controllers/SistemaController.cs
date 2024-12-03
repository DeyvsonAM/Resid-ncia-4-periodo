using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APISenac.Models.DTOs;


namespace APISenac.Controllers
{
    [Route("api/sistema")]
    public class SistemaController : BaseController<Sistema, CreateSistemaDTO>
    {
        public SistemaController(ISistemaService service, IMapper mapper) : base(service, mapper) { }
    }
}
