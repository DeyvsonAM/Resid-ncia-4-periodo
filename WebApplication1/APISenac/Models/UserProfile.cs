namespace APISenac.Models
{
    public class UserProfile
    {
        public Guid UserProfileId { get; set; }
        //Chave estrangeira
        public Guid UserId { get; set; }
        public Guid ProfileId { get; set; }
        public ICollection<UserProfileCustomAtribute> UserProfileCustomAtributes { get; set; }
      
        //Navegação
        public User User { get; set; }
        public BDProfile Profile { get; set; }

        
    }
    
}