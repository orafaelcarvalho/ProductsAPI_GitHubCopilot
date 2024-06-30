using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsAPI_GitHubCopilot.Domain.Interfaces;
using ProductsAPI_GitHubCopilot.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlServer("server=localhost;database=products_githubcopilot;user id=sa;password=123456;trustservercertificate=true;"));

// adicionar a injeção de dependência das interfaces e classes de serviço iProductService / ProductService e ISupplierService / SupplierService
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

// configurar automapper
MapperConfiguration config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ProductDTO, Product>().ReverseMap();
    cfg.CreateMap<SupplierDTO, Supplier>().ReverseMap();
    cfg.CreateMap<ProductUpdateModel, Product>().ReverseMap();
    cfg.CreateMap<SupplierUpdateModel, Supplier>().ReverseMap();
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DataContext>(ServiceLifetime.Transient);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
