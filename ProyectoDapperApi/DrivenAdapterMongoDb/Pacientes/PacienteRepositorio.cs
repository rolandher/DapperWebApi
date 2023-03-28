using AutoMapper;
using DrivenAdapterMongoDb.EntidadesMongo;
using DrivenAdapterMongoDb.Interfaces;
using Entities.Comandos;
using Entities.Entities;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UseCases.PuertaEntrada.Repositorio;
using static DrivenAdapterMongoDb.Pacientes.PacienteRepositorio;

namespace DrivenAdapterMongoDb.Pacientes
{
      public class PacienteRepositorio : IPacienteRepositorio
        {
            private readonly IMongoCollection<EntidadPaciente> _coleccion;
            private readonly IMapper _mapper;

            public PacienteRepositorio(IContext context, IMapper mapper)
            {
                this._coleccion = context.Pacientes;
                _mapper = mapper;
            }

        public async Task<Paciente> AgregarPaciente(Paciente paciente)
        {
            var agregarPaciente = _mapper.Map<EntidadPaciente>(paciente);
            await _coleccion.InsertOneAsync(agregarPaciente);

            if (agregarPaciente == null)
            {
                throw new Exception($"por favor agrege informacion del paciente");
            }
            return paciente;
        }

        public async Task<List<Paciente>> ObtenerListaPacientes()
        {
            var pacientes = await _coleccion.FindAsync(Builders<EntidadPaciente>.Filter.Empty);
            var listaPacientes = pacientes.ToEnumerable().Select(paciente => _mapper.Map<Paciente>(paciente)).ToList();

            if (pacientes == null)
            {
                throw new Exception($"Ingrese la informacion necesaria.");
            }
            return listaPacientes;

        }

        //public async Task<Paciente> ObtenerPacientePorId(string id)
        //{
        //    var obtenerPacientePorId = await _coleccion.FindAsync(Builders<EntidadPaciente>.Filter.Eq("Id", id));
        //    var paciente = obtenerPacientePorId.FirstOrDefault();
        //    return _mapper.Map<Paciente>(paciente);
        //}

        public async Task<Paciente> ActualizarPaciente(ActualizarPaciente actualizarPaciente, string id)
        {
            var filter = Builders<EntidadPaciente>.Filter.Eq(paciente => paciente.Id_Mongo, id);
            var actualizar = await _coleccion.Find(filter).FirstOrDefaultAsync();

            if (actualizar == null)
            {
                throw new Exception($"Marca con id {id} no encontrado.");
            }

            actualizar.Nombre = actualizarPaciente.Nombre;
            actualizar.Fecha_Nacimiento = actualizarPaciente.Fecha_Nacimiento;
            actualizar.Sexo = actualizarPaciente.Sexo;
            var actualizarPacient = await _coleccion.ReplaceOneAsync(filter, actualizar);

            if (actualizarPacient.ModifiedCount == 0)
            {
                throw new Exception($"No se pudo actualizar el paciente.");
            }

            return _mapper.Map<Paciente>(actualizar);

        }

        public async Task<Paciente> EliminarPaciente(string id)
        {
            var filter = Builders<EntidadPaciente>.Filter.Eq(paciente => paciente.Id_Mongo, id);
            var eliminar = await _coleccion.Find(filter).FirstOrDefaultAsync();

            if (eliminar == null)
            {
                throw new Exception($"paciente con id {id} no encontrado.");
            }

            var eliminarPaciente = await _coleccion.DeleteOneAsync(filter);

            if (eliminarPaciente.DeletedCount == 0)
            {
                throw new Exception($"No se pudo eliminar el paciente.");
            }

            return _mapper.Map<Paciente>(eliminar);
        }
      }
}
