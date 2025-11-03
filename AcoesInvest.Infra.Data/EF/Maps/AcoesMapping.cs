using AcoesInvest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoesInvest.Infra.Data.EF.Maps;

public class AcoesMapping : IEntityTypeConfiguration<Acoes>
{
    public void Configure(EntityTypeBuilder<Acoes> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Quantidade)
         .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Pm)
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.PmIr)
            .HasMaxLength(8)
            .IsRequired();

        builder.Property(x => x.Dividendos)
             .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.TotalInv)
           .HasMaxLength(50)
           .IsRequired();

    }

}
