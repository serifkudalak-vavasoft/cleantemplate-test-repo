using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;
using TestProject.Application.Responses;
using TestProject.Domain.Entities;

namespace TestProject.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseResponse<bool>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper, IAsyncRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return BaseResponse<bool>.Fail($"Kategori bulunamadı. Id: {request.Id}");
            }

            category.IsActive = false;
            category.LastModifiedDate = DateTime.Now;

            await _categoryRepository.UpdateAsync(category);

            var products = await _productRepository.ListAsync(_ => _.CategoryId == request.Id);

            if (products.Any())
            {
                foreach (var item in products)
                {
                    item.IsActive = false;
                    item.LastModifiedDate = DateTime.Now;
                }
            }

            await _productRepository.UpdateRangeAsync(products);

            return BaseResponse<bool>.SuccessResponse(true, "Kategori pasif hale getirildi");
        }
    }
}
