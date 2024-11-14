namespace APISenac.Models
{
    public class UserProfile_CustomAtribute 
    {
        
        //Chave estrangeira
        public Guid UserProfileId {get; set;}
        public Guid CustomAtributeId { get; set; }

        public User_Profile User_Profile { get; set; }
        public Custom_Atribute CustomAtribute { get; set; }
    }
}