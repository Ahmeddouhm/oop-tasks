using System;
using System.Collections.Generic;
using System.Text;

namespace VRS
{
    internal class RentalAgency
    {
        public string AgencyName { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Rental> Rentals { get; set; }

        public RentalAgency(string agencyName)
        {
            AgencyName = agencyName;
            Vehicles = new();
            Customers = new();
            Rentals = new();
        }

        public void AddVehicle(Vehicle vehicle) 
        {
            if (vehicle == null)
            {
                Console.WriteLine("Vehicle is Empty !");
                return;
            }

            Vehicles.Add(vehicle);
        }

        public void RegisterCustomer(Customer customer) 
        {
            if (customer == null)
            {
                Console.WriteLine("Customer is Empty !");
                return;
            }

            Customers.Add(customer);
        }

        public Rental? CreateRental(Customer customer, Vehicle vehicle, int days)
        {
            if (customer == null || vehicle == null || days <= 0)
            {
                Console.WriteLine("Invalid Data");
                return null;
            }

            string rentalsID = (Rentals.Count + 1).ToString("D4");
            DateTime endDate = DateTime.Now.AddDays(days);

            Rental rental = new(rentalsID, customer, vehicle, endDate);

            Rentals.Add(rental);
            vehicle.Rent();

            return rental;
        }

        public void CompleteRental(string rentalId)
        {
            if (string.IsNullOrWhiteSpace(rentalId))
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            foreach (var rental in Rentals)
            {
                if (rental.ID == rentalId)
                {
                    rental.CompleteRental();
                }
            }
        }
        public List<Vehicle> GetAvailableVehicles() 
        {
            List<Vehicle> res = new();

            foreach (var v in Vehicles)
            {
                if (v.IsAvailable)
                {
                    res.Add(v);
                }
            }

            return res;
        }

        public List<Rental> GetActiveRentals()
        {
            List<Rental> res = new();

            foreach (var r in Rentals)
            {
                if (r.IsActive)
                {
                    res.Add(r);
                }
            }
            return res;
        }

        public List<Rental>? getCustomerRentals(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                Console.WriteLine("Invalid Or Empty Data !");
                return null;
            }

            List<Rental> res = new();

            foreach (var r in Rentals)
            {
                if (r.Customer.ID == customerId)
                {
                    res.Add(r);
                }
            }

            return res;
        }
        /*
         * V001 - 2022 Toyota Camry - $45.00/day - Rented
         * V002 - 2023 Honda Accord - $50.00/day - Available
         * V003 - 2023 Tesla Model 3 - $85.00/day - Rented
        */
        public string DisplayFleet()
        {
            var sb = new StringBuilder();

            foreach (var v in Vehicles)
            {
                string status = v.IsAvailable ? "Available" : "Rented";
                sb.AppendLine($"{v.ID} - {v.Year} {v.Make} {v.Model} - ${v.DailyRate}/day - {status}");
            }
            return sb.ToString();
        }
    }
}
