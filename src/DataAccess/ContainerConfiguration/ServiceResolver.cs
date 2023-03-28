using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.ContainerConfiguration
{
    public static class ServiceResolver
    {
        public static void ResolveDataAccessServices(this IServiceCollection serviceDescriptors, string connectionString)
        {
            serviceDescriptors.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
