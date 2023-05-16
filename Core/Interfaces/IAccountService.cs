using Core.DTOs.Account;
using Core.Wrappers;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<AuthenticationResponse>> RegisterAsync(RegisterRequest request, string origin);
        // Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
