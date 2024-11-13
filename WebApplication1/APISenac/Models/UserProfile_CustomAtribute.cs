namespace APISenac.Models
{
    public class UserProfile_CustomAtribute : BaseEntity
    {
        public User_Profile User_Profile { get; set; }
        public Custom_Atribute Custom_Atribute { get; set; }
    }
}