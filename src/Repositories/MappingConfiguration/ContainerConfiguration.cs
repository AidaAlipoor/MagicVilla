using Microsoft.Extensions.DependencyInjection;

namespace Business.MappingConfiguration
{
    public static class ContainerConfiguration
    {
        public static void AddAutoMapperToContainer(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}
