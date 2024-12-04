using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APISenac.Models.DTOs;

namespace APISenac.Controllers
{
    [Route("api/sistema")]
    [ApiController] // Certifique-se de que a classe é um Controller de API
    public class SistemaController : BaseController<Sistema, CreateSistemaDTO>
    {
        private readonly ISistemaService _sistemaService;

        public SistemaController(ISistemaService service, IMapper mapper) : base(service, mapper) 
        {
            _sistemaService = service;
        }

        
    }
}
