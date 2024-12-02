using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Valide o usuário (substitua pela lógica real, como consulta ao banco)
        if (request.Username == "admin" && request.Password == "password")
        {
            // Cria as claims para o token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin") // Role é opcional
            };

            // Gera a chave de assinatura
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuaChaveSecretaMuitoForte"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Cria o token
            var token = new JwtSecurityToken(
                issuer: "https://seusite.com",
                audience: "https://seusite.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        return Unauthorized(new { Message = "Credenciais inválidas." });
    }
}

// Classe para representar o payload de login
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}


// Como testar o endpoint via JSON :

// Envie uma requisição POST para api/auth/login com o JSON:
// json
// {
//   "username": "admin",
//   "password": "password"
// }
