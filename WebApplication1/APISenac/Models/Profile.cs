using APISenac.Models;


namespace APISenac.Models
{

    public class Profile : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 
        public ICollection<UserProfile> UserProfiles { get; set; }
        public ICollection<ProfilePermition> ProfilePermitions { get; set; }
        public ICollection<Profile_CustomAtribute> ProfileCustomAtributes { get; set; }
        public ICollection<UserProfileCustomAtribute> UserProfileCustomAtributes { get; set; } = new List<UserProfileCustomAtribute>();

        


    }
}