using TestProject.Domain.Entities;
using TestProject.Persistence;
using System;

namespace TestProject.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(TestAppDbContext context)
        {
            context.SaveChanges();
        }
    }
}
