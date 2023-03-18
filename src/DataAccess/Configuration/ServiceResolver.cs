using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Configuration
{
    public static class ServiceResolver
    {
        public static void ResolveDataAccessServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddDbContext<ApplicationDbContext>(option => 
            option.UseSqlServer("ConnectionStrings:DefaultConnection"));
        }
    }
}
