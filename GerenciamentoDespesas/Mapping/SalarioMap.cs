using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Mapping
{
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.ToTable("TSalario");
            builder.HasKey(x => x.SalarioId);
            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.Mes).WithOne(s => s.Salario).HasForeignKey<Salario>(x => x.MesId);
        }
    }
}
