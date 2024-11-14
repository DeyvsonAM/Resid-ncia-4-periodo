namespace APISenac.Models
{
    public class Profile_Permition

    { 
        public Guid ProfilePermitionId { get; set; }
        //Chave estrangeira
        public Guid ProfileId { get; set; }
        public Guid PermitionId { get; set; }

        
        public Profile Profile { get; set; }
        public Permition Permition { get; set; }

        
    }
}