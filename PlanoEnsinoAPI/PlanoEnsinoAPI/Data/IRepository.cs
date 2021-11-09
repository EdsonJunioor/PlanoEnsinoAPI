﻿using PlanoEnsinoAPI.Models;
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
        Task<Livro[]> GetAllLivroAsync ();
        Task<Livro> GetLivroByIdAsync (int livroCd);
        Task<Livro> GetLivroByNameAsync(string nome);

        //GET Curso
        Task<Curso[]> GetAllCursoAsync();
        Task<Curso> GetCursoByIdAsync (int cursoCd);
        Task<Curso> GetCursoByNameAsync(string nome);

        //GET Autor
        Task<Autor[]> GetAllAutorAsync();
        Task<Autor> GetAutorByIdAsync (int autorCd);
        Task<Autor> GetAutorByNameAsync (string nome);

        //GET Avaliacao
        Task<Avaliacao[]> GetAllAvaliacaoAsync();
        Task<Avaliacao> GetAvaliacaoByIdAsync(int avaliacaoCd);
        Task<Avaliacao> GetAvaliacaoByNameAsync(string nome);

        //GET PlanoEnsino
        Task<PlanoEnsino[]> GetAllPlanoEnsinoAsync();
        Task<PlanoEnsino> GetPlanoEnsinoByIdAsync(int planoEnsinoCd);
        Task<PlanoEnsino> GetPlanoEnsinoByNameAsync(string nome);
    }
}
//Repository => Irepository => controller do obj