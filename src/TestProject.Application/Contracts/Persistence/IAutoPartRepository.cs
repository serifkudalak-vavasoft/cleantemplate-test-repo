using TestProject.Domain.Entities;

namespace TestProject.Application.Contracts.Persistence
{
    public interface IAutoPartRepository : IAsyncRepository<AutoPart>
    {
        Task<bool> IsAutoPartNameUnique(string name);
    }
}
