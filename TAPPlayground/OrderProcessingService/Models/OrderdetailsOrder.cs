namespace OrderProcessingService.Models;

public class OrderDetailsOrder{

    public int OrderId{get;set;}
    public string? ProductTitle{get;set;}
    public int Quantity{get;set;}
    public double UnitPrice{get;set;}
    public double TotalAmount{get;set;}
}