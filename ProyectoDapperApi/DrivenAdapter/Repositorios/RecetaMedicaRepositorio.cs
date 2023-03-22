using Dapper;
using DrivenAdapter.PuertaEnlace;
using Entities.Entidades;
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

        public async Task<RecetaMedicaPaciente> ObtenerListaRecetaMedica(int id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var recetaQuery = $"SELECT * FROM {tableName} WHERE id = @id";
            var doctorQuery =  $"SELECT * FROM Doctores WHERE id = @id";
            var pacienteQuery = $"SELECT * FROM pacientes WHERE id = @id";
            var multiQuery = $"{recetaQuery};{doctorQuery};{pacienteQuery}";

            using (var multi = await connection.QueryMultipleAsync(multiQuery, new { id }))
            {
                var receta = await multi.ReadFirstOrDefaultAsync<RecetaMedica>();
                var doctor = await multi.ReadFirstOrDefaultAsync<Doctor>();
                var paciente = await multi.ReadFirstOrDefaultAsync<Paciente>();

                return new RecetaMedicaPaciente
                {
                    Id = receta.Id,
                    Nombre_Medicina = receta.Nombre_Medicina,
                    Cantidad = receta.Cantidad,
                    Doctor = doctor,                    
                    Paciente = paciente,
                    
                };             
                   
               
            }
        }


    }
}
