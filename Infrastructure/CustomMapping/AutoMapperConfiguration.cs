using AutoMapper; 
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Kharaei.Infra;

public static class AutoMapperConfiguration
{
    public static void InitializeAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddCustomMappingProfile();
        });
  
        //Compile mapping after configuration to boost map speed
        //Mapper.Configuration.CompileMappings();
    }

    public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
    {
        config.AddCustomMappingProfile(Assembly.GetEntryAssembly());
    }

    public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
    {
        var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

        var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
            type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
            .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

        var profile = new CustomMappingProfile(list);

        config.AddProfile(profile);
    }
}