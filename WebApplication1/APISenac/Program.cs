using APISenac.Data;
using Microsoft.EntityFrameworkCore;
using APISenac.Models;
using Microsoft.AspNetCore.Mvc;

using APISenac.Services;
using APISenac.Services.Interfaces;
using APISenac.Data.DataContracts;
using System.Reflection;




var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();

// Registra o Swagger
builder.Services.AddSwaggerGen();

// Obter a Connection String do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<APISenac.Data.DataContracts.IUnitOfWork, APISenac.Data.UnitOfWork>();
//Fazer função que usa Reflection para injetar todos os serviços (OBRIGATÔRIO)
// Registra os serviços de injeção de dependência
var assembly = Assembly.GetExecutingAssembly();

// Registrar serviços dinamicamente usando reflexão
builder.Services.Scan(scan => scan
    .FromAssemblyOf<SistemaService>()  // A partir de uma classe concreta no mesmo assembly (SistemaService é um exemplo)
    .AddClasses(classes => classes.AssignableTo(typeof(IBaseService<>)))  // Filtra as classes que implementam BaseService<T>
    .AsImplementedInterfaces()  // Registra a classe como suas interfaces implementadas
    .WithScopedLifetime());  // Registra o ciclo de vida como Scoped
    

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
