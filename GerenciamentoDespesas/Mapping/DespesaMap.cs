using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Mapping
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("TDespesa");
            builder.HasKey(x => x.DespesaId);
            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.Mes).WithMany(x => x.Despesas).HasForeignKey(x => x.MesId);
            builder.HasOne(x => x.TipoDespesa).WithMany(x => x.Despesas).HasForeignKey(x => x.TipoDespesaId);
        }
    }
}
