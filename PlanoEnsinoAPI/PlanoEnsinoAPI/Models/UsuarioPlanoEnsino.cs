using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class UsuarioPlanoEnsino
    {
        public int CdUsuario { get; set; }
        public int CdDisciplina { get; set; }

        public Usuario Usuario { get; set; }
        public PlanoEnsino PlanoEnsino { get; set; }

        public UsuarioPlanoEnsino() { }                //construtor vazio para não bugar e precisar do NEWTONSOFT

        public UsuarioPlanoEnsino(int Usuario, int Disciplina)
        {
            CdUsuario = Usuario;
            CdDisciplina = Disciplina;
        }
    }
}
