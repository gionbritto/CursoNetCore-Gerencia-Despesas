using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Mapping
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.ToTable("TMes");
            builder.HasKey(x => x.MesId);
            builder.Property(x => x.MesId); //testar porque
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Despesas).WithOne(x => x.Mes).HasForeignKey(x => x.MesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Salario).WithOne(x => x.Mes).OnDelete(DeleteBehavior.Cascade); ; //No caso de 1..1 é necessario colocar onde vai ficar a fk
        }
    }
}
