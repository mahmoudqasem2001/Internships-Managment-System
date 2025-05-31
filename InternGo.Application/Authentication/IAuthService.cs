
using InternGo.Application.Authentication.Common;

namespace InternGo.Application.Authentication
{
    public interface IAuthService
    {
        Task<AuthenticationResult> LoginAsync(LoginRequest request);
        Task<AuthenticationResult> RegisterAsync(RegisterRequest request);

    }
}
