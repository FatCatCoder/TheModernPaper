using Microsoft.EntityFrameworkCore;
using ModernPaper.Contexts;
using ModernPaper.Models;
using ModernPaper.Services;
using ModernPaper.Data;
using Microsoft.AspNetCore.HttpLogging;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

// Add services to the container.
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

// cache
builder.Services.AddDistributedMemoryCache();

// cookies
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

    // app.UseSwagger();
    // app.UseSwaggerUI();
}
 else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpLogging();

app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.UseCors("AllowAll");

app.MapControllers();

// Seed Database if Empty
app.CreateDbIfNotExists();

app.Run();
