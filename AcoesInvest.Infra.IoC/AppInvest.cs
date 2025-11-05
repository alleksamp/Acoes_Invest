using AcoesInvest.Application.Mapper;
using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AcoesInvest.Infra.IoC;

public static class AppInvest
{
    private static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new DomainToViewModelProfile());
        });

        services.AddSingleton(mapperConfig.CreateMapper());
    }

    public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
    {
        services.ConfigureMapper();
        return services;
    }

    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAcoesRepository, AcoesRepository>();
        services.AddScoped<IAcoesService, AcoesService>();
        services.AddScoped<IAcoesAppService, AcoesAppService>();

        return services;
    }

}
