// Create rental agency
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
agency.DisplayFleet();

// Create rentals
var rental1 = agency.CreateRental(customer1, car1, 5);
Console.WriteLine("Rental created: " + rental1.ID);
Console.WriteLine("Total Cost: $" + rental1.GetTotalCost());

var rental2 = agency.CreateRental(customer2, car3, 3);
Console.WriteLine("Rental created: " + rental2.ID);
Console.WriteLine("Total Cost: $" + rental2.GetTotalCost());

// Display available vehicles after rentals
Console.WriteLine("After rentals:");
agency.DisplayFleet();

// Complete a rental
agency.CompleteRental(rental1.ID);
Console.WriteLine("Rental " + rental1.ID + " completed!");

// Display customer rental history
var customerRentals = agency.getCustomerRentals("C001");
Console.WriteLine("Alice's rental history: " + customerRentals.Count + " rental(s)");