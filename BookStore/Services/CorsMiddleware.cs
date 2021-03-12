using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CorsMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task Invoke(HttpContext httpContext)
        {
            string domainName = $"https://{_httpContextAccessor.HttpContext.Request.Host.Host}";
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", domainName);
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET");
            httpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must - revalidate");
            httpContext.Response.Headers.Add("Pragma", "no-cache");
            httpContext.Response.Headers.Add("Age", "0");

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-XSS-Protection
            httpContext.Response.Headers.Add("x-xss-protection", new StringValues("1; mode=block"));

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Content-Type-Options
            httpContext.Response.Headers.Add("x-content-type-options", new StringValues("nosniff"));
            // https://security.stackexchange.com/questions/166024/does-the-x-permitted-cross-domain-policies-header-have-any-benefit-for-my-websit
            httpContext.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", new StringValues("none"));

            //httpContext.Response.Headers.Add("Referrer-Policy", "no-referrer");
            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referrer-Policy
            // TODO Change the value depending of your needs
            httpContext.Response.Headers.Add("referrer-policy", new StringValues("strict-origin-when-cross-origin"));

            // https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/X-Frame-Options
            //Antiforgery Added that part 
            httpContext.Response.Headers.Add("x-frame-options", new StringValues("SAMEORIGIN"));

            return _next(httpContext);
        }
    }

    public static class CorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}