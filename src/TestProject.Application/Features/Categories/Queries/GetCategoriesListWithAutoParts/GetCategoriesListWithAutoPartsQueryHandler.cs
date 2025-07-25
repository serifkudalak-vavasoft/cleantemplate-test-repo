using AutoMapper;
using TestProject.Application.Contracts.Persistence;
using MediatR;

namespace TestProject.Application.Features.Categories.Queries.GetCategoriesListWithAutoParts
{
    public class GetCategoriesListWithAutoPartsQueryHandler : IRequestHandler<GetCategoriesListWithAutoPartsQuery, List<CategoryAutoPartListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithAutoPartsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryAutoPartListVm>> Handle(GetCategoriesListWithAutoPartsQuery request, CancellationToken cancellationToken)
        {
            var list = await _categoryRepository.GetCategoriesWithAutoParts();
            return _mapper.Map<List<CategoryAutoPartListVm>>(list);
        }
    }
}
