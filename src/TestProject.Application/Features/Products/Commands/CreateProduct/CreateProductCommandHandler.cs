using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;

namespace TestProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IAsyncRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createProductCommandResponse = new CreateProductCommandResponse();
            var validatorResponse = await new CreateProductCommandValidator().ValidateAsync(request);

            if (validatorResponse.Errors.Count > 0)
            {
                createProductCommandResponse.Success = false;
                createProductCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validatorResponse.Errors)
                {
                    createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createProductCommandResponse.Success)
            {
                var product = await _productRepository.AddAsync(new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    CategoryId = request.CategoryId
                });

                createProductCommandResponse.Data = _mapper.Map<CreateProductDto>(product);
            }

            return createProductCommandResponse;
        }
    }
}
