using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal abstract class Animal
    {
        /*
           - `animalId` (string): Unique animal ID
           - `name` (string): Animal's name
           - `species` (string): Animal species
           - `age` (integer): Age in years
           - `healthStatus` (string): Health condition
           - `dailyFoodCost` (decimal/float): Daily feeding cost

           - **Abstract Methods:**
           - `abstract makeSound()`: Returns the sound the animal makes
           - `abstract getHabitat()`: Returns preferred habitat type

           - **Virtual Methods:**
           - `virtual getAnimalInfo()`: Returns formatted animal information
           - `virtual calculateWeeklyCost()`: Calculates weekly maintenance cost
        */

        public string ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string HealthStatus { get; set; }
        public int Age { get; set; }
        public double DailyFoodCost { get; set; }
        protected Animal(string id, string name, string species, string healthStatus, int age, double dailyFoodCost)
        {
            ID = id;
            Name = name;
            Species = species;
            HealthStatus = healthStatus;
            Age = age;
            DailyFoodCost = dailyFoodCost;
        }
        public abstract string MakeSound();
        public abstract string GetHabitat();

        public virtual string GetAnimalInfo() 
        {
            return string.Empty;
        }
        public virtual double CalculateWeeklyCost() 
        {
            return 0;
        }
    }
}
