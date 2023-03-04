namespace SessionManagement.Models;

public class Product{
    public int Id {get;set;}

    public String? Title{get;set;}
    public String? Description{get;set;}

    public int StockAvailable{get;set;}

    public double UnitPrice{get;set;}
    
    public string? Image{get; set;}

}