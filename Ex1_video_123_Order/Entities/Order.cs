using Ex1_video_123_Order.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Ex1_video_123_Order.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Remove(orderItem);
        }

        public double Total()
        {
            double total = 0.0;
            foreach (OrderItem item in OrderItems)
            {
                total += item.SubTotal();
            }
            return total;
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            _ = @string.AppendLine("ORDER SUMARY: ");
            _ = @string.AppendLine();
            _ = @string.AppendLine("Order moment: " + Moment);
            _ = @string.AppendLine("Order status: " + Status.ToString());
            _ = @string.AppendLine($"Client: {Client.Name} ({Client.BirthDate.ToShortDateString()}) - {Client.Email}");
            _ = @string.AppendLine("Order items:");
            foreach  (OrderItem orderItem in OrderItems)
            {
                _ = @string.AppendLine($"{orderItem.Product.Name}, $ " +
                $"{orderItem.Product.Price.ToString("F2", CultureInfo.InvariantCulture)}" +
                $",Quantity: {orderItem.Quantity}, Subtotal: ${orderItem.SubTotal()}");
            }
            _ = @string.AppendLine($"Total price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            
            return @string.ToString();
        }
    }
}
