
using Microsoft.EntityFrameworkCore;
using QST.ECommerce.API;
using QST.ECommerce.Application;
using QST.ECommerce.Application.Contracts;
using QST.ECommerce.Application.Services;
using QST.ECommerce.Infrastructure.DbContexts;
using QST.ECommerce.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString("ECommerceDatabase");
// EF Core 
builder.Services.AddDbContext<CatalogDbContext>(
    options =>
    {
        options.UseMySql(conStr, ServerVersion.AutoDetect(conStr));
    });

// Add services to the container.

builder.Services.AddScoped<ICatalogService, CatalogService>(); // Application Layer: This line will initialize Product Service which is inside Appliaction Layer
builder.Services.AddScoped<ICatalogRepository, CatalogRepository>(); // Infrastructure Layer

//builder.Services.AddScoped<IDepartmentService, DepartmentService>(); // This line will intialize the Object of DepartmentService through Constructor Injection
//builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>(); // Infrastructure Layer

//builder.Services.AddScoped<IBrandService, BrandService>(); // This line will intialize the Object of BrandService through Constructor Injection
//builder.Services.AddScoped<IBrandRepository, BrandRepository>(); // Infrastructure Layer

//builder.Services.AddScoped<ICategoryService, CategoryService>(); // This line will intialize the Object of CategoryService through Constructor Injection
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // Infrastructure Layer


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
