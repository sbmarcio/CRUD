using CRUD.Application.Behaviors;
using CRUD.Application.Commands.CreateCliente;
using CRUD.Application.Validators;
using CRUD.Domain.Interfaces;
using CRUD.Infrastructure.Data.Context;
using CRUD.Infrastructure.Data.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 💾 Banco de Dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🧩 Injeção de dependência
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// 🧠 MediatR + FluentValidation
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClienteCommand).Assembly));
builder.Services.AddValidatorsFromAssemblyContaining<CreateClienteCommandValidator>();

// Pipeline behavior para validar comandos automaticamente
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// 🌐 API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUD API", Version = "v1" });
});

var app = builder.Build();

// 🌍 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



