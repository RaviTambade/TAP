using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Http.Logging;

namespace ECommerceApp.Models;

public class Supplier{
public int SupplierId{get;set;}
public string CompanyName{get;set;}
public string SupplierName{get;set;}
public string ContactNumber{get;set;}
public string Email{get;set;}
public string Address{get;set;}

public string City{get;set;}
public string State{get;set;}
public long AccountNumber{get;set;}


}