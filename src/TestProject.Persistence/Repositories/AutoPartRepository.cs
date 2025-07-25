using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;

namespace TestProject.Persistence.Repositories
{
    public class AutoPartRepository : BaseRepository<AutoPart>, IAutoPartRepository
    {
        public AutoPartRepository(TestAppDbContext dbContext) : base(dbContext)
        {
        }
        
        public Task<bool> IsAutoPartNameUnique(string name)
        {
            var matches = _dbContext.AutoPart.Any(e => e.Name.Equals(name));
            return Task.FromResult(matches);
        }

    }
}
