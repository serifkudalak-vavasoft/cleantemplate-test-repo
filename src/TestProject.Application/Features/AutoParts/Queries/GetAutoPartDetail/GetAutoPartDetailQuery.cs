using MediatR;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartDetail
{
    public class GetAutoPartDetailQuery : IRequest<AutoPartDetailVm>
    {
        public Guid Id { get; set; }
    }
}
