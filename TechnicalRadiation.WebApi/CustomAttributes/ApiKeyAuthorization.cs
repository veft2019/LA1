using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace TechnicalRadiation.WebApi.CustomAttributes
{
    public class ApiKeyAuthorization : ActionFilterAttribute
    {
        private static readonly string _serverApiKey = "admin";
        
        public override void OnActionExecuting(ActionExecutingContext context) {
            StringValues clientAuthorization;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out clientAuthorization);
            if(clientAuthorization != _serverApiKey) { context.Result = new StatusCodeResult(401); }
        }
    }
}