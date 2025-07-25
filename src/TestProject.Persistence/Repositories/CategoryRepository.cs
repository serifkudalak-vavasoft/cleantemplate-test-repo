using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithAutoParts()
        {
            var allCategories = await _dbContext.Categories.Include(x => x.AutoParts).ToListAsync();
            return allCategories;
        }
    }
}
