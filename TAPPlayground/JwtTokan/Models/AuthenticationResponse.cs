
namespace ECommerceApp.Models

{

    public class AuthenticateResponse{

     public int UserId {get;set;}

     public string Email{get;set;}

     public string ContactNumber{get;set;}

     public string Password{get;set;}


     public string Token {get;set;}



    public AuthenticateResponse(User user, string token){
      UserId =user.UserId;
      Email= user.Email;
      Password=user.Password;
      ContactNumber=user.ContactNumber;
      Token=token;
    }

    }
    
}