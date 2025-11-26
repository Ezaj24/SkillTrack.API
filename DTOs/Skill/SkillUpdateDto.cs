using SkillTrack.API.Enums;

namespace SkillTrack.API.DTOs.Skill
{
    public class SkillUpdateDto
    {

        public string Name { get; set; }
        public SkillLevel Level {  get; set; }

        public string Category { get; set; }


    }
}