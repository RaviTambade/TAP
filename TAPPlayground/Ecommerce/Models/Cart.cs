namespace ECommerceApp.Models;
public class Cart
{
    public List<Product> Products { get; set; }

    public void RemoveProduct(Product product)
    {
        Products.Remove(product);
    }
     
    
    public double TotalAmount
    {
        get { return Products.Sum(p => p.BuyQuantity * p.UnitPrice); }
    }


}