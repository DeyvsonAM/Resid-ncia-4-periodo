using APISenac.Services.Interfaces;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Models.DTOs;
using AutoMapper;

namespace APISenac.Controllers
{
    [Route("api/permission")]
    public class PermissionController : BaseController<Permission, CreatePermissionDTO>
    {
        public PermissionController(IPermissionService service, IMapper mapper) : base(service, mapper) { }
    }
}
