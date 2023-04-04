using System.ComponentModel.DataAnnotations;

namespace JwtTokan.Models
{

    public class AuthenticateRequest{

      [Required]
       public string Email {get;set;}

      [Required]
       public string Password{get;set;}

    }
}