namespace APISenac.Models
{
    public class Permitions : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;

        public virtual Sistema Sistema {get; set;} 

    }
}