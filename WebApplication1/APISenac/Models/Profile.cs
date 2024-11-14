using APISenac.Models;


namespace APISenac.Models
{

    public class Profile : BaseEntity
    {
         public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 
        public ICollection<User_Profile> User_Profiles { get; set; }
        public ICollection<Profile_Permition> Profile_Permitions { get; set; }
        public ICollection<Profile_CustomAtribute> Profile_CustomAtributes { get; set; }
        public ICollection<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; } = new List<UserProfile_CustomAtribute>();

        


    }
}