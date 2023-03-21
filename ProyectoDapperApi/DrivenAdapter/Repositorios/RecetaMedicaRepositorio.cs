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
    public class RecetaMedicaRepositorio : IRecetaMedicaRepositorio
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "recetaMedica";

        public RecetaMedicaRepositorio(IDbConnectionBuilder dbConnectionBuilder)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
        }

        public async Task<RecetaMedica> AgregarRecetaMedica(RecetaMedica recetaMedica)
        {


            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            
            var agregarRecetaMedica = new
            {
                nombre_medicina = recetaMedica.Nombre_Medicina,
                cantidad = recetaMedica.Cantidad,
                id_paciente = recetaMedica.Id_Paciente,
                id_doctor = recetaMedica.Id_Doctor
            };
            string sqlQuery = $"INSERT INTO {tableName} (nombre_medicina, cantidad, id_paciente, id_doctor)VALUES(@nombre_medicina, @cantidad, @id_paciente, @id_doctor)";
            var rows = await connection.ExecuteAsync(sqlQuery, agregarRecetaMedica);
            return recetaMedica;
           
        }

        public async Task<List<RecetaMedica>> ObtenerListaRecetaMedica(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            string sqlQuery = $"SELECT * FROM {tableName}";
            var result = await connection.QueryAsync<RecetaMedica>(sqlQuery);
            connection.Close();
            return result.ToList();
        }


    }
}
