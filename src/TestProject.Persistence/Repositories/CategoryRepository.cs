using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Application.Contracts.Persistence;
using TestProject.Domain.Entities;

namespace TestProject.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TestAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
