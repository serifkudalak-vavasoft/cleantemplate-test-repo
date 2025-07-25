using TestProject.Application.Contracts;
using TestProject.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TestProject.Domain.Entities;
namespace TestProject.Persistence
{
    public class TestAppDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
           : base(options)
        {
        }

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<AutoPart> AutoPart { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestAppDbContext).Assembly);

            // Seed data
            var enginePartsGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var bodyPartsGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var electricalGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = enginePartsGuid,
                Name = "Engine Parts",
                CreatedDate = DateTime.UtcNow
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = bodyPartsGuid,
                Name = "Body Parts",
                CreatedDate = DateTime.UtcNow
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = electricalGuid,
                Name = "Electrical Components",
                CreatedDate = DateTime.UtcNow
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}"),
                Name = "Piston",
                Price = 500,
                Description = "High-performance piston",
                CategoryId = enginePartsGuid,
                ImageUrl = ""
                
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}"),
                Name = "Crankshaft",
                Price = 1200,
                Description = "Durable crankshaft",
                CategoryId = enginePartsGuid,
                ImageUrl = ""
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}"),
                Name = "Door Handle",
                Price = 100,
                Description = "Stylish door handle",
                CategoryId = bodyPartsGuid,
                ImageUrl = ""
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}"),
                Name = "Front Bumper",
                Price = 800,
                Description = "Impact-resistant bumper",
                CategoryId = bodyPartsGuid,
                ImageUrl = ""
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                Name = "Headlight",
                Price = 200,
                Description = "Bright LED headlight",
                CategoryId = electricalGuid,
                ImageUrl = ""
            });

            modelBuilder.Entity<AutoPart>().HasData(new AutoPart
            {
                AutoPartId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}"),
                Name = "Alternator",
                Price = 400,
                Description = "High-efficiency alternator",
                CategoryId = electricalGuid,
                ImageUrl = ""
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
