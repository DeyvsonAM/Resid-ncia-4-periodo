namespace APISenac.Models
{
    public class Permition : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 

        public ICollection<Profile_Permition> Profile_Permitions { get; set; }

    }
}