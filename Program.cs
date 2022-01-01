using Microsoft.EntityFrameworkCore;
using ModernPaper.Contexts;
using ModernPaper.Models;
using ModernPaper.Services;
using ModernPaper.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Database
builder.Services.AddDbContext<ApplicationDbContext>(DbContextOptions =>
    DbContextOptions.UseNpgsql("Server=localhost;Port=5432;Database=ModernPaper;User Id=postgres;"));
  //DbContextOptions.UseInMemoryDatabase("TodoList"));

builder.Services.AddScoped<ArticleService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed Database if Empty
app.CreateDbIfNotExists();

app.Run();
