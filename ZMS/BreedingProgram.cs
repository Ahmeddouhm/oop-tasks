using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class BreedingProgram
    {
        static int num = 0;
        public Animal? TryBreed(Animal parent1, Animal parent2) 
        {
            if (parent1.Species != parent2.Species) 
            {
                return null;
            }

            if (parent1.Gender == parent2.Gender)
            {
                return null;
            }

            if (!parent1.IsEndangered || !parent2.IsEndangered)
            {
                return null;
            }

            return (Animal)Activator.CreateInstance(parent1.GetType(), $"B00{++num}", "Junior", parent1.Species, "Healthy", 0, parent1.DailyFoodCost * 0.5)!;
        }
    }
}
