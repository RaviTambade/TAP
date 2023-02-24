namespace E_AgroServiceDemo.Models;
public class Farmer{
    public int FarmerId{get;set;}
    public string FarmerName{get;set;}
    public string ContactNumber{get;set;}
    public string Location{get;set;}
    public string Password{get;set;}
    public long CreditedAmount{get;set;}
    public long DebitedAmount{get;set;}
    public long Balance{get;set;}

}