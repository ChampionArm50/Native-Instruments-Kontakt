using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public string Customer { get; set; }
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

    public Order(string customer, string product, int quantity, decimal price)
    {
        Customer = customer;
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    public decimal Total => Quantity * Price;
}

class OrderManager
{
    private readonly List<Order> orders = new();

    public void AddOrder(string customer, string product, int quantity, decimal price)
    {
        orders.Add(new Order(customer, product, quantity, price));
    }

    public decimal GetTotalRevenue()
    {
        return orders.Sum(order => order.Total);
    }

    public void SortByTotal()
    {
        orders.Sort((a, b) => b.Total.CompareTo(a.Total));
    }

    public void PrintReport()
    {
        Console.WriteLine("Order Report");
        Console.WriteLine("============");

        foreach (var order in orders)
        {
            Console.WriteLine(
                $"{order.Customer} | {order.Product} | " +
                $"{order.Quantity} units | ${order.Price:F2} | " +
                $"Total: ${order.Total:F2}"
            );
        }

        Console.WriteLine("============");
        Console.WriteLine($"Orders: {orders.Count}");
        Console.WriteLine($"Total Revenue: ${GetTotalRevenue():F2}");
        Console.WriteLine(
            $"Average Order: ${GetTotalRevenue() / orders.Count:F2}"
        );
    }
}

class Program
{
    static void Main()
    {
        var manager = new OrderManager();

        manager.AddOrder("Alice", "Laptop", 2, 899.99m);
        manager.AddOrder("Brian", "Keyboard", 4, 79.50m);
        manager.AddOrder("Clara", "Monitor", 3, 249.99m);
        manager.AddOrder("David", "Headphones", 5, 129.99m);

        manager.SortByTotal();
        manager.PrintReport();
    }
}