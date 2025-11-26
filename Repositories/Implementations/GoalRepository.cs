using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Data;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories.Interfaces;

namespace SkillTrack.API.Repositories.Implementations
{
    public class GoalRepository : IGoalRepository
    {
        private readonly AppDbContext _context;

        public GoalRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Goal>> GetGoalsByUserIdAsync(int userId)
        {
            return _context.Goals
                .Where(g => g.UserId == userId)
                .ToListAsync();
        }

        public async Task AddGoalAsync(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
        }
        public Task<Goal> GetGoalByIdAsync(int id)
        {
            return _context.Goals.FirstOrDefaultAsync(g => g.Id == id);
        }

        public void UpdateGoal(Goal goal)
        {
            _context.Goals.Update(goal);
        }

        public void DeleteGoal(Goal goal)
        {
            _context.Goals.Remove(goal);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
