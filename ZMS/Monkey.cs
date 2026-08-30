using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Monkey : Animal
    {
        /*
           - Additional properties: `tailLength`, `favoriteFood`
           - Override `makeSound()`: Returns "Ooh ooh ah ah!"
           - Override `getHabitat()`: Returns "Rainforest"
        */

        public double TailLength { get; set; }
        public string FavFood { get; set; }
        public Monkey(string id, string name, string species, string healthStatus, int age, double dailyFoodCost, string favfood, double tailLen) : base(id, name, species, healthStatus, age, dailyFoodCost)
        {
            FavFood = favfood;
            TailLength = tailLen;
        }

        public override string GetHabitat()
        {
            return "Rainforest";
        }

        public override string MakeSound()
        {
            return "Ooh Ooh ah ah!";
        }
    }
}
