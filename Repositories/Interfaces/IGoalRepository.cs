using SkillTrack.API.Models;

namespace SkillTrack.API.Repositories.Interfaces
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetGoalsByUserIdAsync(int userId);
        Task<Goal> GetGoalByIdAsync(int id);
        Task AddGoalAsync(Goal goal);
        void UpdateGoal(Goal goal);
        void DeleteGoal(Goal goal);
        Task SaveChangesAsync();
    }
}
