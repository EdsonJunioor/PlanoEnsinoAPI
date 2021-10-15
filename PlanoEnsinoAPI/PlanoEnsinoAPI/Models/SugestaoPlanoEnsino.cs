using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class SugestaoPlanoEnsino
    {
        //public int CdSugestaoPlanoEnsino { get; set; }
        public int CdDisciplina { get; set; }          //FK de plano de ensino
        public string DsDisciplina { get; set; }       
        public string DsPlanoEnsino { get; set; }
        public int NrCreditos { get; set; }
        public int NrHorasSala { get; set; }           //horas da aula dentro da sala de aula
        public int NrHorasPP { get; set; }
        public string AnoSemestre { get; set; }        //formato ano e semestre 202102
        public string DsEmenta { get; set; }           //tipo de prof se é ADM, NDE ou comum
        public string DsObjetivo { get; set; }
        public string DsMTDGeral { get; set; }         //metodologia geral
        public string DsObservecao { get; set; }
        public string DsBiblioBasica { get; set; }
        public string DsBiblioComplementar { get; set; }
        public string DsSemana1 { get; set; }
        public string DsSemana2 { get; set; }
        public string DsSemana3 { get; set; }
        public string DsSemana4 { get; set; }
        public string DsSemana5 { get; set; }
        public string DsSemana6 { get; set; }
        public string DsSemana7 { get; set; }
        public string DsSemana8 { get; set; }
        public string DsSemana9 { get; set; }
        public string DsSemana10 { get; set; }
        public string DsSemana11 { get; set; }
        public string DsSemana12 { get; set; }
        public string DsSemana13 { get; set; }
        public string DsSemana14 { get; set; }
        public string DsSemana15 { get; set; }
        public string DsSemana16 { get; set; }
        public string DsSemana17 { get; set; }
        public string DsSemana18 { get; set; }
        public string DsSemana19 { get; set; }
        public string DsSemana20 { get; set; }
        public string Status { get; set; }
        public DateTime DtAtualização { get; set; }

        public PlanoEnsino PlanoEnsino { get; set; }

        public SugestaoPlanoEnsino() { }    //construtor vazio para não bugar e precisar do NEWTONSOFT

        public SugestaoPlanoEnsino(int cdDisciplina, string dsDisciplina, string dsPlanoEnsino, int nrCreditos, int nrHorasSala, int nrHorasPP, string anoSemestre, string dsEmenta, string dsObjetivo, string dsMTDGeral, string dsObservecao, string dsBiblioBasica, string dsBiblioComplementar, string dsSemana1, string dsSemana2, string dsSemana3, string dsSemana4, string dsSemana5, string dsSemana6, string dsSemana7, string dsSemana8, string dsSemana9, string dsSemana10, string dsSemana11, string dsSemana12, string dsSemana13, string dsSemana14, string dsSemana15, string dsSemana16, string dsSemana17, string dsSemana18, string dsSemana19, string dsSemana20, string status, DateTime dtAtualização)
        {
            CdDisciplina = cdDisciplina;
            DsDisciplina = dsDisciplina;
            DsPlanoEnsino = dsPlanoEnsino;
            NrCreditos = nrCreditos;
            NrHorasSala = nrHorasSala;
            NrHorasPP = nrHorasPP;
            AnoSemestre = anoSemestre;
            DsEmenta = dsEmenta;
            DsObjetivo = dsObjetivo;
            DsMTDGeral = dsMTDGeral;
            DsObservecao = dsObservecao;
            DsBiblioBasica = dsBiblioBasica;
            DsBiblioComplementar = dsBiblioComplementar;
            DsSemana1 = dsSemana1;
            DsSemana2 = dsSemana2;
            DsSemana3 = dsSemana3;
            DsSemana4 = dsSemana4;
            DsSemana5 = dsSemana5;
            DsSemana6 = dsSemana6;
            DsSemana7 = dsSemana7;
            DsSemana8 = dsSemana8;
            DsSemana9 = dsSemana9;
            DsSemana10 = dsSemana10;
            DsSemana11 = dsSemana11;
            DsSemana12 = dsSemana12;
            DsSemana13 = dsSemana13;
            DsSemana14 = dsSemana14;
            DsSemana15 = dsSemana15;
            DsSemana16 = dsSemana16;
            DsSemana17 = dsSemana17;
            DsSemana18 = dsSemana18;
            DsSemana19 = dsSemana19;
            DsSemana20 = dsSemana20;
            Status = status;
            DtAtualização = dtAtualização;
        }
    }
}
