namespace APISenac.Models
{
    public class Permission : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 

        public ICollection<ProfilePermission> ProfilePermissions { get; set; }

    }
}