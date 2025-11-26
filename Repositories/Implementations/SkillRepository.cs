using Microsoft.EntityFrameworkCore;
using SkillTrack.API.Data;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories.Interfaces;

namespace SkillTrack.API.Repositories.Implementations
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetSkillsByUserIdAsync(int userId)
        {
            return await _context.Skills
                .Where(s => s.UserId == userId)
                .ToListAsync();
        }

        public async Task<Skill?> GetSkillByIdAsync(int id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task AddSkillAsync(Skill skill)
        {
            await _context.Skills.AddAsync(skill);
        }

        public async Task UpdateSkillAsync(Skill skill)
        {
            _context.Skills.Update(skill);
        }

        public async Task DeleteSkillAsync(Skill skill)
        {
            _context.Skills.Remove(skill);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
