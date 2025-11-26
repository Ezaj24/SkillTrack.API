using FluentValidation;
using SkillTrack.API.DTOs.Goal;

namespace SkillTrack.API.Validators
{
    public class GoalCreateValidator : AbstractValidator<GoalCreateDto>
    {
        public GoalCreateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty.")
                .MinimumLength(5);

            RuleFor(x => x.TargetDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Target date must be in the future.");
        }
    }
}
