using System;
using System.Collections.Generic;
using System.Text;

namespace VRS
{
    internal class Rental
    {
        public string ID { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public Rental(string id, Customer customer, Vehicle vehicle, DateTime endDate)
        {
            ID = id;
            Customer = customer;
            Vehicle = vehicle;
            StartDate = DateTime.Now;
            EndDate = endDate;
            IsActive = true;
        }

        public int GetRentalDuration() 
        {
            return (EndDate - StartDate).Days;
        }

        public double GetTotalCost() 
        {
            return Vehicle.CalculateRentalCost(GetRentalDuration()) + 250;
        }

        public void CompleteRental() 
        {
            Vehicle.ReturnVehicle();
            IsActive = true;
        }

        public string GetRentalInfo() 
        {
            var sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
