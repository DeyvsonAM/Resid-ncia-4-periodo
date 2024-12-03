using AutoMapper;
using APISenac.Models;
using APISenac.Models.DTOs;

namespace APISenac.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento bidirecional onde não há configurações específicas
            CreateMap<BDProfile, CreateBDProfileDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<CustomAtribute, CreateCustomAtributeDTO>().ReverseMap();
            CreateMap<Sistema, CreateSistemaDTO>().ReverseMap();

            // Configuração específica para Permission
            CreateMap<CreatePermissionDTO, Permission>();

            CreateMap<CreateBDProfileDTO, BDProfile>()
            .ForMember(dest => dest.ProfilePermissions, opt => opt.Ignore())
            .ForMember(dest => dest.ProfileCustomAtributes, opt => opt.Ignore())
            .ForMember(dest => dest.UserProfileCustomAtributes, opt => opt.Ignore());


            CreateMap<CreateCustomAtributeDTO, CustomAtribute>()
            .ForMember(dest => dest.ProfileCustomAtributes, opt => opt.Ignore())
            .ForMember(dest => dest.UserProfileCustomAtributes, opt => opt.Ignore());


            CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.UserProfiles, opt => opt.Ignore())
            .ForMember(dest => dest.UserProfileCustomAtributes, opt => opt.Ignore());
            

        }
    }
}
