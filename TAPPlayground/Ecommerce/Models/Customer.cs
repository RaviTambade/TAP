using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Models;
public class Customer{
    public int CustomerId{get;set;}
    [Required(ErrorMessage ="please enter name")]
    public string? FirstName{get;set;}
     [Required(ErrorMessage ="please enter name")]
    public string? LastName{get;set;}    
     [Required(ErrorMessage ="please enter name")]
    public string? Email{get;set;}
     [Required(ErrorMessage ="please enter name")]
    public string? ContactNumber{get;set;}
     [Required(ErrorMessage ="please enter name")]
    public string? Password{get;set;}
}