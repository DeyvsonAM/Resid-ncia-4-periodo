namespace APISenac.Models.DTOs
{
    // DTO para criação de permissões
    public class CreatePermissionDTO
    {

        public string Nome { get; set; } = string.Empty;

        public Guid SistemaId { get; set; } // Referência ao Sistema por ID

        
    }

    // DTO para representar apenas o ID do Sistema
    
}
