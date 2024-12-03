using OtpNet;
using QRCoder;
using System.Drawing;

namespace APISenac.Services
{
    public class TwoFactorAuthenticationService
    {
        public string GenerateSecretKey()
        {
            var secretKey = KeyGeneration.GenerateRandomKey(20); // 20 bytes
            return Base32Encoding.ToString(secretKey);
        }

        public string GenerateQrCodeUrl(string secretKey, string userEmail, string issuer)
        {
            var bytesSecretKey = Base32Encoding.ToBytes(secretKey);
            return $"otpauth://totp/{issuer}:{userEmail}?secret={secretKey}&issuer={issuer}";
        }

        public bool ValidateCode(string secretKey, string code)
        {
            var bytesSecretKey = Base32Encoding.ToBytes(secretKey);
             var totp = new Totp(bytesSecretKey, step: 30, totpSize: 6); 
            return totp.VerifyTotp(code, out _);
        }

        public string GenerateQrCodeImage(string secretKey, string email, string appName)
        {
            // Gerar o URL para o QR Code
            var qrCodeUrl = $"otpauth://totp/{appName}:{email}?secret={secretKey}&issuer={appName}";

            // Criar o gerador de QR Code
            using (var qrGenerator = new QRCodeGenerator())
            {
                var qrCodeData = qrGenerator.CreateQrCode(qrCodeUrl, QRCodeGenerator.ECCLevel.Q);

                using (var qrCode = new QRCode(qrCodeData))
                {
                    using (var qrCodeImage = qrCode.GetGraphic(20))
                    {
                        // Converter a imagem para Base64 (para exibição em HTML)
                        using (var ms = new MemoryStream())
                        {
                            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteArray = ms.ToArray();
                            return Convert.ToBase64String(byteArray); // Retorna a imagem em formato Base64
                        }
                    }
                }
            }
        }
    }
}

