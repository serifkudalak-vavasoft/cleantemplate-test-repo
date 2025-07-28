using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Features.Categories.Commands.CreateCategory;
using TestProject.Application.Features.Categories.Commands.DeleteCategory;
using TestProject.Application.Features.Categories.Commands.UpdateCategory;
using TestProject.Application.Features.Categories.Queries.GetCategoriesList;

namespace TestProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var response = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(response);
        }

        [HttpPost("AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult<UpdateCategoryCommandResponse>> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await _mediator.Send(updateCategoryCommand);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand { Id = id };
            var response = await _mediator.Send(deleteCategoryCommand);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
