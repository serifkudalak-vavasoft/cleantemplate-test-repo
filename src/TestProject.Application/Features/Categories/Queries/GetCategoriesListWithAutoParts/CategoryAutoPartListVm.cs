using System;
using System.Collections.Generic;

namespace TestProject.Application.Features.Categories.Queries.GetCategoriesListWithAutoParts
{
    public class CategoryAutoPartListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryAutoPartDto> AutoParts { get; set; }
    }
}
