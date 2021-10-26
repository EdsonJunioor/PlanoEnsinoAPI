using Microsoft.EntityFrameworkCore;
using PlanoEnsinoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
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
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

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
       
    }
}
