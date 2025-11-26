namespace SkillTrack.API.DTOs.Goal
{
    public class GoalResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsCompleted { get; set; }   // ADD THIS FIELD
    }
}
