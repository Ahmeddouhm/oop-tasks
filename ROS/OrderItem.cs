using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ROS
{
    internal class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public string Special_Instructions { get; set; }

        public OrderItem(MenuItem menuItem, int quantity, string special_Instructions)
        {
            MenuItem = menuItem;
            Quantity = quantity;
            Special_Instructions = special_Instructions;
        }

        public decimal GetSubtotal() => Quantity * MenuItem.Price;

        public string GetOrderItemDetails() 
        {
            //var sb = new StringBuilder();

            //sb.AppendLine($"O-ID({ItemID})");
            //sb.AppendLine($"-------------");
            //sb.AppendLine($"Name : {Name}");
            //sb.AppendLine($"Desc : {Description}");
            //sb.AppendLine($"Category : {Category}");
            //sb.AppendLine($"Price : {Price:C2}");
            //sb.AppendLine($"Availability : {IsAvailable}");

            // IAM NOT SURE OF THIS IMPLEMENTATION
            return MenuItem.GetItemInfo();
        }
    }
}
