using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace TechnicalRadiation.WebApi.CustomAttributes
{
    public class ApiKeyAuthorization : Attribute, IAuthorizationFilter
    {
        private static readonly string _apiKey = "admin";
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues authentication;
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out authentication);
            if(authentication != _apiKey) { context.Result = new StatusCodeResult(401); }
        }
    }
}