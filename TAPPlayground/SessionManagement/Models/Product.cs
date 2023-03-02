namespace SessionManagement.Models;

public class Product{
    public int Id {get;set;}

    public String? Name{get;set;}
    public String? Description{get;set;}

    public double Price{get;set;}

    public int Count{get;set;}
    
    public int TotalQuantity{get; set;}

    public int AvailableQuantity{get; set;}

    public int SellQuantity{get; set;}

}