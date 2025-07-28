using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Features.Products.Commands.CreateProduct;
using TestProject.Application.Features.Products.Commands.DeleteProduct;
using TestProject.Application.Features.Products.Commands.UpdateProduct;
using TestProject.Application.Features.Products.Queries.GetProductsList;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllProducts()
        {
            var response = await _mediator.Send(new GetProductsListQuery());
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await _mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<UpdateProductCommandResponse>> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            var response = await _mediator.Send(updateProductCommand);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteProductCommand = new DeleteProductCommand { Id = id };
            var response = await _mediator.Send(deleteProductCommand);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
