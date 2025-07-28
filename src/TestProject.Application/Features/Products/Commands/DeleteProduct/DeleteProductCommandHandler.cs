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

namespace TestProject.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseResponse<bool>>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) return BaseResponse<bool>.Fail($"Ürün Bulunamadı. {request.Id}");

            product.IsActive = false;
            product.LastModifiedDate = DateTime.Now;

            await _productRepository.UpdateAsync(product);

            return BaseResponse<bool>.SuccessResponse(true, "Ürün pasif hale getirildi");
        }
    }
}
