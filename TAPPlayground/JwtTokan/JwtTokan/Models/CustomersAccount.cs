namespace ECommerceApp.Models;
public class CustomerAccount{
    public int CustomerId{get;set;}
    public string FirstName{get;set;}
    public string LastName{get;set;}
    public string Email{get;set;}
    public string ContactNumber{get;set;}
    public long AccountNumber{get;set;}
    public string IFSCCode{get;set;}
    public double AccountBalance{get;set;}
}