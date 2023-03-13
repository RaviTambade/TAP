using System;

namespace ECommerceApp.Models;
public class Account
{
    public int AccountId{get;set;}
    public string AccountNumber{get;set;}
    public string IFCCode{get;set;}
    public DateTime RegisterDate{get;set;}
    public double Balance{get;set;}
}