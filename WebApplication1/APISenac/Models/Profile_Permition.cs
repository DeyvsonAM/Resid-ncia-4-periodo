namespace APISenac.Models
{
    public class Profile_Permition : BaseEntity
    {
        public Profile Profile { get; set; }
        public Permitions Permitions { get; set; }
    }
}