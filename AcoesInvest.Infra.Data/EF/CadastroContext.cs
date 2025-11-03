using AcoesInvest.Domain.Interfaces;
using AcoesInvest.Domain.Models;
using AcoesInvest.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AcoesInvest.Infra.Data.EF;

public class CadastroContext : DbContext, IUnitOfWork
{
    public CadastroContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
        CriarBancoCasoNaoExista();
    }

    private void CriarBancoCasoNaoExista()
    {
        if (!(Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AcoesMapping());

    }
    public DbSet<Acoes> Acoes { get; set; }

}
