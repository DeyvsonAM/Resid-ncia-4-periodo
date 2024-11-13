namespace APISenac.Models
{
    public class User_Profile : BaseEntity
    {
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}