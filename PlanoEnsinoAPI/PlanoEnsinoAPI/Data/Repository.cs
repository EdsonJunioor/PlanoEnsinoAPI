﻿using Microsoft.EntityFrameworkCore;
using PlanoEnsinoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Data               //Repository => Irepository => controller do obj
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        //METÓDOS GLOBAIS

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        //METÓDOS ESPECIFICOS PARA UM OBJETO

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Usuario
        public async Task<Usuario[]> GetAllUsuarioAsync()
        {
            IQueryable<Usuario> query = _context.Usuario;

            query = query.AsNoTracking()
                         .OrderBy(c => c.CdUsuario);

            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            IQueryable<Usuario> query = _context.Usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario)
                         .Where(usuario => usuario.CdUsuario == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Usuario> GetUsuarioByNameAsync(string nome)
        {
            IQueryable<Usuario> query = _context.Usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario)
                         .Where(usuario => usuario.Nome == nome);

            return await query.FirstOrDefaultAsync();
        }

        //Login
        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            IQueryable<Usuario> query = _context.Usuario;

            query = query.AsNoTracking()
                         .OrderBy(usuario => usuario)
                         .Where(usuario => usuario.Login == email);

            return await query.FirstOrDefaultAsync();
        }

        //Livro
        public async Task<Livro[]> GetAllLivroAsync()
        {
            IQueryable<Livro> query = _context.Livro;

            query = query.AsNoTracking()
                         .OrderBy(livro => livro.DsLivro);

            return await query.ToArrayAsync();
        }
        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            IQueryable<Livro> query = _context.Livro;

            query = query.AsNoTracking()
                         .OrderBy(livro => livro)
                         .Where(livro => livro.CdLivro == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Livro> GetLivroByNameAsync(string nome)
        {
            IQueryable<Livro> query = _context.Livro;

            query = query.AsNoTracking()
                         .OrderBy(livro => livro)
                         .Where(livro => livro.DsLivro == nome);

            return await query.FirstOrDefaultAsync();
        }

        //Curso
        public async Task<Curso[]> GetAllCursoAsync()
        {
            IQueryable<Curso> query = _context.Curso;

            query = query.AsNoTracking()
                         .OrderBy(curso => curso.DsCurso);

            return await query.ToArrayAsync();
        }
        public async Task<Curso> GetCursoByIdAsync(int id)
        {
            IQueryable<Curso> query = _context.Curso;

            query = query.AsNoTracking()
                         .OrderBy(curso => curso)
                         .Where(curso => curso.CdCurso == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Curso> GetCursoByNameAsync(string nome)
        {
            IQueryable<Curso> query = _context.Curso;

            query = query.AsNoTracking()
                         .OrderBy(curso => curso)
                         .Where(curso => curso.DsCurso == nome);

            return await query.FirstOrDefaultAsync();
        }

        //Autor
        public async Task<Autor[]> GetAllAutorAsync()
        {
            IQueryable<Autor> query = _context.Autor;

            query = query.AsNoTracking()
                         .OrderBy(autor => autor.Nome);

            return await query.ToArrayAsync();
        }
        public async Task<Autor> GetAutorByIdAsync(int id)
        {
            IQueryable<Autor> query = _context.Autor;

            query = query.AsNoTracking()
                         .OrderBy(autor => autor)
                         .Where(autor => autor.CdAutor == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Autor> GetAutorByNameAsync(string nome)
        {
            IQueryable<Autor> query = _context.Autor;

            query = query.AsNoTracking()
                         .OrderBy(autor => autor)
                         .Where(autor => autor.Nome == nome);

            return await query.FirstOrDefaultAsync();
        }

        //Avaliacao
        public async Task<Avaliacao[]> GetAllAvaliacaoAsync()
        {
            IQueryable<Avaliacao> query = _context.Avaliacao;

            query = query.AsNoTracking()
                         .OrderBy(avaliacao => avaliacao.CdAvaliacao);

            return await query.ToArrayAsync();
        }

        public async Task<Avaliacao> GetAvaliacaoByIdAsync(int id)
        {
            IQueryable<Avaliacao> query = _context.Avaliacao;

            query = query.AsNoTracking()
                         .OrderBy(avaliacao => avaliacao)
                         .Where(avaliacao => avaliacao.CdAvaliacao == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Avaliacao> GetAvaliacaoByNameAsync(string nome)
        {
            IQueryable<Avaliacao> query = _context.Avaliacao;

            query = query.AsNoTracking()
                         .OrderBy(avaliacao => avaliacao)
                         .Where(avaliacao => avaliacao.Nome == nome);

            return await query.FirstOrDefaultAsync();
        }
    }
}
