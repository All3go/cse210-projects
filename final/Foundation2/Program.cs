using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Boise", "ID", "USA");
        Address address2 = new Address("456 Maple Rd", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Austin Linford", address1);
        Customer customer2 = new Customer("Sophie Lee", address2);

        Product product1 = new Product("Laptop", "L001", 999.99, 1);
        Product product2 = new Product("Mouse", "M101", 25.50, 2);
        Product product3 = new Product("Keyboard", "K202", 45.00, 1);
        Product product4 = new Product("Monitor", "MN303", 199.99, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.GetTotalCost());
        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order2.GetTotalCost());
    }
}
