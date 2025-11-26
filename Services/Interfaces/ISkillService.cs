using SkillTrack.API.DTOs.Skill;

namespace SkillTrack.API.Services.Interfaces
{
    public interface ISkillService
    {
        Task<List<SkillResponseDto>> GetSkillsByUserIdAsync(int userId);
        Task<SkillResponseDto> AddSkillAsync(int userId, SkillCreateDto dto);
        Task<SkillResponseDto> UpdateSkillAsync(int id, SkillUpdateDto dto);
        Task DeleteSkillAsync(int id);
    }
}
