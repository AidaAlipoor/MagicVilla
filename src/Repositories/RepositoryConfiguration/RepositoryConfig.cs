using Business.Repositories.VillaNumberRepository;
using Business.Repositories.VillaRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Business.RepositoryConfiguration
{
    public static class RepositoryConfig
    {
        public static void AddRepositoriesToContainer(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IVillaRepository, VillaRepository>();
            serviceDescriptors.AddScoped<IVillaNumberRepository, VillaNumberRepository>();
        }
    }
}
