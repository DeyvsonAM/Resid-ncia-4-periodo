namespace APISenac.Models
{
    public class ProfilePermission : BaseEntity

    { 
     
        //Chave estrangeira
        public Guid ProfileId { get; set; }
        public Guid PermissionId { get; set; }

        
        public BDProfile Profile { get; set; }
        public Permission Permission { get; set; }

        
    }
}