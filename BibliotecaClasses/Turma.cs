using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClasses
{
    public class Turma
    {
        public string Nome { get; set; }

        public string Curso { get; set; }

        public Professor DiretorTurma { get; set; }

        public List<Disciplina> Disciplinas { get; set; }

        public List<Aluno> Alunos { get; set; }

        public override string ToString()
        {
            return $"{Nome} {Curso}"; 
        }
    }
}
