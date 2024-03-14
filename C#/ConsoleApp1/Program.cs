using System;

namespace Program
{
    class Program {

        static void Main(string[] args)
        {
            Mammal FirstMammal = new Mammal();
            Mammal SecondMammal = new Mammal();

            FirstMammal.NameOfMammal = "Lion";
            SecondMammal.NameOfMammal = "Kitten";

            Console.WriteLine("The first mammal is a " + FirstMammal.NameOfMammal + " and does " + FirstMammal.SoundOfMammal());
            Console.WriteLine("The second mammal is a " + SecondMammal.NameOfMammal + " and does " + SecondMammal.SoundOfMammal());
        }
    }

    class Mammal
    {
        public string NameOfMammal { get; set; }

        public string SoundOfMammal ()
        {
            switch (NameOfMammal)
            {
                case "Lion":
                    return "Roar";
                case "Kitten":
                    return "Meow";
                default:
                    return "Noises";
            }
        }
    }
}