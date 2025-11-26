using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SkillTrack.API.Enums;



namespace SkillTrack.API.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }
        public SkillLevel Level { get; set; }
        public string Category { get; set; }    

        public DateTime CreatedAt {  get; set; } = DateTime.UtcNow;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;    

    }
}