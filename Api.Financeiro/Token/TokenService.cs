using Api.Financeiro.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Financeiro.Token
{
    public class TokenService
    {
        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();            
            var chKey = Encoding.ASCII.GetBytes(Key.Secret);   
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chKey), SecurityAlgorithms.HmacSha256Signature)
            };

           
            var token = tokenHandler.CreateToken(tokenConfig);

            return tokenHandler.WriteToken(token);
           
        }
    }
}
