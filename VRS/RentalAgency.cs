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
        
        }

        public void RegisterCustomer(Customer customer) { }


        public void CreateRental(Customer customer, Vehicle vehicle, int days)
        {

        }

        public void CompleteRental(string rentalId)
        {

        }
        public List<Vehicle> GetAvailableVehicles() 
        {
            List<Vehicle> res = new();

            return res;
        }

        public List<Rental> GetActiveRentals()
        {
            List<Rental> res = new();

            return res;
        }

        public List<Customer> getCustomerRentals(string customerId)
        {
            List<Customer> res = new();

            return res;
        }

        public string DisplayFleet()
        {
            var sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
