using Bootcamp.Models;

Pessoa pessoa1 = new Pessoa();
Pessoa pessoa2 = new Pessoa();

pessoa1.Nome = "Carlos";
pessoa1.Idade = 28;
pessoa1.Apresentar();

pessoa2.Nome = "Cláudio";
pessoa2.Idade = 26;
pessoa2.Apresentar();

Console.WriteLine(DateTime.Now.ToString());