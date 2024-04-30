using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Common.Models
{
    public class Curso
    {
        public string Nome {get; set;} 
        public List<Pessoa> Alunos {get; set;}

        public void AdicionarAluno (Pessoa aluno)
        {
            Alunos.Add(aluno);
        }

        public void ExcluirAluno (Pessoa aluno)
        {
            Alunos.Remove(aluno);
        }

        public void ListarAlunos ()
        {
            int quantidade = Alunos.Count;
            if (Alunos.Any())
            {  
                int i = 0;
                Console.WriteLine("Curso: " + Nome + "\nAlunos listados: " + quantidade + "\n");
                foreach (var aluno in Alunos){
                    i++;
                    Console.WriteLine($"{i}- {aluno.NomeCompleto}, {aluno.Idade} anos");
                }
            }
            else
            {
                Console.WriteLine("Não há alunos listados.");
            }
        }
    }
}