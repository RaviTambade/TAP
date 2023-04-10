namespace CatalogService.Models;
public class Supplier
{
    public int SupplierId { get; set; }
    public string CompanyName { get; set; }
    public string SupplierName { get; set; }
    public string ContactNumber { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public long AccountNumber { get; set; }
}