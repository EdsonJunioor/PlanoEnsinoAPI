﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanoEnsinoAPI.Data;

namespace PlanoEnsinoAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Autor", b =>
                {
                    b.Property<int>("CdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdAutor");

                    b.ToTable("Autor");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Avaliacao", b =>
                {
                    b.Property<int>("CdAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CdDisciplina")
                        .HasColumnType("int");

                    b.Property<string>("DsAluno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsAvaliacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsConsulta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsConteudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsObservacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CdAvaliacao");

                    b.HasIndex("CdDisciplina")
                        .IsUnique();

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Curso", b =>
                {
                    b.Property<int>("CdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DsCurso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TpGraduacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Livro", b =>
                {
                    b.Property<int>("CdLivro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("DsLivro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Editora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdLivro");

                    b.ToTable("Livro");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.PlanoEnsino", b =>
                {
                    b.Property<int>("CdDisciplina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoSemestre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsBiblioBasica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsBiblioComplementar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsDisciplina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsEmenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsMTDGeral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsObjetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsObservecao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAtualização")
                        .HasColumnType("datetime2");

                    b.Property<int>("NrCreditos")
                        .HasColumnType("int");

                    b.Property<int>("NrHorasPP")
                        .HasColumnType("int");

                    b.Property<int>("NrHorasSala")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdDisciplina");

                    b.ToTable("PlanoEnsino");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.SugestaoPlanoEnsino", b =>
                {
                    b.Property<int>("CdSugestaoPlanoEnsino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoSemestre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CdDisciplina")
                        .HasColumnType("int");

                    b.Property<string>("DsBiblioBasica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsBiblioComplementar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsDisciplina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsEmenta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsMTDGeral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsObjetivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsObservecao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsPlanoEnsino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DsSemana9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAtualização")
                        .HasColumnType("datetime2");

                    b.Property<int>("NrCreditos")
                        .HasColumnType("int");

                    b.Property<int>("NrHorasPP")
                        .HasColumnType("int");

                    b.Property<int>("NrHorasSala")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdSugestaoPlanoEnsino");

                    b.HasIndex("CdDisciplina")
                        .IsUnique();

                    b.ToTable("SugestaoPlanoEnsino");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Usuario", b =>
                {
                    b.Property<int>("CdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TpUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.Avaliacao", b =>
                {
                    b.HasOne("PlanoEnsinoAPI.Models.PlanoEnsino", "PlanoEnsino")
                        .WithOne("Avaliacao")
                        .HasForeignKey("PlanoEnsinoAPI.Models.Avaliacao", "CdDisciplina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlanoEnsinoAPI.Models.SugestaoPlanoEnsino", b =>
                {
                    b.HasOne("PlanoEnsinoAPI.Models.PlanoEnsino", "PlanoEnsino")
                        .WithOne("SugestaoPlanoEnsino")
                        .HasForeignKey("PlanoEnsinoAPI.Models.SugestaoPlanoEnsino", "CdDisciplina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
