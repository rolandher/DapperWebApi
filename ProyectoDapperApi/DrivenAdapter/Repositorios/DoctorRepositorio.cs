using Dapper;
using DrivenAdapter.PuertaEnlace;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.PuertaEntrada.Repositorio;

namespace DrivenAdapter.Repositorios
{
    public class DoctorRepositorio : IDoctorRepositorio
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Doctores";

        public DoctorRepositorio(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<Doctor> AgregarDoctor(Doctor doctor)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var agregarDoctor = new
            {
                nombre_doctor = doctor.Nombre_Doctor,
                correo = doctor.Correo,
                direccion = doctor.Direccion
            };
            string sqlQuery = $"INSERT INTO {tableName} (nombre_doctor, correo, direccion)VALUES(@nombre_doctor, @correo, @direccion)";
            var rows = await connection.ExecuteAsync(sqlQuery, agregarDoctor);
            return doctor;
        }

        public async Task<List<Doctor>> ObtenerListaDoctores()
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<Doctor>(sqlQuery);
            connection.Close();
            return result.ToList();
        }

        public async Task<Doctor> ObtenerDoctorPorId(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName} WHERE id = @id";
            var result = await connection.QuerySingleAsync<Doctor>(sqlQuery, new { id });
            connection.Close();
            return result;
        }


    }
}
