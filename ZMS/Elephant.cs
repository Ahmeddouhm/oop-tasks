using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Elephant : Animal
    {

        /*
           - Additional properties: `tuskLength`, `weight`
           - Override `makeSound()`: Returns "Trumpet!"
           - Override `getHabitat()`: Returns "Grassland"
        */

        public double Weight { get; set; }
        public double TuskLength { get; set; }
        public Elephant(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, double weight, double tuskLen) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            TuskLength = tuskLen;
            Weight = weight;
        }

        public override string MakeSound()
        {
            return "Trumpet!";
        }

        public override string GetHabitat()
        {
            return "GrassLand";
        }
    }
}
