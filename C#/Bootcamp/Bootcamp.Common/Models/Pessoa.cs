using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bootcamp.Common.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, string sobrenome, int idade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
        }

        private string _nome;
        private string _sobrenome;
        private int _idade;
        public string Nome 
        { 
            get => _nome.ToUpper();

            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome não pode ser vazio!");
                }

                _nome = value;
            } 
        }
        public string Sobrenome 
        { 
            get => _sobrenome.ToUpper();

            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O sobrenome não pode ser vazio!");
                }

                _sobrenome = value;
            } 
        }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public int Idade 
        { 
            get => _idade;

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException ("Precisa ter nascido!");
                }

                _idade = value;
            }
        }

        public void Apresentar()
        {
            Console.WriteLine($"Olá! Meu nome é {NomeCompleto} e tenho {Idade} anos.");
        }
    }
}