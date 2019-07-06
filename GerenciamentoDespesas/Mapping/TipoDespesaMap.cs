using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Mapping
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder)
        {
            builder.ToTable("TTipoDespesa");
            builder.HasKey(x => x.TipoDespesaId);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Despesas).WithOne(x => x.TipoDespesa).HasForeignKey(x => x.TipoDespesaId);
        }
    }
}
