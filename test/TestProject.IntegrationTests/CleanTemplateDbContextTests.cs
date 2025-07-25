using TestProject.Application.Contracts;
using TestProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace TestProject.Persistence.IntegrationTests
{
    public class TestAppDbContextTests
    {
        private readonly TestAppDbContext _TestAppDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public TestAppDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TestAppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _TestAppDbContext = new TestAppDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new AutoPart() {AutoPartId = Guid.NewGuid(), Name = "Test AutoPart" };

            _TestAppDbContext.AutoPart.Add(ev);
            await _TestAppDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
