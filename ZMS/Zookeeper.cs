using System;
using System.Collections.Generic;
using System.Text;

namespace ZMS
{
    internal class Zookeeper
    {

        /*
           - `employeeId` (string)
           - `name` (string)
           - `specialization` (string): Type of animals they handle
           - `assignedAnimals` (List/Array of Animal objects)

           - **Methods:**
           - `feedAnimal(animal)`: Feeds an animal
           - `checkHealth(animal)`: Checks animal health
           - `getWorkload()`: Returns number of assigned animals
        */
        public string ID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Animal> AssignedAnimals { get; set; }
        public Zookeeper(string id, string name, string specialization)
        {
            ID = id;
            Name = name;
            Specialization = specialization;
            AssignedAnimals = new();
        }

        public void FeedAnimal(Animal animal) 
        {
            Console.WriteLine($"{Name} fed {animal.Name} ({animal.Species})");
        }

        public void CheckHealth(Animal animal) => Console.WriteLine($"{Name} checked health of {animal.Name} ({animal.Species}) - Status: {animal.HealthStatus}");

        public int GetWorkLoad() 
        {
            return AssignedAnimals.Count;
        }


    }
}
