namespace SkillTrack.API.DTOs.Goal
{
    public class GoalUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
