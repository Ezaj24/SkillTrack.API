using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs.Skill
{
    public class SkillResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SkillLevel Level { get; set; }

        public string Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}