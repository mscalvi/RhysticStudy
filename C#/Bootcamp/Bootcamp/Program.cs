using System;
using Bootcamp.Common.Models;

Pessoa pessoa1 = new Pessoa();
Pessoa pessoa2 = new Pessoa();
Pessoa pessoa3 = new Pessoa();

pessoa1.Nome = "Carlos";
pessoa1.Idade = 28;
pessoa1.Apresentar();

pessoa2.Nome = "Cláudio";
pessoa2.Idade = 26;
pessoa2.Apresentar();

pessoa3.Nome = "Vivian";
pessoa3.Idade = 28;
pessoa3.Apresentar();

pessoa3.Nome = "Laranjo";
pessoa3.Idade = 7;
pessoa3.Apresentar();

Console.WriteLine(DateTime.Now.ToString());