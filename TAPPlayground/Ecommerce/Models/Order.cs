namespace ECommerceApp.Models;

public class Order
{
    public int OrderId{get;set;}
    public string? OrderDate{get;set;}

    public string? ShippedDate{get; set;}
    public int CustomerId{get;set;}

    public double Total{get; set;}
    public string? Status{get;set;}

}