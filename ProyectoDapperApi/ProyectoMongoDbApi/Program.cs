using AutoMapper.Data;
using DrivenAdapterMongoDb;
using DrivenAdapterMongoDb.Interfaces;
using DrivenAdapterMongoDb.Pacientes;
using ProyectoMongoDbApi.AutoMapper;
using UseCases.CasosDeUso;
using UseCases.PuertaEntrada;
using UseCases.PuertaEntrada.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));
builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("DefaultConnection"), "test"));

builder.Services.AddScoped<IPacienteUseCase, PacienteCasoDeUso>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();

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
