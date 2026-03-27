using TaskFlow.Entities.DTOs.Auth;

namespace TaskFlow.Business.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);
    Task<string> LoginAsync(LoginDto dto);
}