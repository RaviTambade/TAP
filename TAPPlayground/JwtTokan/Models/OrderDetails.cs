
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models;

public class OrderDetails
{
    [Column("orderdetails_id")]
    public int OrderDetailsId { get; set; }

    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("discount")]
    public double Discount { get; set; }


}