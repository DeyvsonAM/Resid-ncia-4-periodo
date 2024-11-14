namespace APISenac.Models
{
    public class User_Profile
    {
        public Guid UserProfileId { get; set; }
        //Chave estrangeira
        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        public ICollection<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; }
      
        //Navegação
        public User User { get; set; }
        public Profile Profile { get; set; }

        
    }
    
}