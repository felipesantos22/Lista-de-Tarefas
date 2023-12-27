using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using list.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace list.Services.Token;

public class TokenService
{
    public static object GenerateToken(User user)
    {
        var Key = Encoding.ASCII.GetBytes(Services.Token.Key.Secret);
        var tokenConfig = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);
        return new
        {
            token = tokenString
        };
    }
}