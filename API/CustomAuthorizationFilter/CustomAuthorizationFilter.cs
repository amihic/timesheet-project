using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using TimeSheet.Domain.Model;

namespace API.CustomAuthorizationFilter
{
    public class CustomAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.DisplayName.Contains("Login"))
            {
                return;
            }

            //provera autentifikacije
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }

            var id = context.HttpContext.User.FindFirst("UserId")?.Value;
            var userId = int.Parse(id);

            LoggedInUser loggedInUser = new LoggedInUser();
            loggedInUser.Id = userId; 

            context.HttpContext.Items["UserId"] = loggedInUser;
        }
    }
}
