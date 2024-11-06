using Agenda.API.Data;
using Agenda.API.Services;
using Agenda.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
//var cultureInfo = new CultureInfo("pt-BR");
//CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
//CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseInMemoryDatabase("AgendaDB")); // Use InMemoryDatabase para simplificação

builder.Services.AddControllers();
builder.Services.AddScoped<IAgendaService, AgendaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Agenda API", Version = "v1" });
});

var app = builder.Build();

// Initialize the AgendaService
using (var scope = app.Services.CreateScope())
{
    var agendaService = scope.ServiceProvider.GetRequiredService<IAgendaService>() as AgendaService;
    agendaService?.Initialize();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
