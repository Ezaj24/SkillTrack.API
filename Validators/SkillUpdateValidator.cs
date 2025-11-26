using FluentValidation;
using SkillTrack.API.DTOs.Skill;

namespace SkillTrack.API.Validators
{
    public class SkillUpdateValidator : AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Skill name is required.")
                .MinimumLength(2).WithMessage("Skill name must be at least 2 characters.");

            RuleFor(x => x.Level)
                .IsInEnum().WithMessage("Skill level is not valid.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.");
        }
    }
}
