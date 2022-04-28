﻿// <auto-generated />
using System;
using Challenge.API.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Challenge.API.Migrations
{
    [DbContext(typeof(ChallengeDbContext))]
    [Migration("20220428003545_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Challenge.Domain.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero");
                });

            modelBuilder.Entity("Challenge.Domain.Models.GeneroPeliculaSerie", b =>
                {
                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaSerieId")
                        .HasColumnType("int");

                    b.HasKey("GeneroId", "PeliculaSerieId");

                    b.HasIndex("PeliculaSerieId");

                    b.ToTable("GeneroPeliculaSerie");
                });

            modelBuilder.Entity("Challenge.Domain.Models.PeliculaSerie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Calificacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PeliculaSerie");
                });

            modelBuilder.Entity("Challenge.Domain.Models.PeliculaSeriePersonaje", b =>
                {
                    b.Property<int>("PeliculaSerieId")
                        .HasColumnType("int");

                    b.Property<int>("PersonajeId")
                        .HasColumnType("int");

                    b.HasKey("PeliculaSerieId", "PersonajeId");

                    b.HasIndex("PersonajeId");

                    b.ToTable("PeliculaSeriePersonaje");
                });

            modelBuilder.Entity("Challenge.Domain.Models.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Personaje");
                });

            modelBuilder.Entity("Challenge.Domain.Models.GeneroPeliculaSerie", b =>
                {
                    b.HasOne("Challenge.Domain.Models.Genero", "Genero")
                        .WithMany("GenerosPelicuslaSeries")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge.Domain.Models.PeliculaSerie", "PeliculaSerie")
                        .WithMany("GenerosPeliculasSeries")
                        .HasForeignKey("PeliculaSerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("PeliculaSerie");
                });

            modelBuilder.Entity("Challenge.Domain.Models.PeliculaSeriePersonaje", b =>
                {
                    b.HasOne("Challenge.Domain.Models.PeliculaSerie", "PeliculaSerie")
                        .WithMany("PeliculasSeriesPersonajes")
                        .HasForeignKey("PeliculaSerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Challenge.Domain.Models.Personaje", "Personaje")
                        .WithMany("PeliculasSeriesPersonajes")
                        .HasForeignKey("PersonajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeliculaSerie");

                    b.Navigation("Personaje");
                });

            modelBuilder.Entity("Challenge.Domain.Models.Genero", b =>
                {
                    b.Navigation("GenerosPelicuslaSeries");
                });

            modelBuilder.Entity("Challenge.Domain.Models.PeliculaSerie", b =>
                {
                    b.Navigation("GenerosPeliculasSeries");

                    b.Navigation("PeliculasSeriesPersonajes");
                });

            modelBuilder.Entity("Challenge.Domain.Models.Personaje", b =>
                {
                    b.Navigation("PeliculasSeriesPersonajes");
                });
#pragma warning restore 612, 618
        }
    }
}
