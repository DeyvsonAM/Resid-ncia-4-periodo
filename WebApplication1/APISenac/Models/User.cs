namespace APISenac.Models
{
    public class User : BaseEntity
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        private string Senha { get; set; } = string.Empty;
        private string Cpf { get; set; } = string.Empty;

        // Relacionamento entre User e User_Profile
        public ICollection<User_Profile> User_Profiles { get; set; } = new List<User_Profile>();

        // Relacionamento entre User e UserProfile_CustomAtribute
        public ICollection<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; } = new List<UserProfile_CustomAtribute>();
    }
}
