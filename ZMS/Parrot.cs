using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Parrot : Animal
    {

        /*
           - Additional properties: `canTalk`, `vocabulary` (List/Array of strings)
           - Override `makeSound()`: Returns "Squawk!"
           - Add method: `speak()`: Returns a random word from vocabulary
        */

        public bool CanTalk { get; set; }
        public List<string> Vocabulary { get; set; } = new List<string> { "Hi", "Salam 3alaykom", "B7bk", "El 3asfoor" };
        public Parrot(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, bool canTalk = false) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            CanTalk = canTalk;
        }
        public override string GetHabitat()
        {
            return "Rainforest";
        }

        public override string MakeSound()
        {
            return "Squawk!";
        }

        public string Speak() 
        {
            Random rnd = new();

            return Vocabulary[rnd.Next(0, Vocabulary.Count)];
        }
    }
}
