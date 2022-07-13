using JSONTokenLoginAPI.Entities;
using JSONTokenLoginAPI.Helper;
using JSONTokenLoginAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSONTokenLoginAPI.Service
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }

    public class AuthenticationService : IAuthenticationService
    {
        // hardcoded user for simplicity
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "mytest",
                LastName = "User",
                Username = "mytestuser",
                Password = "test123"
            }
        };
        private readonly AppSettings _appSettings;
        public AuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.UserName && x.Password == model.Password);
            if (user == null) return null;
            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }
        // Generate JwtToken
        private string generateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Here you  can fill claim information from database for the users as well
            var claims = new[] {
                new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "atul"),
                    new Claim(JwtRegisteredClaimNames.Email, ""),
                    new Claim("Role", "Admin"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(_appSettings.Issuer, _appSettings.Issuer, claims, expires: DateTime.Now.AddHours(24), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
