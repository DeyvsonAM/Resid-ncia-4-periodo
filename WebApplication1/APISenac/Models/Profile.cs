using APISenac.Models.DTOs;


namespace APISenac.Models
{

    public class BDProfile : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;

        public virtual CreateSistemaDTO Sistema {get; set;} 
        public ICollection<UserProfile> UserProfiles { get; set; }
        public ICollection<ProfilePermission> ProfilePermissions { get; set; }
        public ICollection<ProfileCustomAtribute> ProfileCustomAtributes { get; set; }
        public ICollection<UserProfileCustomAtribute> UserProfileCustomAtributes { get; set; } = new List<UserProfileCustomAtribute>();

        


    }
}