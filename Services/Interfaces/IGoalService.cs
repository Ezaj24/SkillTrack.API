using SkillTrack.API.DTOs.Goal;

namespace SkillTrack.API.Services.Interfaces
{
    public interface IGoalService
    {
        Task<List<GoalResponseDto>> GetGoalsByUserIdAsync(int userId);
        Task<GoalResponseDto> CreateGoalAsync(int userId, GoalCreateDto dto);

        Task<GoalResponseDto> UpdateGoalAsync(int id, GoalUpdateDto dto);
        Task<bool> MarkGoalCompletedAsync(int id);
        Task<bool> DeleteGoalAsync(int id);

    }
}
