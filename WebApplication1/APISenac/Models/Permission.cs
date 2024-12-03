namespace APISenac.Models
{
    public class Permission : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
         public Guid SistemaId { get; set; } 

        public virtual Sistema Sistema {get; set;} 

        public ICollection<ProfilePermission> ProfilePermissions { get; set; }

    }
}