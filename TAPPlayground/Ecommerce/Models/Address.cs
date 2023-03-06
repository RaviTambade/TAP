namespace ECommerceApp.Models;
public class Address
{
    public int AddressId {get;set;}
    public int CustomerId {get;set;}

    public string? AddressMode{get;set;}

    public string? HouseNumber{get;set;}
    public string? Landmark{get;set;}
    public string? City{get;set;}
    public string? State{get;set;}
    public string? Country{get;set;}
    public string? PinCode{get;set;}
    public string FullAddress{
        get{
            return $"{HouseNumber},{Landmark},{City},{State},{Country},{PinCode}";
        }
    }
}