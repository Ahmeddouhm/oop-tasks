using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Snake : Animal
    {

        /*
           - Additional properties: `isVenomous`, `length`
           - Override `makeSound()`: Returns "Hiss!"
           - Override `getHabitat()`: Returns "Desert"
        */
        public bool IsVenomous { get; set; }
        public double Length { get; set; }
        public Snake(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, double length, bool isVenomous = false) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            IsVenomous = isVenomous;
            Length = length;
        }

        public override string GetHabitat()
        {
            return "Desert!";
        }

        public override string MakeSound()
        {
            return "Hiss!";
        }
    }
}
