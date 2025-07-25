using AutoMapper;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;
using MediatR;

namespace TestProject.Application.Features.AutoParts.Queries.GetAutoPartDetail
{
    public class GetAutoPartDetailQueryHandler : IRequestHandler<GetAutoPartDetailQuery, AutoPartDetailVm>
    {
        private readonly IAsyncRepository<AutoPart> _autopartRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetAutoPartDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<AutoPart> autopartRepository,
            IAsyncRepository<Category> categoryRepository)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<AutoPartDetailVm> Handle(GetAutoPartDetailQuery request, CancellationToken cancellationToken)
        {
            var autoPart = await _autopartRepository.GetByIdAsync(request.Id);
            var autoPartDetailDto = _mapper.Map<AutoPartDetailVm>(autoPart);

            var category = await _categoryRepository.GetByIdAsync(autoPart.CategoryId);

            autoPartDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return autoPartDetailDto;
        }
    }
}
