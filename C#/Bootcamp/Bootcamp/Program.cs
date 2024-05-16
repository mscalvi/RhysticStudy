using System;
using Bootcamp.Common.Models;
using System.Globalization;
using Newtonsoft.Json;


Pessoa pessoa1 = new Pessoa("Carlos", "Alberto", 31);
Pessoa pessoa2 = new Pessoa("Cláudio", "Macaxeira", 28);
Pessoa pessoa3 = new Pessoa("Vivian", "Scalvi", 28);
Pessoa pessoa4 = new Pessoa("Laranjo", "Calabreso", 7);
Pessoa pessoa5 = new Pessoa("Lair", "Lira", 16);
Pessoa pessoa6 = new Pessoa("Graul", "Kree", 31);

Curso NovoCurso = new Curso ();
NovoCurso.Nome = "Curso Teste";
NovoCurso.Alunos = new List<Pessoa>();

NovoCurso.AdicionarAluno (pessoa1);
NovoCurso.AdicionarAluno (pessoa2);
NovoCurso.AdicionarAluno (pessoa3);
NovoCurso.AdicionarAluno (pessoa4);
NovoCurso.AdicionarAluno (pessoa5);

NovoCurso.ListarAlunos();

Console.WriteLine(DateTime.Now.ToString());

string[] linhas = File.ReadAllLines ("../Bootcamp.Common/Archives/ReadingFile.txt");

foreach (string linha in linhas)
{
    Console.WriteLine(linha);
}

string serializado = JsonConvert.SerializeObject (NovoCurso, Formatting.Indented);
    File.WriteAllText ("../Bootcamp.Common/Archives/enturmamento.json", serializado);