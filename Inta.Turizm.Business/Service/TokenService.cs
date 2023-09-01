using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Business.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inta.Turizm.Business.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration configuration;
        public TokenService(IConfiguration _configuration)
        {
            configuration = (IConfigurationRoot)_configuration;
            var a = configuration["AppSettings:ValidIssuer"];
        }
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            if (configuration == null)
                return Task.FromResult(new GenerateTokenResponse { });

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var dateTimeNow = DateTime.UtcNow;

            JwtSecurityToken jwt = new JwtSecurityToken(
                    issuer: configuration["AppSettings:ValidIssuer"],
                    audience: configuration["AppSettings:ValidAudience"],
                    claims: new List<Claim> {
                    new Claim("userName", request.Username),
                    new Claim("Guide",Guid.NewGuid().ToString()),
                    new Claim("LoginDate", DateTime.Now.ToLongDateString())
                    },
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromMinutes(500)),
                    signingCredentials: credentials
                );
                        
            return Task.FromResult(new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate = dateTimeNow.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}
