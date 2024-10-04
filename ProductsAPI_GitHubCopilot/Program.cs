using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductsAPI_GitHubCopilot.Application.Interfaces;
using ProductsAPI_GitHubCopilot.Application.Services;
using ProductsAPI_GitHubCopilot.Domain.Interfaces;
using ProductsAPI_GitHubCopilot.Infra.DataContext;
using ProductsAPI_GitHubCopilot.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework Core para usar SQL Server com a string de conex�o "ProductConnection"
builder.Services.AddDbContext<ProductsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));

// Registrar servi�os no container de inje��o de depend�ncia
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Configurar ASP.NET Core para usar controladores e APIs
builder.Services.AddControllers();

// Adicionar e configurar Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
});

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
