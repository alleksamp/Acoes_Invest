using AcoesInvest.Application.Mapper;
using AcoesInvest.Application.Services;
using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Services;
using AcoesInvest.Infra.Data.EF;
using AcoesInvest.Infra.Data.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

    public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureMapper();
        services.ConfigureApplicationServices();
        services.ConfigureInfraData(configuration);

        return services;
    }

    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAcoesAppService, AcoesAppService>();
        services.AddScoped<IAcoesService, AcoesService>();

        services.AddScoped<IUsuariosAppService, UsuariosAppService>();
        services.AddScoped<IUsuariosService, UsuariosService>();

        return services;
    }

    public static IServiceCollection ConfigureInfraData(this IServiceCollection services, IConfiguration configuration)
    {
        // Obtém a string de conexão do appsettings.json. 
        // OBS: O nome 'connection' deve ser o mesmo do seu appsettings.json
        var connectionString = configuration.GetConnectionString("connection");

        // REGISTRO 1: Adiciona o DbContext
        services.AddDbContext<CadastroContext>(options =>
            options.UseSqlServer(connectionString) // ⬅️ Usando SQL Server (baseado na sua connection string)
        );

        // REGISTRO 2: Adiciona o Repositório, que depende do DbContext
        // Removemos o registro do repositório do ConfigureApplicationServices
        services.AddScoped<IAcoesRepository, AcoesRepository>();
        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        return services;
    }


}
