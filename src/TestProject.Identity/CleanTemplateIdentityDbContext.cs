using TestProject.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Identity
{
    public class TestAppIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TestAppIdentityDbContext()
        {

        }

        public TestAppIdentityDbContext(DbContextOptions<TestAppIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    }
}
