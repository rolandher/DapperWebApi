using UseCases.PuertaEntrada;
using UseCases.CasosDeUso;
using UseCases.PuertaEntrada.Repositorio;
using DrivenAdapter.Repositorios;
using ProyectoDapperApi.Automapper;
using DrivenAdapter.PuertaEnlace;
using DrivenAdapter;
using ProyectoDapperApi.ErrorHandleMiddleware;
using AutoMapper.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(PerfilConfiguracion));

builder.Services.AddScoped<IPacienteUseCase, PacienteCasoDeUso>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();



builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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

app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();
