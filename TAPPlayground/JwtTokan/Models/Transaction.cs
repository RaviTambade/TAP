using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerceApp.Models;

public class Transaction
{
    internal object transactionId;

    [Column("transaction_id")]
    public int TransactionId{get; set;}
    [Column("from_account_number")]
    public long FromAccountNumber{get; set;}
    [Column("to_account_number")]
    public long ToAccountNumber{get; set;}
    [Column("transaction_date")]
    public string? TransactionDate{get; set;}
    [Column("amount")]
    public double Amount{get; set;}

}