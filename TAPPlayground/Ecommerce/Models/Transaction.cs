namespace ECommerceApp.Models;

public class Transaction
{
    public int TransactionId{get; set;}

    public long FromAccountNumber{get; set;}

    public long ToAccountNumber{get; set;}
    public DateTime TransactionDate{get; set;}

    public double Amount{get; set;}
}