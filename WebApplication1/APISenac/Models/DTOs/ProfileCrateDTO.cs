using APISenac.Models;

namespace APISenac.Models.DTOs
{
    public class CreateBDProfileDTO
    {
       
        public string Nome { get; set; } = string.Empty;

        public CreateSistemaDTO SistemaNome { get; set; }

        public List<Guid> ProfilePermissions { get; set; } = new List<Guid>();

       
        public List<Guid> ProfileCustomAtributes { get; set; } = new List<Guid>();

       
        public List<Guid> UserProfileCustomAtributes { get; set; } = new List<Guid>();

        
    
      
    }
    }
    

