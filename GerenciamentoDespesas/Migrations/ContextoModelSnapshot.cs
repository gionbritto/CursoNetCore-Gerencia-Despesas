﻿// <auto-generated />
using System;
using GerenciamentoDespesas.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciamentoDespesas.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciamentoDespesas.Models.Despesa", b =>
                {
                    b.Property<Guid>("DespesaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MesId");

                    b.Property<Guid>("TipoDespesaId");

                    b.Property<double>("Valor");

                    b.HasKey("DespesaId");

                    b.HasIndex("MesId");

                    b.HasIndex("TipoDespesaId");

                    b.ToTable("TDespesa");
                });

            modelBuilder.Entity("GerenciamentoDespesas.Models.Mes", b =>
                {
                    b.Property<Guid>("MesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Ordem");

                    b.HasKey("MesId");

                    b.ToTable("TMes");
                });

            modelBuilder.Entity("GerenciamentoDespesas.Models.Salario", b =>
                {
                    b.Property<Guid>("SalarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("MesId");

                    b.Property<double>("Valor");

                    b.HasKey("SalarioId");

                    b.HasIndex("MesId")
                        .IsUnique();

                    b.ToTable("TSalario");
                });

            modelBuilder.Entity("GerenciamentoDespesas.Models.TipoDespesa", b =>
                {
                    b.Property<Guid>("TipoDespesaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TipoDespesaId");

                    b.ToTable("TTipoDespesa");
                });

            modelBuilder.Entity("GerenciamentoDespesas.Models.Despesa", b =>
                {
                    b.HasOne("GerenciamentoDespesas.Models.Mes", "Mes")
                        .WithMany("Despesas")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GerenciamentoDespesas.Models.TipoDespesa", "TipoDespesa")
                        .WithMany("Despesas")
                        .HasForeignKey("TipoDespesaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GerenciamentoDespesas.Models.Salario", b =>
                {
                    b.HasOne("GerenciamentoDespesas.Models.Mes", "Mes")
                        .WithOne("Salario")
                        .HasForeignKey("GerenciamentoDespesas.Models.Salario", "MesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}