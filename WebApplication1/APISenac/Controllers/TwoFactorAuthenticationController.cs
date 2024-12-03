using Microsoft.AspNetCore.Mvc;
using APISenac.Services;
using APISenac.Data;
using APISenac.Models.DTOs;


namespace APISenac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwoFactorAuthenticationController : ControllerBase
    {
        private readonly TwoFactorAuthenticationService _twoFactorService;
        private readonly AppDbContext _context;

        public TwoFactorAuthenticationController(TwoFactorAuthenticationService twoFactorService, AppDbContext context)
        {
            _twoFactorService = twoFactorService;
            _context = context;
        }

        [HttpGet("server-time")]
        public IActionResult GetServerTime()
        {
            var serverTime = DateTime.UtcNow; 
            return Ok(new { ServerTime = serverTime });
        }

        [HttpPost("setup")]
        public IActionResult SetupTwoFactorAuthentication(string userId)
        {
            // Tente converter o userId de string para Guid
            if (!Guid.TryParse(userId, out Guid userGuid))
            {
                return BadRequest("ID de usuário inválido.");
            }

            var user = _context.Users.Find(userGuid);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            // Gerar chave secreta
            var secretKey = _twoFactorService.GenerateSecretKey();

            // Armazenar a chave secreta no usuário
            user.TwoFactorSecretKey = secretKey;
            _context.SaveChanges();

            // Gerar o URL do QR Code e a imagem em Base64
            var qrCodeImageBase64 = _twoFactorService.GenerateQrCodeImage(secretKey, user.Email, "API.SENAC");

            // Retornar a chave secreta e a imagem do QR Code (em Base64)
            return Ok(new { SecretKey = secretKey, QrCodeImageBase64 = qrCodeImageBase64 });
        }

        [HttpPost("validate")]
        public IActionResult ValidateTwoFactorCode([FromBody] ValidateCodeRequest request)
        {
            if (string.IsNullOrEmpty(request.SecretKey) || string.IsNullOrEmpty(request.Code))
            {
                return BadRequest("Secret key or code cannot be null.");
            }

            var isValid = _twoFactorService.ValidateCode(request.SecretKey, request.Code);
            if (isValid)
            {
                return Ok("Code is valid.");
            }

            return Unauthorized("Invalid code.");
        }

        private string GetCurrentUserId()
        {
            return User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        }
    }
}
