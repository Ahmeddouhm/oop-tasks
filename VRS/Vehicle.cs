using System;
using System.Collections.Generic;
using System.Text;

namespace VRS
{
    internal class Vehicle
    {
        public string? ID { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public double DailyRate { get; set; }
        public bool IsAvailable { get; set; }

        public Vehicle(string id, string make, string model, int year, double dailyrate)
        {
            ID = id;
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyrate;
            IsAvailable = true;
        }


        public void Rent() 
        {
            IsAvailable = false;
        }

        public void ReturnVehicle() 
        {
            IsAvailable = true;
        }

        public virtual double CalculateRentalCost(int days) 
        {
            double totalCost = DailyRate * days;

            if (days > 15)
            {
                double discount = 0.15;
                totalCost -= (totalCost * discount);
            }

            return totalCost;
        }
        public virtual string GetVehicleInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine("======================");
            sb.AppendLine($"({ID}) | {Model} - {Make} | {Year} | DailyRate: {DailyRate} | Status: {IsAvailable}");
            sb.AppendLine("======================");

            return sb.ToString();
        }
    }

    class SUV : Vehicle 
    {
        public SUV(string id, string make, string model, int year, double dailyrate) : base(id,make,model,year,dailyrate)
        {
            
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            return baseCost + 55;
        }

        public override string GetVehicleInfo()
        {
            
            return "[SUV]" + base.GetVehicleInfo();
        }
    }
    class Truck : Vehicle 
    {
        public Truck(string id, string make, string model, int year, double dailyrate) : base(id,make,model,year,dailyrate)
        {
            
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = base.CalculateRentalCost(days);
            return baseCost + (days*20);
        }
        public override string GetVehicleInfo()
        {
            
            return "[Truck]" + base.GetVehicleInfo();
        }
    }
    class Luxury : Vehicle 
    {
        public Luxury(string id, string make, string model, int year, double dailyrate) : base(id,make,model,year,dailyrate)
        {
            
        }

        public override double CalculateRentalCost(int days)
        {
            double baseCost = days * DailyRate;
            return baseCost + (baseCost * 0.20);
        }
        public override string GetVehicleInfo()
        {
            
            return "[Luxury]" + base.GetVehicleInfo();
        }
    }
}
