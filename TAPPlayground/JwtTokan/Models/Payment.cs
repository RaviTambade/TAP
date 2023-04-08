namespace ECommerceApp.Models;

public class Payment{
    internal int payments;

    public int PaymentId{get;set;}
    public string? PaymentDate{get;set;}
    public string? PaymentMode{get;set;}

    public int TransactionId{get;set;}
    
    public int OrderId{get;set;}
}