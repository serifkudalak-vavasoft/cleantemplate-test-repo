using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;

namespace TestProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(_ => _.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} zorunlu");

            RuleFor(_ => _.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} zorunlu");

            RuleFor(_ => _.Price)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} zorunlu");

            RuleFor(_ => _.CategoryId)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} zorunlu");
        }
    }
}
