using MediatR;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartsList
{
    public class GetAutoPartsListQuery : IRequest<List<AutoPartListVm>>
    {
    }
}
