using AcoesInvest.Domain.Interfaces;
using AcoesInvest.Domain.Models;
using AcoesInvest.Infra.Data.EF.Maps;
using Microsoft.EntityFrameworkCore;

namespace AcoesInvest.Infra.Data.EF;

public class CadastroContext : DbContext, IUnitOfWork
{
    public CadastroContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroContext).Assembly);

        modelBuilder.Entity<Acoes>()
        .HasOne<Usuarios>() // Uma Ação tem um Usuário
        .WithMany()        // Um Usuário tem muitas Ações
        .HasForeignKey(x => x.UsuarioId)
        .OnDelete(DeleteBehavior.Cascade); // Se deletar o usuário, as ações dele somem

        base.OnModelCreating(modelBuilder);

    }
    public DbSet<Acoes> Acoes { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

}
