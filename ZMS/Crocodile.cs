using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Crocodile : Animal
    {

        /*
           - Additional properties: `jawStrength`, `weight`
           - Override `makeSound()`: Returns "Growl!"
           - Override `getHabitat()`: Returns "Swamp"
        */

        public double JawStrength { get; set; }
        public double Weight { get; set; }
        public Crocodile(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, double jawStrength, double weight) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            JawStrength = jawStrength;
            Weight = weight;
        }
        public override string GetHabitat()
        {
            return "Swamp";
        }

        public override string MakeSound()
        {
            return "Growl!";
        }
    }
}
