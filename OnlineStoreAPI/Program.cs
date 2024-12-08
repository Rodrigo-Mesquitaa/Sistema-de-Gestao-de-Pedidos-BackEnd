using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Repositories;
using OnlineStoreAPI.Services;
using Microsoft.OpenApi.Models;
using OnlineStoreAPI.Date; 

var builder = WebApplication.CreateBuilder(args);

// Configurar a string de conexão
builder.Services.AddDbContext<OnlineStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineStoreDatabase")));

// Adicionar serviços
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OnlineStoreAPI",
        Version = "v1"
    });
});

var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Adicionando o middleware do Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online Store API v1");
        c.RoutePrefix = string.Empty; // Acesse o Swagger UI na raiz do aplicativo
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();