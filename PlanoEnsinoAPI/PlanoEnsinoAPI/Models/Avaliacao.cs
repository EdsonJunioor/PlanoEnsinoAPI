using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class Avaliacao
    {
        public int CdAvaliacao { get; set; }
        public int CdDisciplina { get; set; }       //FK de Plano Ensino
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public string DsAluno { get; set; }
        public string DsConsulta { get; set; }
        public string DsAvaliacao { get; set; }
        public string DsConteudo { get; set; }
        public string DsObservacao { get; set; }
        public PlanoEnsino PlanoEnsino { get; set; }

        public Avaliacao() { }       //construtor vazio para não bugar e precisar do NEWTONSOFT

        public Avaliacao(int cdAvaliacao, int cdDisciplina, string nome, decimal peso, string dsAluno, string dsConsulta, string dsAvaliacao, string dsConteudo, string dsObservacao)
        {
            CdAvaliacao = cdAvaliacao;
            CdDisciplina = cdDisciplina;
            Nome = nome;
            Peso = peso;
            DsAluno = dsAluno;
            DsConsulta = dsConsulta;
            DsAvaliacao = dsAvaliacao;
            DsConteudo = dsConteudo;
            DsObservacao = dsObservacao;
        }
    }
}