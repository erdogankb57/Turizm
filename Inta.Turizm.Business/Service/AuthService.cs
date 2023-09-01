using Inta.Turizm.Business.Abstract;
using Inta.Turizm.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inta.Turizm.Business.Service
{
    public class AuthService : IAuthService
    {
        private ITokenService tokenService;
        public AuthService(ITokenService _tokenService)
        {
            tokenService = _tokenService;
        }
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Username == "erdogan" && request.Password == "123456")
            {
                /*Access Token*/
                var accessToken = tokenService.GenerateToken(new GenerateTokenRequest
                {
                    Username = request.Username
                });

                response.AccessTokenExpireDate = accessToken.Result.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = accessToken.Result.Token;
            }

            return Task.FromResult(response);
        }
    }
}
