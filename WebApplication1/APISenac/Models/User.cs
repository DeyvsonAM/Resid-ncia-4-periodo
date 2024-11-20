namespace APISenac.Models
{
    public class User : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        private string Senha { get; set; } = string.Empty;
        private string Cpf { get; set; } = string.Empty;

        // Relacionamento entre User e User_Profile
        public ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

        // Relacionamento entre User e UserProfile_CustomAtribute
        public ICollection<UserProfileCustomAtribute> UserProfileCustomAtributes { get; set; } = new List<UserProfileCustomAtribute>();
    }
}
