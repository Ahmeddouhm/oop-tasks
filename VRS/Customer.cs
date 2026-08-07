using System;
using System.Collections.Generic;
using System.Text;

namespace VRS
{
    internal class Customer
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? DriversLicenseNumber { get; set; }

        public Customer(string id,string name,string phoneNumber,string email,string driverLicenseNumber)
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            DriversLicenseNumber = driverLicenseNumber;
        }

        public string GetCustomerInfo() 
        {
            var sb = new StringBuilder();

            return sb.ToString();
        }
    }
}
