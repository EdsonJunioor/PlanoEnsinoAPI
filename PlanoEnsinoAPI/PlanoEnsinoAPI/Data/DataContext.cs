using Microsoft.EntityFrameworkCore;
using PlanoEnsinoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<PlanoEnsino> PlanoEnsino { get; set; }
        public DbSet<SugestaoPlanoEnsino> SugestaoPlanoEnsino { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Autor>()
              .HasKey(a => a.CdAutor);

            builder.Entity<Autor>()
                .Property(a => a.CdAutor).ValueGeneratedOnAdd();

            builder.Entity<Avaliacao>()
              .HasKey(a => a.CdAvaliacao);

            builder.Entity<Avaliacao>()
                .Property(a => a.CdAvaliacao).ValueGeneratedOnAdd();

            builder.Entity<Avaliacao>()
                .Property(a => a.Peso).HasColumnType("decimal(18,2)");

            builder.Entity<Curso>()
             .HasKey(c => c.CdCurso);

            builder.Entity<Curso>()
                .Property(c => c.CdCurso).ValueGeneratedOnAdd();

            builder.Entity<Livro>()
             .HasKey(l => l.CdLivro);

            builder.Entity<Livro>()
                .Property(l => l.CdLivro).ValueGeneratedOnAdd();

            builder.Entity<PlanoEnsino>()
            .HasKey(p => p.CdDisciplina);

            builder.Entity<PlanoEnsino>()
                .Property(p => p.CdDisciplina).ValueGeneratedOnAdd();

            builder.Entity<SugestaoPlanoEnsino>()
            .HasKey(p => p.CdSugestaoPlanoEnsino);

            builder.Entity<SugestaoPlanoEnsino>()
            .HasOne<PlanoEnsino>(s => s.PlanoEnsino)
            .WithOne(p => p.SugestaoPlanoEnsino)
            .HasForeignKey<SugestaoPlanoEnsino>(s => s.CdDisciplina);


            //  builder.Entity<SugestaoPlanoEnsino>().HasOne(spe => spe.).WithMany(b => b.).HasForeignKey(bc => bc.LivroId);


            //  modelBuilder.Entity<LivroAutor>()
            //.HasOne(bc => bc.Livro)
            // .WithMany(b => b.LivrosAutores)
            //  .HasForeignKey(bc => bc.LivroId);

            //modelBuilder.Entity<LivroAutor>()
            //    .HasOne(bc => bc.Autor)
            //    .WithMany(c => c.LivrosAutores)
            //     .HasForeignKey(bc => bc.AutorId);


            builder.Entity<Usuario>()
                 .HasKey(u => u.CdUsuario);

            builder.Entity<Usuario>()
                .Property(u => u.CdUsuario).ValueGeneratedOnAdd();
        }
    }
}
