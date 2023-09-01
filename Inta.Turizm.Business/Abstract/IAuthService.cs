using Inta.Turizm.Business.Model;

namespace Inta.Turizm.Business.Abstract
{
    public interface IAuthService
    {
        public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);

    }
}
