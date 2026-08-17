using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            return Vehicle.CalculateRentalCost(GetRentalDuration()) + 150;
        }

        public void CompleteRental() 
        {
            Vehicle.ReturnVehicle();
            IsActive = true;
        }

        public string GetRentalInfo() 
        {
            var sb = new StringBuilder();
            sb.AppendLine("===============");
            sb.AppendLine($"RentalID: {ID}");
            sb.AppendLine($"Name: {Customer.Name}");
            sb.AppendLine($"VehicleID: {Vehicle.ID}");
            sb.AppendLine($"StartDate: {StartDate}");
            string cost = (GetTotalCost() > 0) ? $"{GetTotalCost()}" : "No Costs Yet";
            sb.AppendLine($"Cost: {cost}");
            sb.AppendLine($"Status: {IsActive}");
            sb.AppendLine("===============");
            return sb.ToString();
        }

        public void GenerateReceipts() 
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "Rental Receipt.txt");

            File.WriteAllText(filePath, GetRentalInfo());
        }
    }
}
