using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Bugs!");
            Bug newBug1 = new Bug("Andy", "ant", new List<string> (){"bird", "morebird", "bigbird"}, new List<string>() {"picnics", "food", "sweets"});
            Bug newBug2 = new Bug("Mandy", "mantis", new List<string> (){"bird", "morebird", "mantis"}, new List<string>() {"ant", "mantis", "sweets"});
            
            foreach (string each in newBug1.Prey) {
                Console.WriteLine(each);
            }

            Console.WriteLine(newBug2.Eat("ant"));
            Console.WriteLine(newBug2.Eat("bird"));
        }
    }

    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName
        {
            get
            {
                return $"{this.Name} the {this.Species}";
            }
        }

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        // public string PreyList()
        // {
        //     var commaDelimitedPrey = string.Join(",", this.Prey);
        //     return commaDelimitedPrey;
        // }

        public string PreyList => String.Join(",", this.Prey);

        // Convert this method to an expression member
        // public string PredatorList()
        // {
        //     var commaDelimitedPredators = string.Join(",", this.Predators);
        //     return commaDelimitedPredators;
        // }

        public string PredatorList => String.Join(",", this.Predators);

        // Convert this to expression method (hint: use a C# ternary)
        // public string Eat(string food)
        // {
        //     if (this.Prey.Contains(food))
        //     {
        //         return $"{this.Name} ate the {food}.";
        //     } else {
        //         return $"{this.Name} is still hungry.";
        //     }
        // }

        // public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
        public string Eat(string food) => Prey.Contains(food) ? $"{Name} ate the {food}." : $"{Name} is still hungry.";


    }


}




