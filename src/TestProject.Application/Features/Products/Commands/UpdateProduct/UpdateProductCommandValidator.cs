using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
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
