using APISenac.Data;
using Microsoft.EntityFrameworkCore;
using APISenac.Services;
using APISenac.Services.Interfaces;
using APISenac.Data.DataContracts;
using System.Reflection;
using APISenac.Middlewares;




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

builder.Services.AddScoped<APISenac.Data.DataContracts.IUnitOfWork, UnitOfWork>();


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

app.UseMiddleware<ExceptionMiddleware>();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
