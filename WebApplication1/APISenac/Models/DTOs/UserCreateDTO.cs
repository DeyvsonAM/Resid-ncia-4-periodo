namespace APISenac.Models.DTOs
{
    public class CreateUserDTO
    {
        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;
       
        public List<Guid> UserProfiles { get; set; } = new List<Guid>();

        public List<Guid> UserProfileCustomAtributes { get; set; } = new List<Guid>();
    }
}
