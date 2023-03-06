namespace SessionManagement.Models;
public class PaymentDetails{
    public string Owner{get;set;}
    public string CreditCardNumber{get;set;}
    public int CVV{get;set;}
    public DateOnly ExpiryDate{get;set;}
}