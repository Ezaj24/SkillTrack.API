using SkillTrack.API.DTOs.Goal;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories.Interfaces;
using SkillTrack.API.Services.Interfaces;

namespace SkillTrack.API.Services.Implementations
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<List<GoalResponseDto>> GetGoalsByUserIdAsync(int userId)
        {
            var goals = await _goalRepository.GetGoalsByUserIdAsync(userId);

            return goals.Select(g => new GoalResponseDto
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                TargetDate = g.TargetDate,
                CreatedAt = g.CreatedAt,
                LastUpdated = g.LastUpdated,
                IsCompleted = g.IsCompleted
            }).ToList();
        }

        public async Task<GoalResponseDto> CreateGoalAsync(int userId, GoalCreateDto dto)
        {
            var goal = new Goal
            {
                Title = dto.Title,
                Description = dto.Description,
                TargetDate = dto.TargetDate,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            await _goalRepository.AddGoalAsync(goal);
            await _goalRepository.SaveChangesAsync();

            return new GoalResponseDto
            {
                Id = goal.Id,
                Title = goal.Title,
                Description = goal.Description,
                TargetDate = goal.TargetDate,
                CreatedAt = goal.CreatedAt,
                LastUpdated = goal.LastUpdated,
                IsCompleted = goal.IsCompleted
            };
        }
        public async Task<GoalResponseDto> UpdateGoalAsync(int id, GoalUpdateDto dto)
        {
            var goal = await _goalRepository.GetGoalByIdAsync(id);
            if (goal == null)
                throw new Exception("Goal not found");

            goal.Title = dto.Title;
            goal.Description = dto.Description;
            goal.TargetDate = dto.TargetDate;
            goal.LastUpdated = DateTime.UtcNow;
            

            _goalRepository.UpdateGoal(goal);
            await _goalRepository.SaveChangesAsync();

            return new GoalResponseDto
            {
                Id = goal.Id,
                Title = goal.Title,
                Description = goal.Description,
                TargetDate = goal.TargetDate,
                CreatedAt = goal.CreatedAt,
                LastUpdated = goal.LastUpdated,
                IsCompleted = goal.IsCompleted
            };
        }
        public async Task<bool> MarkGoalCompletedAsync(int id)
        {
            var goal = await _goalRepository.GetGoalByIdAsync(id);
            if (goal == null)
                throw new Exception("Goal not found");

            goal.IsCompleted = true;
            goal.LastUpdated = DateTime.UtcNow;

            _goalRepository.UpdateGoal(goal);
            await _goalRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteGoalAsync(int id)
        {
            var goal = await _goalRepository.GetGoalByIdAsync(id);
            if (goal == null)
                throw new Exception("Goal not found");

            _goalRepository.DeleteGoal(goal);
            await _goalRepository.SaveChangesAsync();

            return true;
        }


    }
}
