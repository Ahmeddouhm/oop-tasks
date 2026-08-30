using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Eagle : Animal
    {
        public Eagle(string id, string name, string species, string healthStatus, int age, double dailyFoodCost , double wingSpan, double diveSpeed) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            WingSpan = wingSpan;
            DiveSpeed = diveSpeed;
        }

        /*
           - Additional properties: `wingspan`, `diveSpeed`
           - Override `makeSound()`: Returns "Screech!"
           - Override `getHabitat()`: Returns "Mountains"
        */
        public double WingSpan { get; set; }
        public double DiveSpeed { get; set; }
        public override string GetHabitat()
        {
            return "Mountains";
        }

        public override string MakeSound()
        {
            return "Screech!";
        }
    }
}
