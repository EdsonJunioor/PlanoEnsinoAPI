using PlanoEnsinoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Data
{
    public interface IRepository
    {
        // CRUD GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //GET Usuario
        Task<Usuario[]> GetAllUsuarioAsync ();
        Task<Usuario> GetUsuarioByIdAsync (int usuarioCd);
        Task<Usuario> GetUsuarioByNameAsync (string nome);

        //Login
        Task<Usuario> GetUsuarioByEmailAsync(string email);

        //GET Livro
        Task<Livro[]> GetAllLivroAsync();
        Task<Livro> GetLivroByIdAsync (int livroCd);
        Task<Livro> GetLivroByNameAsync(string nome);

        //GET Curso
        Task<Curso[]> GetAllCursoAsync();
        Task<Curso> GetCursoByIdAsync (int cursoCd);
        Task<Curso> GetCursoByNameAsync(string nome);

        //GET Autor
        Task<Autor[]> GetAllAutorAsync();
        Task<Autor> GetAutorByIdAsync (int autorCd);
        Task<Autor> GetAutorByNameAsync(string nome);

        //GET PlanoEnsino
        Task<PlanoEnsino[]> GetAllPlanoEnsinoAsync();
        Task<PlanoEnsino> GetPlanoEnsinoByIdAsync(int planoEnsinoCd);
        Task<PlanoEnsino> GetPlanoEnsinoByNameAsync(string nome);

        //GET SugestaoPlanoEnsino
        Task<SugestaoPlanoEnsino[]> GetAllSugestaoPlanoEnsinoAsync();
        Task<SugestaoPlanoEnsino> GetSugestaoPlanoEnsinoByIdAsync(int sugestaoPlanoEnsinoCd);
        Task<SugestaoPlanoEnsino> GetSugestaoPlanoEnsinoByNameAsync(string nome);

        //GET LIVROAUTOR
        Task<LivroAutor> GetLivroAutorByIdAsync(int cdLivro, int cdAutor);
        Task<List<LivroAutorAll>> GetLivroAutorAll();

        //GET CURSOPLANOENSINO
        Task<CursoPlanoEnsino> GetCursoPlanoEnsinoById(int cdCurso, int cdDisciplina);

        //GET USUARIOPLANOENSINO
        Task<UsuarioPlanoEnsino> GetUsuarioPlanoEnsinoById(int cdUsuario, int cdDisciplina);

        //GET LIVROPLANOENSINO
        Task<LivroPlanoEnsino> GetLivroPlanoEnsinoById(int cdLivro, int cdDisciplina);
    }
}
//Repository => Irepository => controller do obj