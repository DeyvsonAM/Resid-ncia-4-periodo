namespace APISenac.Models.DTOs
{
    public class ValidateCodeRequest
    {
        public string SecretKey { get; set; }
        public string Code { get; set; }
    }
}
