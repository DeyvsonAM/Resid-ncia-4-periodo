namespace APISenac.Models
{
    public class ProfilePermission

    { 
        public Guid ProfilePermissionId { get; set; }
        //Chave estrangeira
        public Guid ProfileId { get; set; }
        public Guid PermissionId { get; set; }

        
        public Profile Profile { get; set; }
        public Permission Permission { get; set; }

        
    }
}