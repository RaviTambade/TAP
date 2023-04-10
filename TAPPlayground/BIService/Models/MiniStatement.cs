namespace BIService.Models;

public class MiniStatement
{
    public int CustomerId{get; set;}
    public string? CustomerFirstName{get; set;}
    public string? CustomerLastName{get; set;}
    public double Amount{get; set;}
    public DateTime TransactionDate{get; set;}
    public string? ModeType{get; set;}
}