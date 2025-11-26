using SkillTrack.API.Models;
using SkillTrack.API.Enums;



namespace SkillTrack.API.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetSkillsByUserIdAsync(int userId);
        Task<Skill?> GetSkillByIdAsync(int id);

        Task AddSkillAsync (Skill skill);

        Task UpdateSkillAsync (Skill skill);

        Task DeleteSkillAsync (Skill skill);

        Task<bool> SaveChangesAsync();
    }
}