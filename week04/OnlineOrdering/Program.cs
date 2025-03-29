using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetProductInfo()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += product.GetProductInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "L123", 800, 1));
        order1.AddProduct(new Product("Mouse", "M456", 25, 2));
        order1.AddProduct(new Product("Keyboard", "K789", 45, 1));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MO111", 200, 2));
        order2.AddProduct(new Product("USB Cable", "U222", 10, 5));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}\n");
        }
    }
}
