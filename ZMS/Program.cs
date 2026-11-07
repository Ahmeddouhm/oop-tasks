using System;
using System.Collections.Generic;
using ZMS;

// 1. Create zoo
var zoo = new Zoo("Safari World");

// 2. Create animals
var lion = new Lion("A001", "Simba", "African Lion", "Healthy", 5, 50.00, "Golden", 3);
var elephant = new Elephant("A002", "Dumbo", "African Elephant", "Healthy", 15, 80.00, 5000, 2.5);
var parrot = new Parrot("A003", "Polly", "Macaw", "Healthy", 8, 10.00, true);
parrot.Vocabulary.Add("Hello");
parrot.Vocabulary.Add("Goodbye");
parrot.Vocabulary.Add("Pretty bird");
var snake = new Snake("A004", "Kaa", "Python", "Healthy", 10, 15.00, 4.5, true);
var eagle = new Eagle("A005", "Freedom", "Bald Eagle", "Healthy", 6, 20.00, 2.3, 320);

// 3. Add animals to zoo
zoo.AddAnimal(lion);
zoo.AddAnimal(elephant);
zoo.AddAnimal(parrot);
zoo.AddAnimal(snake);
zoo.AddAnimal(eagle);

// 4. Create zookeepers
var keeper1 = new Zookeeper("K001", "John Smith", "Mammals");
var keeper2 = new Zookeeper("K002", "Jane Doe", "Birds and Reptiles");

zoo.Keepers.Add(keeper1);
zoo.Keepers.Add(keeper2);

// 5. Assign animals to keepers
zoo.AssignAnimalToKeeper(lion, keeper1);
zoo.AssignAnimalToKeeper(elephant, keeper1);
zoo.AssignAnimalToKeeper(parrot, keeper2);
zoo.AssignAnimalToKeeper(snake, keeper2);
zoo.AssignAnimalToKeeper(eagle, keeper2);

// 6. Display all animals
Console.WriteLine(zoo.DisplayAllAnimals());

// 7. Demonstrate polymorphism (Animal sounds)
Console.WriteLine("=== Animal Sounds ===");
foreach (var animal in zoo.Animals)
{
    Console.WriteLine($"{animal.Name} says: {animal.MakeSound()}");
}

// 8. Get animals by habitat
Console.WriteLine("\n=== Savanna Animals ===");
var savannaAnimals = zoo.GetAnimalsByHabitat("Savanna");
if (savannaAnimals != null)
{
    foreach (var animal in savannaAnimals)
    {
        Console.WriteLine($"- {animal.Name} ({animal.Species})");
    }
}

// 9. Calculate total weekly cost
double weeklyCost = zoo.CalculateTotalWeeklyCost();
Console.WriteLine($"\nTotal Weekly Cost: ${weeklyCost:F2}");

// 10. Zookeeper activities
Console.WriteLine("\n=== Zookeeper Activities ===");
keeper1.FeedAnimal(lion);
keeper1.CheckHealth(elephant);
Console.WriteLine($"{keeper1.Name}'s workload: {keeper1.GetWorkLoad()} animals");

// 11. Zoo statistics
Console.WriteLine("\n" + zoo.GetZooStatistics());


