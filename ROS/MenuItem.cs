using System;
using System.Collections.Generic;
using System.Text;

namespace ROS
{
    internal class MenuItem
    {
        public string? ItemID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public MenuItem(string? itemID, string? name, string? description, string? category, decimal price, bool isAvailable)
        {
            ItemID = itemID;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            IsAvailable = isAvailable;
        }

        public string GetItemInfo() 
        {
            var sb = new StringBuilder();

            sb.AppendLine($"I-ID({ItemID})");
            sb.AppendLine($"-------------");
            sb.AppendLine($"Name : {Name}");
            sb.AppendLine($"Desc : {Description}");
            sb.AppendLine($"Category : {Category}");
            sb.AppendLine($"Price : {Price:C2}");
            sb.AppendLine($"Availability : {IsAvailable}");

            return sb.ToString();
        }
    }
}
