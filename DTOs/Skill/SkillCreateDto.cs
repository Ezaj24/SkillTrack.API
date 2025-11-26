using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs.Skill
{
    public class SkillCreateDto
    {
        public string Name { get; set; }

        public SkillLevel Level { get; set; }

        public string Category { get; set; }
    }
}