using System;

namespace TestProject.Application.Features.Categories.Queries.GetCategoriesListWithAutoParts
{
    public class CategoryAutoPartDto
    {
        public Guid AutoPartId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
