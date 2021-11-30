using Microsoft.EntityFrameworkCore;
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
                         .OrderBy(l => l.DsLivro);

            return await query.ToArrayAsync();
        }
        public async Task<List<LivroAutorAll>> GetLivroAutorAll()
        {
            var listinha = new List<LivroAutorAll>();
            //IQueryable<Livro> query = _context.LivroAutor;

            listinha = await _context.LivroAutor
                        .Join(_context.Livro, la => la.CdLivro, li => li.CdLivro, (la, li) => new { la, li })
                        .Join(_context.Autor, la_li => la_li.la.CdAutor, al => al.CdAutor, (la_li, al) => new LivroAutorAll
                        {
                            CdLivro = la_li.li.CdLivro,
                            DsLivro = la_li.li.DsLivro,
                            Editora = la_li.li.Editora,
                            Ano = la_li.li.Ano,
                            CdAutor = la_li.la.CdAutor,
                            Nome = la_li.la.Autor.Nome
                        })
                        .OrderBy(l => l.DsLivro).ToListAsync();

            return listinha;
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

        //Curso Plano Ensino
        public async Task<CursoPlanoEnsino> GetCursoPlanoEnsinoById(int cdCurso, int cdDisciplina)
        {
            IQueryable<CursoPlanoEnsino> query = _context.CursoPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(cursop => cursop)
                         .Where(cursop => cursop.CdCurso == cdCurso)
                         .Where(cursop => cursop.CdDisciplina == cdDisciplina);

            return await query.FirstOrDefaultAsync();
        }

        //Usuario Plano Ensino
        public async Task<UsuarioPlanoEnsino> GetUsuarioPlanoEnsinoById(int cdUsuario, int cdDisciplina)
        {
            IQueryable<UsuarioPlanoEnsino> query = _context.UsuarioPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(usuariop => usuariop)
                         .Where(usuariop => usuariop.CdUsuario == cdUsuario)
                         .Where(usuariop => usuariop.CdDisciplina == cdDisciplina);

            return await query.FirstOrDefaultAsync();
        }

        //Livro Plano Ensino
        public async Task<LivroPlanoEnsino> GetLivroPlanoEnsinoById(int cdLivro, int cdDisciplina)
        {
            IQueryable<LivroPlanoEnsino> query = _context.LivroPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(livrop => livrop)
                         .Where(livrop => livrop.CdLivro == cdLivro)
                         .Where(livrop => livrop.CdDisciplina == cdDisciplina);

            return await query.FirstOrDefaultAsync();
        }

        //LivroAutor
        public async Task<LivroAutor> GetLivroAutorByIdAsync(int cdLivro, int cdAutor)
        {
            IQueryable<LivroAutor> query = _context.LivroAutor;

            query = query.AsNoTracking()
                         .OrderBy(livroa => livroa)
                         .Where(livroa => livroa.CdLivro == cdLivro)
                         .Where(livroa => livroa.CdAutor == cdAutor);

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

        //Plano de Ensino
        public async Task<PlanoEnsino[]> GetAllPlanoEnsinoAsync()
        {
            IQueryable<PlanoEnsino> query = _context.PlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(planoensino => planoensino.CdDisciplina);

            return await query.ToArrayAsync();
        }

        public async Task<PlanoEnsino> GetPlanoEnsinoByIdAsync(int id)
        {
            IQueryable<PlanoEnsino> query = _context.PlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(planoensino => planoensino)
                         .Where(planoensino => planoensino.CdDisciplina == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<PlanoEnsino> GetPlanoEnsinoByNameAsync(string nome)
        {
            IQueryable<PlanoEnsino> query = _context.PlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(planoensino => planoensino)
                         .Where(planoensino => planoensino.DsDisciplina == nome);

            return await query.FirstOrDefaultAsync();
        }

        //Sugestão Plano de Ensino
        public async Task<SugestaoPlanoEnsino[]> GetAllSugestaoPlanoEnsinoAsync()
        {
            IQueryable<SugestaoPlanoEnsino> query = _context.SugestaoPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(sugestaoplanoensino => sugestaoplanoensino.CdSugestaoPlanoEnsino);

            return await query.ToArrayAsync();
        }

        public async Task<SugestaoPlanoEnsino> GetSugestaoPlanoEnsinoByIdAsync(int id)
        {
            IQueryable<SugestaoPlanoEnsino> query = _context.SugestaoPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(sugestaoplanoensino => sugestaoplanoensino)
                         .Where(sugestaoplanoensino => sugestaoplanoensino.CdSugestaoPlanoEnsino == id);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<SugestaoPlanoEnsino> GetSugestaoPlanoEnsinoByNameAsync(string nome)
        {
            IQueryable<SugestaoPlanoEnsino> query = _context.SugestaoPlanoEnsino;

            query = query.AsNoTracking()
                         .OrderBy(sugestaoplanoensino => sugestaoplanoensino)
                         .Where(sugestaoplanoensino => sugestaoplanoensino.DsSugestaoPlanoEnsino == nome);

            return await query.FirstOrDefaultAsync();
        }
    }
}
