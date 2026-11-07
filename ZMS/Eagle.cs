using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Eagle : Animal
    {

        /*
           - Additional properties: `wingspan`, `diveSpeed`
           - Override `makeSound()`: Returns "Screech!"
           - Override `getHabitat()`: Returns "Mountains"
        */
        public double WingSpan { get; set; }
        public double DiveSpeed { get; set; }
        public Eagle(string id, string name, string species, string healthStatus, int age, double dailyFoodCost , double wingSpan, double diveSpeed) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            WingSpan = wingSpan;
            DiveSpeed = diveSpeed;
        }
        public override string GetHabitat()
        {
            return "Mountains";
        }

        public override string MakeSound()
        {
            return "Screech!";
        }

        public override string GetAnimalInfo()
        {
            return base.GetAnimalInfo() + $" - Wing Span: {WingSpan:F2}" + $"Dive Speed: {DiveSpeed:F2}";
        }

        public override double CalculateWeeklyCost()
        {
            return base.CalculateWeeklyCost();
        }
    }
}
