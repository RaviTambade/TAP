namespace ECommerceApp.Models;

public class Transaction
{
    public int TransactionId{get; set;}

    public long FromAccountNumber{get; set;}

    public long ToAccountNumber{get; set;}
    public string TransactionDate{get; set;}

    public double Amount{get; set;}

    public override string ToString()
    {
        return TransactionId + " " + FromAccountNumber + " " + ToAccountNumber + " " + TransactionDate + " " + Amount;
    }
}