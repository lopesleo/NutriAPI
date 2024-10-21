﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NutrIA.Data;

#nullable disable

namespace NutrIA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241020035544_AddPacienteNutricionistaRelation")]
    partial class AddPacienteNutricionistaRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("NutrIA.Models.NutricionistaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Nutricionista");
                });

            modelBuilder.Entity("NutrIA.Models.PacienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Notas")
                        .HasColumnType("text");

                    b.Property<int?>("NutricionistaId")
                        .HasColumnType("integer");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision");

                    b.Property<string>("RestricoesAlimentares")
                        .HasColumnType("text");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NutricionistaId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("NutrIA.Models.PacienteModel", b =>
                {
                    b.HasOne("NutrIA.Models.NutricionistaModel", "Nutricionista")
                        .WithMany("Pacientes")
                        .HasForeignKey("NutricionistaId");

                    b.Navigation("Nutricionista");
                });

            modelBuilder.Entity("NutrIA.Models.NutricionistaModel", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
