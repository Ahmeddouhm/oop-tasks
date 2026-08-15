// Create rental agency
using System.Globalization;
using VRS;

var agency = new RentalAgency("Prime Car Rentals");

// Add vehicles to fleet
var car1 = new Vehicle("V001", "Toyota", "Camry", 2022, 45.00);
var car2 = new Vehicle("V002", "Honda", "Accord", 2023, 50.00);
var car3 = new Vehicle("V003", "Tesla", "Model 3", 2023, 85.00);

agency.AddVehicle(car1);
agency.AddVehicle(car2);
agency.AddVehicle(car3);

// Register customers
var customer1 = new Customer("C001", "Alice Johnson", "555-0123",
                        "alice@email.com", "DL123456");
var customer2 = new Customer("C002", "Bob Smith", "555-0456",
                        "bob@email.com", "DL789012");

agency.RegisterCustomer(customer1);
agency.RegisterCustomer(customer2);

// Display available vehicles
Console.WriteLine(agency.DisplayFleet());

// Create rentals
var rental1 = agency.CreateRental(customer1, car1, 5);
Console.WriteLine("Rental created: " + rental1.ID);
Console.WriteLine("Total Cost: " + rental1.GetTotalCost().ToString("C"));
Console.WriteLine($"Customer: {rental1.Customer.Name}");
Console.WriteLine($"Vehicle: {rental1.Vehicle.Year} {rental1.Vehicle.Make} {rental1.Vehicle.Model} ");
Console.WriteLine($"Duration: {rental1.GetRentalDuration()} Days");
Console.WriteLine();

var rental2 = agency.CreateRental(customer2, car3, 3);
Console.WriteLine("Rental created: " + rental2.ID);
Console.WriteLine("Total Cost: " + rental2.GetTotalCost().ToString("C"));
Console.WriteLine($"Customer: {rental2.Customer.Name}");
Console.WriteLine($"Vehicle: {rental2.Vehicle.Year} {rental2.Vehicle.Make} {rental2.Vehicle.Model} ");
Console.WriteLine($"Duration: {rental2.GetRentalDuration()} Days");
Console.WriteLine();

// Display available vehicles after rentals
Console.WriteLine("After rentals:");
Console.WriteLine(agency.DisplayFleet());

// Complete a rental
agency.CompleteRental(rental1.ID);
Console.WriteLine("Rental " + rental1.ID + " completed!");

// Display customer rental history
var customerRentals = agency.getCustomerRentals("C001");
Console.WriteLine("Alice's rental history: " + customerRentals.Count + " rental(s)");

/*
=== Prime Car Rentals - Fleet Status ===
V001 - 2022 Toyota Camry - $45.00/day - Available
V002 - 2023 Honda Accord - $50.00/day - Available
V003 - 2023 Tesla Model 3 - $85.00/day - Available

Rental created: R001
Customer: Alice Johnson
Vehicle: 2022 Toyota Camry
Duration: 5 days
Total Cost: $225.00

Rental created: R002
Customer: Bob Smith
Vehicle: 2023 Tesla Model 3
Duration: 3 days
Total Cost: $255.00

After rentals:
V001 - 2022 Toyota Camry - $45.00/day - Rented
V002 - 2023 Honda Accord - $50.00/day - Available
V003 - 2023 Tesla Model 3 - $85.00/day - Rented

Rental R001 completed!
Vehicle 2022 Toyota Camry is now available.

Alice's rental history: 1 rental(s) 
*/
