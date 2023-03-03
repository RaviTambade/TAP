namespace SessionManagement.Models;

public class Address
{
    public int Id{get; set;}

    public int CustId{get; set;}

    public string HouseNo{get; set;}

    public string Landmark {get; set;}

    public string City{get; set;}

    public string State{get; set;}

    public string Country{get; set;}

    public string Pincode{get; set;}
}