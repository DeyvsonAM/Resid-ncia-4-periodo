namespace APISenac.Models
{
    public class Custom_Atribute : BaseEntity
    {
        public string Valor { get; set; }
        public string TipoAtributo { get; set; }
        public byte Requerimento { get; set; }
        public char Delimitador { get; set; }
        public ICollection<Profile_CustomAtribute> Profile_CustomAtributes { get; set; }
        public ICollection<UserProfile_CustomAtribute> UserProfile_CustomAtributes { get; set; }

    }
}