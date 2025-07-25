using TestProject.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
    //        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddCookie()
    //.AddBearerToken(IdentityConstants.BearerScheme);


            services.AddAuthorizationBuilder();

            services.AddDbContext<TestAppIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TestAppIdentityConnectionString")));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<TestAppIdentityDbContext>()
                .AddApiEndpoints();
        }
    }
}
