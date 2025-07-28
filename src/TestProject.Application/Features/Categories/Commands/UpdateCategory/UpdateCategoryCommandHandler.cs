using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;
using TestProject.Application.Exceptions;
using TestProject.Domain.Entities;

namespace TestProject.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,UpdateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategoryCommandResponse = new UpdateCategoryCommandResponse();

            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                updateCategoryCommandResponse.Success = false;
                updateCategoryCommandResponse.Message = $"Kategori Bulunamadı. Id: {request.Id}";
                return updateCategoryCommandResponse;
            }
            else
            {
                var validatorResponse = await new UpdateCategoryCommandValidator().ValidateAsync(request);

                if (validatorResponse.Errors.Count > 0)
                {
                    updateCategoryCommandResponse.Success = false;
                    updateCategoryCommandResponse.ValidationErrors = new List<string>();

                    foreach (var error in validatorResponse.Errors)
                    {
                        updateCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                }

                if (updateCategoryCommandResponse.Success)
                {
                    category.LastModifiedDate = DateTime.Now;
                    _mapper.Map(request, category);

                    await _categoryRepository.UpdateAsync(category);
                    updateCategoryCommandResponse.Category = _mapper.Map<UpdateCategoryDto>(category);
                }

                return updateCategoryCommandResponse;
            }
        }
    }
}
