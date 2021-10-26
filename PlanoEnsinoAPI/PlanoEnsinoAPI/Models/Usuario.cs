using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class Usuario
    {
        public int CdUsuario { get; set; }
        public string Nome{ get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public string TpUsuario { get; set; } //tipo de prof se é ADM, NDE ou comum
        public string Status { get; set; }
        public UsuarioPlanoEnsino UsuarioPlanoEnsino { get; set; }

        public Usuario() { }                //construtor vazio para não bugar e precisar do NEWTONSOFT

        public Usuario(int cdUsuario, string nome, string login, string senha, string sexo, DateTime dtNascimento, string tpUsuario, string status)
        {
            CdUsuario = cdUsuario;
            Nome = nome;
            Login = login;
            Senha = senha;
            Sexo = sexo;
            DtNascimento = dtNascimento;
            TpUsuario = tpUsuario;
            Status = status;
        }
    }
}
