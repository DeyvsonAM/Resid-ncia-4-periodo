namespace APISenac.Models.DTOs
{

    //Automapper - Conventions
    public class PermitionDTO
    {
        public string Nome { get; set; } = string.Empty;
        public SistemaCreatePermition Sistema { get; set; }  // DTO para o Sistema, incluindo somente o Id
        public List<Guid> ProfilePermitions { get; set; }  // Lista de IDs de Profile_Permition relacionados
    }

    // DTO para o Sistema, contendo apenas o Id do Sistema
    public class SistemaCreatePermition
    {
        public Guid Id { get; set; }  // Somente o Id do Sistema
    }
}
