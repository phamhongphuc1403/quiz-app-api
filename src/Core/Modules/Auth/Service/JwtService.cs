using Microsoft.IdentityModel.Tokens;
using quiz_app_api.src.Core.Database.Model;
using quiz_app_api.src.Core.ENVs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace quiz_app_api.src.Core.Modules.Auth.Service
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly double _expireDay;
        private readonly double _expireMinute;
        public JwtService()
        {
            _secret = ENV.JWT_SECRET;
            _expireMinute = Convert.ToDouble(ENV.EXPIRE_MINUTE);
            _expireDay = Convert.ToDouble(ENV.EXPIRE_DAY);
        }
        public string GenerateAccessToken(UserModel user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_secret);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.email),
                new Claim("username", user.username),
                new Claim("id", user.id.ToString()),
            };

            var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expireMinute),
                signingCredentials: SigningCredentials
            );

            var jwt = jwtTokenHandler.WriteToken(token);

            return jwt;
        }

        public string GenerateRefreshToken(UserModel user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_secret);

            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.id.ToString()),
            };

            var SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expireDay),
                signingCredentials: SigningCredentials
            );

            var jwt = jwtTokenHandler.WriteToken(token);

            return jwt;
        }

        public ClaimsPrincipal? Verify(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                return tokenHandler.ValidateToken(token, Validator(), out var validatedToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public TokenValidationParameters Validator()
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(_secret);

            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = TimeSpan.Zero
            };
        }
    }
}
