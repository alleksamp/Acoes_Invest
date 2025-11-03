using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AcoesInvest.Infra.Data.EF.Extensions;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection AddEFConfiguration (this IServiceCollection services,
        string connectionString)
    {
        services.AddEntityFrameworkSqlServer()
            .AddDbContext<CadastroContext>(options =>
            {
                options.UseSqlServer(connectionString);
            },
            ServiceLifetime.Scoped);

        return services;
    }
}
