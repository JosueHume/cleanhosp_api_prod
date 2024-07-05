﻿// <auto-generated />
using System;
using CleanHosp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cleanhosp_api_prod.Migrations
{
    [DbContext(typeof(CleanHospContext))]
    partial class CleanHospContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanHospAPI.Models.Ala", b =>
                {
                    b.Property<int>("AlaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("AlaId");

                    b.ToTable("Alas");
                });

            modelBuilder.Entity("CleanHospAPI.Models.Equipamento", b =>
                {
                    b.Property<int>("EquipamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EquipamentoId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("DataAquisicao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("ValorAquisicao")
                        .HasColumnType("numeric");

                    b.HasKey("EquipamentoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("CleanHospAPI.Models.EquipamentosUtilizados", b =>
                {
                    b.Property<int>("EquipamentosUtilizadosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EquipamentosUtilizadosId"));

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("LimpezaAndamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("LimpezaAndamentoId1")
                        .HasColumnType("integer");

                    b.Property<int>("LimpezaAndamentoId2")
                        .HasColumnType("integer");

                    b.Property<int>("TempoUsoEmMinutos")
                        .HasColumnType("integer");

                    b.HasKey("EquipamentosUtilizadosId");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("LimpezaAndamentoId");

                    b.HasIndex("LimpezaAndamentoId1");

                    b.ToTable("EquipamentosUtilizados");
                });

            modelBuilder.Entity("CleanHospAPI.Models.Limpeza", b =>
                {
                    b.Property<int>("LimpezaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LimpezaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("LimpezaId");

                    b.ToTable("Limpezas");
                });

            modelBuilder.Entity("CleanHospAPI.Models.LimpezaAndamento", b =>
                {
                    b.Property<int>("LimpezaAndamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LimpezaAndamentoId"));

                    b.Property<int>("AlaId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("boolean");

                    b.Property<int>("LimpezaId")
                        .HasColumnType("integer");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.HasKey("LimpezaAndamentoId");

                    b.HasIndex("AlaId");

                    b.HasIndex("LimpezaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("LimpezasAndamento");
                });

            modelBuilder.Entity("CleanHospAPI.Models.Local", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocalId"));

                    b.Property<int>("AlaId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("LocalId");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("CleanHospAPI.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PessoaId"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("CleanHospAPI.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("QtdeEstoque")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("numeric");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CleanHospAPI.Models.ProdutosUtilizados", b =>
                {
                    b.Property<int>("ProdutosUtilizadosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProdutosUtilizadosId"));

                    b.Property<int>("LimpezaAndamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("LimpezaAndamentoId1")
                        .HasColumnType("integer");

                    b.Property<int>("LimpezaAndamentoId2")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("ProdutosUtilizadosId");

                    b.HasIndex("LimpezaAndamentoId");

                    b.HasIndex("LimpezaAndamentoId1");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosUtilizados");
                });

            modelBuilder.Entity("CleanHospAPI.Models.EquipamentosUtilizados", b =>
                {
                    b.HasOne("CleanHospAPI.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.LimpezaAndamento", null)
                        .WithMany("EquipamentosUtilizados")
                        .HasForeignKey("LimpezaAndamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.LimpezaAndamento", "LimpezaAndamento")
                        .WithMany()
                        .HasForeignKey("LimpezaAndamentoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");

                    b.Navigation("LimpezaAndamento");
                });

            modelBuilder.Entity("CleanHospAPI.Models.LimpezaAndamento", b =>
                {
                    b.HasOne("CleanHospAPI.Models.Ala", "Ala")
                        .WithMany()
                        .HasForeignKey("AlaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.Limpeza", "Limpeza")
                        .WithMany()
                        .HasForeignKey("LimpezaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ala");

                    b.Navigation("Limpeza");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CleanHospAPI.Models.ProdutosUtilizados", b =>
                {
                    b.HasOne("CleanHospAPI.Models.LimpezaAndamento", null)
                        .WithMany("ProdutosUtilizados")
                        .HasForeignKey("LimpezaAndamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.LimpezaAndamento", "LimpezaAndamento")
                        .WithMany()
                        .HasForeignKey("LimpezaAndamentoId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanHospAPI.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LimpezaAndamento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CleanHospAPI.Models.LimpezaAndamento", b =>
                {
                    b.Navigation("EquipamentosUtilizados");

                    b.Navigation("ProdutosUtilizados");
                });
#pragma warning restore 612, 618
        }
    }
}
