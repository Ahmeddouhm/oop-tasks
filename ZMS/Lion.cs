using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Lion : Animal
    {
        /*
           - Additional properties: `maneColor`, `prideSize`
           - Override `makeSound()`: Returns "Roar!"
           - Override `getHabitat()`: Returns "Savanna"
        */

        public string ManeColor { get; set; }
        public double PrideSize { get; set; }
        public Lion(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, string maneColor, double prideSize) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            ManeColor = maneColor;
            PrideSize = prideSize;
        }

        public override string MakeSound()
        {
            return "Roar!";
        }

        public override string GetHabitat()
        {
            return "Savanna";
        }
    }
}
