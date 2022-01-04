using ModernPaper.Contexts;
using ModernPaper.Models;
using ModernPaper.Services;
using ModernPaper.Data;
using ModernPaper.Middleware;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;
using StackExchange.Redis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;





var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", opts => 
        opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(DbContextOptions =>
    DbContextOptions.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));

// builder.Services.AddScoped<ArticleService>();

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// -- Redis disabled while working on win7 due to unsupported version -- //

// Add Redis distributed cache
// builder.Services.AddStackExchangeRedisCache(options => options.Configuration = builder.Configuration.GetConnectionString("RedisConnection"));
// builder.Services.AddStackExchangeRedisCache(opt => 
//     opt.Configuration = "localhost:6379");

// InMemory distributed cache Testing
builder.Services.AddDistributedMemoryCache();

// Res cache middleware
builder.Services.AddResponseCaching();

// cookie sessions
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromSeconds(10);
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
// });

// logging
builder.Services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = HttpLoggingFields.All;
        logging.RequestHeaders.Add("My-Request-Header");
        logging.ResponseHeaders.Add("My-Response-Header");
        logging.MediaTypeOptions.AddText("application/javascript");
        logging.RequestBodyLogLimit = 4096;
        logging.ResponseBodyLogLimit = 4096;
    });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
 else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpLogging();
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
// app.UseSession();
// app.UseResponseCompression();
// app.UseResponseCaching();
app.UsePaywall();
app.MapControllers();

// Seed Database if Empty
app.CreateDbIfNotExists();
app.Run();
