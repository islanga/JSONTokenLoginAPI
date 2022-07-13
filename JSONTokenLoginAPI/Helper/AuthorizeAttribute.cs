using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JSONTokenLoginAPI.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"];
            if (user == null)
            {
                // user not logged in
                context.Result = new JsonResult(new
                {
                    message = "Unauthorized"
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
