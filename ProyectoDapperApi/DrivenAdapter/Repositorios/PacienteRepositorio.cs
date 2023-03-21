using Dapper;
using DrivenAdapter.PuertaEnlace;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.PuertaEntrada.Repositorio;

namespace DrivenAdapter.Repositorios
{
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "pacientes";

        public PacienteRepositorio(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<List<Paciente>> ObtenerListaPacientes()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Paciente>(sqlQuery);
            connection.Close();
            return result.ToList();
        }

        public async Task<Paciente> AgregarPaciente(Paciente paciente)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var agregarPaciente = new
            {
                nombre = paciente.Nombre,
                fecha = paciente.Fecha_Nacimiento,
                premios = paciente.Sexo,
            };
            string sqlQuery = $"INSERT INTO {tableName} (nombre, fecha_nacimiento, sexo)VALUES(@nombre, @fecha, @sexo)";
            var rows = await connection.ExecuteAsync(sqlQuery, agregarPaciente);
            return paciente;
        }


    }
}
