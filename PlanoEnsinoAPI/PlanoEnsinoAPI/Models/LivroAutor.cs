using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class LivroAutor
    {
        public int CdLivro { get; set; }
        public int CdAutor { get; set; }
        public Livro Livro { get; set; }
        public Autor Autor { get; set; }

        public LivroAutor() { }                //construtor vazio para não bugar e precisar do NEWTONSOFT

        public LivroAutor(int Livro, int Autor)
        {
            CdLivro = Livro;
            CdAutor = Autor;
        }
    }
}