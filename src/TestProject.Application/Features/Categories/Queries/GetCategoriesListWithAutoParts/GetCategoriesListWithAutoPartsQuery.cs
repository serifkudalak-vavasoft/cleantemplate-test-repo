using MediatR;
using System.Collections.Generic;

namespace TestProject.Application.Features.Categories.Queries.GetCategoriesListWithAutoParts
{
    public class GetCategoriesListWithAutoPartsQuery : IRequest<List<CategoryAutoPartListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
