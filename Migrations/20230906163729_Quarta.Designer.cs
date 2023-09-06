﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteAPI.Repository;

#nullable disable

namespace RestauranteAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230906163729_Quarta")]
    partial class Quarta
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MealMenu", b =>
                {
                    b.Property<int>("CardapiosId")
                        .HasColumnType("int");

                    b.Property<int>("RefeicoesId")
                        .HasColumnType("int");

                    b.HasKey("CardapiosId", "RefeicoesId");

                    b.HasIndex("RefeicoesId");

                    b.ToTable("MealMenu");
                });

            modelBuilder.Entity("MealOrder", b =>
                {
                    b.Property<int>("PedidosId")
                        .HasColumnType("int");

                    b.Property<int>("RefeicaoId")
                        .HasColumnType("int");

                    b.HasKey("PedidosId", "RefeicaoId");

                    b.HasIndex("RefeicaoId");

                    b.ToTable("MealOrder");
                });

            modelBuilder.Entity("RestauranteAPI.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("RestauranteAPI.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCardapio")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("RestauranteAPI.Models.MenuMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("cardapioId")
                        .HasColumnType("int");

                    b.Property<int>("refeicaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MenuMeal");
                });

            modelBuilder.Entity("RestauranteAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("PrecoTotal")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RestauranteAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MealMenu", b =>
                {
                    b.HasOne("RestauranteAPI.Models.Menu", null)
                        .WithMany()
                        .HasForeignKey("CardapiosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteAPI.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("RefeicoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MealOrder", b =>
                {
                    b.HasOne("RestauranteAPI.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteAPI.Models.Meal", null)
                        .WithMany()
                        .HasForeignKey("RefeicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestauranteAPI.Models.Order", b =>
                {
                    b.HasOne("RestauranteAPI.Models.User", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("RestauranteAPI.Models.User", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
