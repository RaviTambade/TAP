namespace PaymentProcessingService.Models;
public class Payment{
    public int PaymentId{get;set;}
    public DateTime PaymentDate{get;set;}
    public string? PaymentMode{get;set;}
    public int TransactionId{get;set;} 
    public int OrderId{get;set;}

    
}