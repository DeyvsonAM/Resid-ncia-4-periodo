using System.Text.Json.Serialization;

namespace APISenac.Models
{
    public class CustomAtribute : BaseEntity
    {
        public string Valor { get; set; }
        public string TipoAtributo { get; set; }
        public byte Requerimento { get; set; }
        public char Delimitador { get; set; }

       
        public ICollection<Profile_CustomAtribute> ProfileCustomAtributes { get; set; }
        public ICollection<UserProfileCustomAtribute> UserProfileCustomAtributes { get; set; }

    }
}