using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;

namespace TestProject.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProductCommandResponse = new UpdateProductCommandResponse();

            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                updateProductCommandResponse.Success = false;
                updateProductCommandResponse.Message = $"Ürün Bulunamadı. Id: {request.Id}";
                return updateProductCommandResponse;
            }
            else
            {
                var validatorResponse = await new UpdateProductCommandValidator().ValidateAsync(request);

                if (validatorResponse.Errors.Count > 0)
                {
                    updateProductCommandResponse.Success = false;
                    updateProductCommandResponse.ValidationErrors = new List<string>();

                    foreach (var error in validatorResponse.Errors)
                    {
                        updateProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                    }
                }

                if (updateProductCommandResponse.Success)
                {
                    product.LastModifiedDate = DateTime.Now;
                    _mapper.Map(request, product);

                    await _productRepository.UpdateAsync(product);
                    updateProductCommandResponse.Product = _mapper.Map<UpdateProductDto>(product);
                }

                return updateProductCommandResponse;
            }
        }
    }
}
