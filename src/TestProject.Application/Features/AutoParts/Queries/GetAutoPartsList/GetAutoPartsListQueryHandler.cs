using AutoMapper;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;
using MediatR;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartsList
{
    public class GetAutoPartsListQueryHandler : IRequestHandler<GetAutoPartsListQuery, List<AutoPartListVm>>
    {
        private readonly IAsyncRepository<AutoPart> _autoPartRepository;
        private readonly IMapper _mapper;

        public GetAutoPartsListQueryHandler(IMapper mapper, IAsyncRepository<AutoPart> autopartRepository)
        {
            _mapper = mapper;
            _autoPartRepository = autopartRepository;
        }

        public async Task<List<AutoPartListVm>> Handle(GetAutoPartsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _autoPartRepository.ListAllAsync();
            return _mapper.Map<List<AutoPartListVm>>(allEvents);
        }
    }
}
