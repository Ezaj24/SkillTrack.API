using SkillTrack.API.DTOs.Skill;
using SkillTrack.API.Models;
using SkillTrack.API.Repositories.Interfaces;
using SkillTrack.API.Services.Interfaces;

namespace SkillTrack.API.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillResponseDto>> GetSkillsByUserIdAsync(int userId)
        {
            var skills = await _repository.GetSkillsByUserIdAsync(userId);

            return skills.Select(s => new SkillResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Level = s.Level,
                Category = s.Category,
                CreatedAt = s.CreatedAt,
                LastUpdated = s.LastUpdated
            }).ToList();
        }

        public async Task<SkillResponseDto> AddSkillAsync(int userId, SkillCreateDto dto)
        {
            var skill = new Skill
            {
                UserId = userId,
                Name = dto.Name,
                Level = dto.Level,
                Category = dto.Category,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            await _repository.AddSkillAsync(skill);
            await _repository.SaveChangesAsync();

            return new SkillResponseDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level,
                Category = skill.Category,
                CreatedAt = skill.CreatedAt,
                LastUpdated = skill.LastUpdated
            };
        }

        public async Task<SkillResponseDto> UpdateSkillAsync(int id, SkillUpdateDto dto)
        {
            var skill = await _repository.GetSkillByIdAsync(id);
            if (skill == null) throw new Exception("Skill not found");

            skill.Name = dto.Name;
            skill.Level = dto.Level;
            skill.Category = dto.Category;
            skill.LastUpdated = DateTime.UtcNow;

            await _repository.UpdateSkillAsync(skill);
            await _repository.SaveChangesAsync();

            return new SkillResponseDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Level = skill.Level,
                Category = skill.Category,
                CreatedAt = skill.CreatedAt,
                LastUpdated = skill.LastUpdated
            };
        }

        public async Task DeleteSkillAsync(int id)
        {
            var skill = await _repository.GetSkillByIdAsync(id);
            if (skill == null) throw new Exception("Skill not found");

            await _repository.DeleteSkillAsync(skill);
            await _repository.SaveChangesAsync();
        }
    }
}
