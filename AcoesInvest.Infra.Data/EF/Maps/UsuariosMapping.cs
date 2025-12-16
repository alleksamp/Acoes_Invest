using AcoesInvest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoesInvest.Infra.Data.EF.Maps;

public class UsuariosMapping : IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
         .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Senha)
            .HasMaxLength(255)
            .IsRequired();


    }
}
