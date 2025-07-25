using TestProject.Api.Utility;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartDetail;
using TestProject.Application.Features.AutoParts.Commands.CreateAutoPart;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartsList;
using TestProject.Application.Features.AutoParts.Commands.UpdateAutoPart;
using TestProject.Application.Features.AutoParts.Commands.DeleteAutoPArt;
using TestProject.Application.Features.AutoParts.Queries.GetAutoPartssExport;

namespace TestProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoPartsController : Controller
    {
        private readonly IMediator _mediator;

        public AutoPartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAutoParts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AutoPartListVm>>> GetAllAutoParts()
        {
            var result = await _mediator.Send(new GetAutoPartsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetAutoPartById")]
        public async Task<ActionResult<AutoPartDetailVm>> GetAutoPartById(Guid id)
        {
            var getAutoPartDetailQuery = new GetAutoPartDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getAutoPartDetailQuery));
        }

        [HttpPost(Name = "AddAutoPart")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAutoPartCommand createAutoPartCommand)
        {
            var id = await _mediator.Send(createAutoPartCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateAutoPart")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAutoPartCommand updateAutoPartCommand)
        {
            await _mediator.Send(updateAutoPartCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAutoPart")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAutoPartCommand = new DeleteAutoPartCommand() { AutoPartId = id };
            await _mediator.Send(deleteAutoPartCommand);
            return NoContent();
        }

        [HttpGet("export", Name = "ExportAutoParts")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportAutoParts()
        {
            var fileDto = await _mediator.Send(new GetAutoPartExportQuery());

            return File(fileDto.Data, fileDto.ContentType, fileDto.AutoPartExportFileName);
        }
    }
}
