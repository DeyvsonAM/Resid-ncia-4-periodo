namespace APISenac.Models.DTOs
{
    public class CreateCustomAtributeDTO
    {

        public string Valor { get; set; } = string.Empty;

        public string TipoAtributo { get; set; } = string.Empty;

        public byte Requerimento { get; set; }

        public char Delimitador { get; set; }
        public List<Guid> ProfileCustomAtributes { get; set; } = new List<Guid>();

        public List<Guid> UserProfileCustomAtributes { get; set; } = new List<Guid>();
    }
}
