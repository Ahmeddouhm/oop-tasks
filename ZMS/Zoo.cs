using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Zoo
    {
        /*
            - `zooName` (string)
            - `animals` (List/Array of Animal objects)
            - `zookeepers` (List/Array of Zookeeper objects)

            - **Methods:**
            - `addAnimal(animal)`: Adds animal to zoo
            - `removeAnimal(animalId)`: Removes animal
            - `assignAnimalToKeeper(animal, keeper)`: Assigns care responsibility
            - `getAnimalsByHabitat(habitat)`: Returns animals by habitat type
            - `getAnimalsBySpecies(species)`: Returns animals by species
            - `calculateTotalWeeklyCost()`: Calculates total maintenance cost
            - `displayAllAnimals()`: Shows all animals with their sounds
            - `getZooStatistics()`: Returns summary statistics
         */

        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Zookeeper> Keepers { get; set; }

        public Predicate<Animal> FilterAnimals;

        public void AddAnimal(Animal animal) 
        {
            if (animal is null)
            {
                Console.WriteLine("[ERROR] Null Animal Value");
                return;
            }

            Animals.Add(animal);
        }
        public void RemoveAnimal(Animal animal) 
        {
            if (animal is null)
            {
                Console.WriteLine("[ERROR] Null Animal Value");
                return;
            }

            Animals.Remove(animal);
        }

        public void AssignAnimalToKeeper(Animal animal, Zookeeper keeper) 
        {
            if (animal is null || keeper is null)
            {
                Console.WriteLine("[ERROR] Null Values");
                return;
            }

            keeper.AssignedAnimals.Add(animal);
        }

        public List<Animal>? GetAnimals(Predicate<Animal> filter) 
        {
            var animals = new List<Animal>();

            foreach (var a in Animals)
            {
                if (filter(a))
                {
                    animals.Add(a);
                }
            }

            return animals;
        }
        public List<Animal>? GetAnimalsBySpecies(string species) => GetAnimals(a => a.Species == species);
        public List<Animal>? GetAnimalsByHabitat(string habitat) => GetAnimals(a => a.GetHabitat() == habitat);

        public double CalculateTotalWeeklyCost() 
        {
            double cost = 0;

            foreach (var a in Animals)
            {
                cost += a.CalculateWeeklyCost();
            }

            return cost;
        }

        public string DisplayAllAnimals() 
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} All Animals");
            sb.AppendLine($"==================");

            foreach (var a in Animals)
            {
                sb.AppendLine($"{a.Name} - Makes {a.MakeSound()}");
            }

            return sb.ToString();
        }

        public string GetZooStatistics() 
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} Statistics");
            sb.AppendLine($"==================");

            sb.AppendLine($"Zoo has {Animals.Count}");
            sb.AppendLine($"Zoo has {Keepers.Count}");
            sb.AppendLine($"Zoo costs weekly {CalculateTotalWeeklyCost()}");

            return sb.ToString();
        }
    }
}
