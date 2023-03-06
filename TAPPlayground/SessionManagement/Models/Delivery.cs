namespace SessionManagement.Models;
public class Delivery
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Landmark { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PinCode { get; set; }

}