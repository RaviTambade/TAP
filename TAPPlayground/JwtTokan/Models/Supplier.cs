using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Http.Logging;

namespace ECommerceApp.Models;

public class Supplier{
    [Column("supplier_id")]
public int SupplierId{get;set;}
    [Column("company_name")]
public string CompanyName{get;set;}
    [Column("supplier_name")]
public string SupplierName{get;set;}
    [Column("contact_number")]
public string ContactNumber{get;set;}
public string Password{get;set;}

    [Column("email")]
public string Email{get;set;}
    [Column("address")]
public string Address{get;set;}
    [Column("city")]
public string City{get;set;}
    [Column("state")]
public string State{get;set;}
    [Column("account_number")]
public long AccountNumber{get;set;}



}