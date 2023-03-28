using AutoMapper;
using DrivenAdapterMongoDb.EntidadesMongo;
using DrivenAdapterMongoDb.Interfaces;
using Entities.Entities;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
            return paciente;
        }

        public async Task<List<Paciente>> ObtenerListaPacientes()
        {
            var pacientes = await _coleccion.FindAsync(Builders<EntidadPaciente>.Filter.Empty);
            var listaPacientes = pacientes.ToEnumerable().Select(paciente => _mapper.Map<Paciente>(paciente)).ToList();
            return listaPacientes;

        }

        public async Task<Paciente> ObtenerPacientePorId(string id)
        {
            var obtenerPacientePorId = await _coleccion.FindAsync(Builders<EntidadPaciente>.Filter.Eq("Id", id));
            var paciente = obtenerPacientePorId.FirstOrDefault();
            return _mapper.Map<Paciente>(paciente);

        }

        public async Task<Paciente> ActualizarPaciente(Paciente paciente)
        {
            var actualizarPaciente = _mapper.Map<EntidadPaciente>(paciente);
            await _coleccion.ReplaceOneAsync(Builders<EntidadPaciente>.Filter.Eq("Id", paciente.Id), actualizarPaciente);
            return paciente;
        }
        
    }
}
