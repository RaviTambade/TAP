using System.Text;
namespace ShoppingCartService.Models;
public class Item
{
    public int  ProductId {get;set;}
    public string?  ProductTitle {get;set;}
    public string?  ImageURL {get;set;}
    public int Quantity {get;set;}
    public double UnitPrice {get;set;}
}