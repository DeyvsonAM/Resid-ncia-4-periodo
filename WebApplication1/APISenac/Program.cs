using APISenac.Data;
using Microsoft.EntityFrameworkCore;
using APISenac.Services;
using APISenac.Services.Interfaces;
using APISenac.Data.DataContracts;
using System.Reflection;
using APISenac.Middlewares;
using APISenac.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;







var builder = WebApplication.CreateBuilder(args);



// Obter a Connection String do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adicionar serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();

// Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "APISenac",
            ValidAudience = "APISenac.Client",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789")),
        };
    });

builder.Services.AddAuthorization();

// Registra o Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
   // Registra a implementação de IRepositor
 

var assembly = Assembly.GetExecutingAssembly();

// Registrar serviços dinamicamente usando reflexão
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ProfileService>()  // A partir de uma classe concreta no mesmo assembly (SistemaService é um exemplo)
    .AddClasses(classes => classes.AssignableTo(typeof(IBaseService<>)))  // Filtra as classes que implementam BaseService<T>
    .AsImplementedInterfaces()  // Registra a classe como suas interfaces implementadas
    .WithScopedLifetime());  // Registra o ciclo de vida como Scoped

builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<TwoFactorAuthenticationService>();

// Adicionar suporte a controllers
builder.Services.AddControllers();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
