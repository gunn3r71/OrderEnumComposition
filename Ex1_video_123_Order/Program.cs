using Ex1_video_123_Order.Entities;
using Ex1_video_123_Order.Entities.Enums;
using System;
using System.Globalization;

namespace Ex1_video_123_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ClientData
            Console.WriteLine("Enter the client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (dd/mm/yyyy): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            #endregion

            #region OrderData
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order: ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now,orderStatus,new Client(name,email,birthDate));
            #endregion

            #region OrderItem
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                order.AddItem(new OrderItem(quantity,price,new Product(productName,price)));
            }
            #endregion

            Console.WriteLine(order);
        }
    }
}
