using GerenciamentoDespesas.Mapping;
using GerenciamentoDespesas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDespesas.Infra
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> op) : base(op)
        {
        }

        public DbSet<Mes> TMes { get; set; }
        public DbSet<Salario> TSalario { get; set; }
        public DbSet<Despesa> TDespesa { get; set; }
        public DbSet<TipoDespesa> TTipoDespesa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoDespesaMap());
            modelBuilder.ApplyConfiguration(new DespesaMap());
            modelBuilder.ApplyConfiguration(new MesMap());
            modelBuilder.ApplyConfiguration(new SalarioMap());
        }
       
    }
}
