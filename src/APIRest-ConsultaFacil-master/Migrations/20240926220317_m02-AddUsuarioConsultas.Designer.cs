﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apirest.Data;

#nullable disable

namespace apirest.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20240926220317_m02-AddUsuarioConsultas")]
    partial class m02AddUsuarioConsultas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("apirest.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataConsulta")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("HoraConsulta")
                        .IsRequired()
                        .HasColumnType("interval");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("apirest.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Sexo")
                        .HasColumnType("integer");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "12345678910",
                            Email = "admin@email.com.br",
                            Nome = "Administrador",
                            Perfil = 0,
                            Senha = "$2a$11$R6H73LeyMvKlGa8mdE7eCeRw7vaUKUzj4ihcjh6h8181/ufq/gsra",
                            Sexo = 1,
                            Telefone = "31990000000"
                        },
                        new
                        {
                            Id = 2,
                            CPF = "12345678911",
                            Email = "medico@email.com.br",
                            Nome = "Medico",
                            Perfil = 1,
                            Senha = "$2a$11$IJbJJeMeBg4GlizVAFY1nun7IYTGF6el5yV1/7JNvTNB.4Ng4PWQ2",
                            Sexo = 1,
                            Telefone = "31990000001"
                        },
                        new
                        {
                            Id = 3,
                            CPF = "12345678912",
                            Email = "paciente@email.com.br",
                            Nome = "Paciente",
                            Perfil = 2,
                            Senha = "$2a$11$LOiYLYjrtOag6894qxEIo.fUC2T.rodGCrtSB5z1RUQ3aM9dTwfr.",
                            Telefone = "31990000002"
                        });
                });

            modelBuilder.Entity("apirest.Models.Consulta", b =>
                {
                    b.HasOne("apirest.Models.Usuario", "Usuario")
                        .WithMany("Consultas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("apirest.Models.Usuario", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
