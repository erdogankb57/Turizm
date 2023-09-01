using Inta.Turizm.Business.Model;

namespace Inta.Turizm.Business.Abstract
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request);
    }
}
