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

        public double CalculateRentalCost(int days) 
        {
            return DailyRate * days;
        }
        public string GetVehicleInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine("======================");
            sb.AppendLine($"({ID}) | {Model} - {Make} | {Year} | DailyRate: {DailyRate} | Status: {IsAvailable}");
            sb.AppendLine("======================");

            return sb.ToString();
        }
    }
}
