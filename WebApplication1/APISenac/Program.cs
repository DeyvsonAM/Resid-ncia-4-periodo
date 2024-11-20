using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;
using APISenac.Services;
using APISenac.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();

// Registra o Swagger
builder.Services.AddSwaggerGen();

// Obter a Connection String do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//Fazer função que usa Reflection para injetar todos os serviços (OBRIGATÔRIO)
// Registra os serviços de injeção de dependência
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<ISistemaService, SistemaService>();

// Adicionar suporte a controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
