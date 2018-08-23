using System;
using System.Linq;
using System.Collections.Generic;


// Build a collection of customers who are millionaires
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}
public class GroupedMillionaires {
    public string Bank { get; set; }
    public IEnumerable<string> Millionaires { get; set; }
}


public class Program
{
    public static void Main() {
        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };
    var groupedByBank = customers.Where(c => c.Balance >= 1000000).GroupBy(
        p => p.Bank,
        p => p.Name,
        (bank, millionaires) => new GroupedMillionaires()
        {
            Bank = bank,
            Millionaires = millionaires
        }
    ).ToList();

    foreach (var i in groupedByBank)
    {
        Console.WriteLine($"{i.Bank}: {string.Join(" and ", i.Millionaires.Count())}");
    }


    }
}