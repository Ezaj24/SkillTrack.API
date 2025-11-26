using FluentValidation;
using SkillTrack.API.DTOs.Goal;

namespace SkillTrack.API.Validators
{
    public class GoalUpdateValidator : AbstractValidator<GoalUpdateDto>
    {
        public GoalUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.TargetDate)
                .GreaterThan(DateTime.UtcNow);
        }
    }
}
