using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // -----------------------------
        // ORDER 1 - USA CUSTOMER
        // -----------------------------

        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "P001",
            800.00,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "P002",
            25.00,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "P003",
            50.00,
            1
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // -----------------------------
        // ORDER 2 - INTERNATIONAL CUSTOMER
        // -----------------------------

        Address address2 = new Address(
            "15 Independence Avenue",
            "Accra",
            "Greater Accra",
            "Ghana"
        );

        Customer customer2 = new Customer(
            "Bright Yaw",
            address2
        );

        Order order2 = new Order(customer2);

        Product product4 = new Product(
            "Monitor",
            "P004",
            300.00,
            1
        );

        Product product5 = new Product(
            "USB Cable",
            "P005",
            10.00,
            3
        );

        Product product6 = new Product(
            "Webcam",
            "P006",
            75.00,
            1
        );

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        // -----------------------------
        // DISPLAY ORDER 1
        // -----------------------------

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("========================================");

        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine(
            $"Total Cost: ${order1.GetTotalCost():F2}"
        );

        Console.WriteLine();


        // -----------------------------
        // DISPLAY ORDER 2
        // -----------------------------

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("========================================");

        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine(
            $"Total Cost: ${order2.GetTotalCost():F2}"
        );
    }
}