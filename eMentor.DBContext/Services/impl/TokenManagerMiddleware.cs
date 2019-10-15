using eMentor.Common.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Net;
using System.Threading.Tasks;

namespace eMentor.DBContext.Services.impl
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenManager _tokenManager;

        public TokenManagerMiddleware(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(context.Request.Headers["authorization"] == StringValues.Empty || Constants.ActionAllowAnonymous.Contains(context.Request.Path.ToUriComponent()))
            {
                await next(context);

                return;
            }
         
            if (await _tokenManager.IsCurrentActiveToken())
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
