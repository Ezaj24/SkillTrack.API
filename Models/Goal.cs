namespace SkillTrack.API.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }      // NEW
        public DateTime TargetDate { get; set; }     // NEW

        public DateTime CreatedAt { get; set; }      // NEW
        public DateTime LastUpdated { get; set; }    // NEW

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
