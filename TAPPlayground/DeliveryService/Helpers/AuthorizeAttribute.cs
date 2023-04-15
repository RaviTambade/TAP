
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DeliveryService.Models;

namespace DeliveryService.Helpers
{


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]


    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {

        public string Roles { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            List<string> userRoles = (List<string>)context.HttpContext.Items["userRoles"];
            bool status = false;

            if (this.Roles != null && userRoles != null)
            {
                List<string> requiredRoles = this.Roles.Split(',').ToList();
                bool result = requiredRoles.Intersect(userRoles).Count() >= 1;
                if (result)
                {
                    status = true;
                }
            }

            if (status == false)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

            }
        }
    }
}