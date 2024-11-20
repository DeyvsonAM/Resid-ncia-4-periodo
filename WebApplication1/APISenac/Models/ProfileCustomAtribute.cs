namespace APISenac.Models
{
    public class Profile_CustomAtribute
    {
        //Chave estrangeira
        public Guid CustomAtributeId { get; set; }
        public Guid ProfileId { get; set; }
        
        
        
        public Profile Profile { get; set; }
        public CustomAtribute CustomAtribute { get; set; }
    }
}