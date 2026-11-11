using System;
using System.Collections.Generic;
using System.Text;

namespace ROS
{
    enum OrderStatus
    {
        Pending,
        Preparing,
        Ready,
        Served,
        Completed
    }
    internal class Order
    {
        public string OrderId { get; set; }
        public int TableNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public DateTime OrderTime { get; set; }
        public OrderStatus Status { get; set; }

        public Order(string orderId, int tableNumber, DateTime orderTime, OrderStatus status)
        {
            OrderId = orderId;
            TableNumber = tableNumber;
            OrderTime = orderTime;
            Status = status;
        }
    }
}
