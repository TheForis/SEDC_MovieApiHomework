using Microsoft.IdentityModel.Tokens;
using Qinshift.Movies.DomainModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Qinshift.Movies.Services.Helper
{
    public static class TokenHelper
    {
        public static SecurityToken GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes("The secretest sentence for getting an unique token is this right here");

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                                            SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                        new Claim("userFullName", $"{user.FirstName}{user.LastName}")
                    })
            };

            // 5. Generate Token
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }
    }
}
