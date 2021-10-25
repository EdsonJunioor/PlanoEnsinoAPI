﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanoEnsinoAPI.Models
{
    public class CursoPlanoEnsino
    {
        public int CdCurso { get; set; }
        public int CdDisciplina { get; set; }
        public Curso Curso { get; set; }
        public PlanoEnsino PlanoEnsino { get; set; }

        public CursoPlanoEnsino() { }                //construtor vazio para não bugar e precisar do NEWTONSOFT

        public CursoPlanoEnsino(int Curso, int Disciplina)
        {
            CdCurso = Curso;
            CdDisciplina = Disciplina;
        }
    }
}