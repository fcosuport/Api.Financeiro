﻿// <auto-generated />
using System;
using Api.Financeiro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Financeiro.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.Financeiro.Models.Assinatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cancelado")
                        .HasColumnType("Boolean");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<string>("CodAssinatura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("DiaVencimento")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DtPrimeiraParcela")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Dtcadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Dtcancelamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("integer");

                    b.Property<string>("NomeWhats")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PlanoId")
                        .HasColumnType("integer");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FormaPagamentoId");

                    b.HasIndex("PlanoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Assinaturas");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj_Cpf")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Dtalteracao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Dtcadastro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Fantasia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Inativo")
                        .HasColumnType("Boolean");

                    b.Property<string>("Obs")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Razao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Api.Financeiro.Models.FormaPagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Formapagamentos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Plano", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodProdGn")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Titulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cancelado")
                        .HasColumnType("Boolean");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DtPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Emissao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FormaPagamentoId")
                        .HasColumnType("integer");

                    b.Property<int>("NumParcela")
                        .HasColumnType("integer");

                    b.Property<int>("QtdeParcelas")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric(10,2)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FormaPagamentoId");

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Assinatura", b =>
                {
                    b.HasOne("Api.Financeiro.Models.Cliente", "Cliente")
                        .WithMany("Assinaturas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Financeiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("Assinaturas")
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Financeiro.Models.Plano", "Plano")
                        .WithMany("Assinaturas")
                        .HasForeignKey("PlanoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Financeiro.Models.Produto", "Produto")
                        .WithMany("Assinaturas")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("FormaPagamento");

                    b.Navigation("Plano");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Titulo", b =>
                {
                    b.HasOne("Api.Financeiro.Models.Cliente", "Cliente")
                        .WithMany("Titulos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Financeiro.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("Titulos")
                        .HasForeignKey("FormaPagamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("FormaPagamento");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Cliente", b =>
                {
                    b.Navigation("Assinaturas");

                    b.Navigation("Titulos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.FormaPagamento", b =>
                {
                    b.Navigation("Assinaturas");

                    b.Navigation("Titulos");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Plano", b =>
                {
                    b.Navigation("Assinaturas");
                });

            modelBuilder.Entity("Api.Financeiro.Models.Produto", b =>
                {
                    b.Navigation("Assinaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
