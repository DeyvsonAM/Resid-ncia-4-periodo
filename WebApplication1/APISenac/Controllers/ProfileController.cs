using AutoMapper;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services.Interfaces;
using APISenac.Models.DTOs;

namespace APISenac.Controllers
{
    [Route("api/profile")]
    public class ProfileController : BaseController<BDProfile, CreateBDProfileDTO>
    {
        private readonly IBDProfileService _profileService;

        public ProfileController(IBDProfileService profileService, IMapper mapper) 
            : base(profileService, mapper) 
        {
            _profileService = profileService;
        }

        // Endpoint para obter permissões associadas a um perfil
       
        }
    }

