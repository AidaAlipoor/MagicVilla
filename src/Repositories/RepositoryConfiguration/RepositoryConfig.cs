using Business.Repositories.VillaRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.RepositoryConfiguration
{
    public static class RepositoryConfig
    {
        public static void AddVillaRepositoryToContainer(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IVillaRepository, VillaRepository>();
        }
    }
}
