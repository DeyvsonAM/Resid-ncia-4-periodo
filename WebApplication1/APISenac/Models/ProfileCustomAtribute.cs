namespace APISenac.Models
{
    public class ProfileCustomAtribute
    {
        //Chave estrangeira
        public Guid CustomAtributeId { get; set; }
        public Guid ProfileId { get; set; }
        
        
        
        public BDProfile Profile { get; set; }
        public CustomAtribute CustomAtribute { get; set; }
    }
}