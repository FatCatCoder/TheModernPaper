using Microsoft.EntityFrameworkCore;
using ModernPaper.Contexts;
using ModernPaper.Models;
using ModernPaper.Services;
using ModernPaper.Data;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", opts => 
        opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Database
builder.Services.AddDbContext<ApplicationDbContext>(DbContextOptions =>
    DbContextOptions.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
    // DbContextOptions.UseNpgsql("Server=localhost;Port=5432;Database=ModernPaper;User Id=postgres;"));
  //DbContextOptions.UseInMemoryDatabase("TodoList"));

builder.Services.AddScoped<ArticleService>();

// Controllers
builder.Services.AddControllers()
.AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();


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

app.UseCors("AllowAll");

app.MapControllers();

// Seed Database if Empty
app.CreateDbIfNotExists();

app.Run();
