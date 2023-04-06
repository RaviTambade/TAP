using System.Text;

namespace ECommerceApp.Models;
 
 public class Cart
 {
     public List<Item> Items { get; set; }

     public void AddToCart(Item item)
    {
         Items.Add(item);
    }
     
     public  Cart()
     {
        this.Items=new List<Item>();
     }
 }