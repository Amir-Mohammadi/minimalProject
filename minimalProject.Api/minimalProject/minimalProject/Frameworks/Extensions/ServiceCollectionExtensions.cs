using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using minimalProject.Core.Data;

namespace minimalProject.Frameworks.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddContext(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        }
    }
}
