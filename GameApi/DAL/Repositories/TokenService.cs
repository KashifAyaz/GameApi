using GameApi.DAL.Interfaces;
using GameApi.Models;
using GameApi.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameApi.DAL.Repositories
{
    public class TokenService : ITokenService
    {
        private const string SecretKey = "this is my custom super secret key for game api authentication";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public string GenerateToken(UserViewModel usr)
        {
            var user = User.Users.FirstOrDefault(x => x.Username == usr.Username && x.Password == usr.Password);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("role", user.Role),
                new Claim("regions", string.Join(",", user.Regions))
            };
            var token = new JwtSecurityToken(
               issuer: "GameApi",
               audience: "GameApi",
               claims: claims,
               expires: DateTime.UtcNow.AddHours(1),
               signingCredentials: new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
