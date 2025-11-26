using SkillTrack.API.DTOs.Auth;
using SkillTrack.API.Models;

namespace SkillTrack.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
        string CreateToken(User user);
    }
}
