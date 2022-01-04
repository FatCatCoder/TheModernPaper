using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModernPaper.Middleware;

public class PaywallMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public PaywallMiddleware(RequestDelegate next, ILogger<PaywallMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // CookieOptions cookies =  new CookieOptions();
        // cookies.Expires = DateTime.Now.AddMinutes(1);
        // cookies.["ArticlesRead"] = "hi";
        
        var userip = context.Connection.RemoteIpAddress;  

        _logger.LogInformation("MIDDLEWARE HIT");
        // var builder = new StringBuilder(Environment.NewLine);

        // foreach (var header in context.Request.Headers)
        // {
        //     builder.AppendLine($"{header.Key}:{header.Value}");
        // }

        // _logger.LogInformation(builder.ToString());

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}

public static class PaywallMiddlewareExtensions
{
    public static IApplicationBuilder UsePaywall(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<PaywallMiddleware>();
    }
}