using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace VRS
{
    internal class Rental
    {
        public string ID { get; set; }
        public double LateFee { get; set; }
        public Customer Customer { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public bool HasInsurance { get; set; }
        public double InsuranceDailyRate { get; set; } = 15.0;

        public Rental(string id, Customer customer, Vehicle vehicle, DateTime endDate, bool hasInsurance = false)
        {
            ID = id;
            Customer = customer;
            Vehicle = vehicle;
            StartDate = DateTime.Now;
            EndDate = endDate;
            IsActive = true;
            HasInsurance = hasInsurance;
        }

        public double CalculateInsuranceFees() => HasInsurance ? GetRentalDuration() * InsuranceDailyRate : 0.0;

        public int GetRentalDuration() => (int)Math.Ceiling((EndDate - StartDate).TotalDays);

        public double GetTotalCost() => Vehicle.CalculateRentalCost(GetRentalDuration()) + CalculateInsuranceFees() + LateFee;

        public void CompleteRental(DateTime? actualReturnDate = null)
        {
            DateTime returnDate = actualReturnDate ?? DateTime.Now;

            if (returnDate > EndDate)
            {
                int lateDays = (int)Math.Ceiling((returnDate - EndDate).TotalDays);

                LateFee = (Vehicle.DailyRate * 1.5) * lateDays; 
            }

            Vehicle.ReturnVehicle();
            IsActive = false;
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
