using FluentValidation;
using TestProject.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Features.AutoParts.Commands.CreateAutoPart
{
    public class CreateAutoPartCommandValidator : AbstractValidator<CreateAutoPartCommand>
    {
        private readonly IAutoPartRepository _autopartRepository;
        public CreateAutoPartCommandValidator(IAutoPartRepository autopartRepository)
        {
            _autopartRepository = autopartRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(AutoPartNameUnique)
                .WithMessage("An autopart with the same name already exists.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> AutoPartNameUnique(CreateAutoPartCommand e, CancellationToken token)
        {
            return !await _autopartRepository.IsAutoPartNameUnique(e.Name);
        }
    }
}
