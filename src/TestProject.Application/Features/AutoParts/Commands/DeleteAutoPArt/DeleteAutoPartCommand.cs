using MediatR;

namespace TestProject.Application.Features.AutoParts.Commands.DeleteAutoPArt
{
    public class DeleteAutoPartCommand : IRequest
    {
        public Guid AutoPartId { get; set; }
    }
}
