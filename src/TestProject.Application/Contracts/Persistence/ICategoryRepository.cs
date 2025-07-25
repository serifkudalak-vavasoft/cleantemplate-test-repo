using TestProject.Domain.Entities;

namespace TestProject.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithAutoParts();
    }
}
