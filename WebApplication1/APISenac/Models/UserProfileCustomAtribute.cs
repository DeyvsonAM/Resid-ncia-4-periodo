namespace APISenac.Models
{
    public class UserProfileCustomAtribute 
    {
        
        //Chave estrangeira
        public Guid UserProfileId {get; set;}
        public Guid CustomAtributeId { get; set; }

        public UserProfile UserProfile { get; set; }
        public CustomAtribute CustomAtribute { get; set; }
    }
}