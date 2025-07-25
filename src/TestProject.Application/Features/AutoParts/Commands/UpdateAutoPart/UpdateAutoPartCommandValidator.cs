using FluentValidation;

namespace TestProject.Application.Features.AutoParts.Commands.UpdateAutoPart
{
    public class UpdateAutoPartCommandValidator : AbstractValidator<UpdateAutoPartCommand>
    {
        public UpdateAutoPartCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }
    }
}
