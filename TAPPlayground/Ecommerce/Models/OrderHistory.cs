namespace ECommerceApp.Models;
public class OrderHistory
{
    private int quantity;
    private double unitPrice;

    public string Title { get; set; }
    public double UnitPrice { get => unitPrice; set => unitPrice = value; }
    public int Quantity { get => quantity; set => quantity = value; }
    public DateTime OrderDate { get; set; }
    public double TotalAmmount{
        get{return unitPrice*quantity;}
    }
}