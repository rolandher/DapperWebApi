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
            var registrarPaciente = _mapper.Map<EntidadPaciente>(paciente);
            await _coleccion.InsertOneAsync(registrarPaciente);
            return paciente;
        }

        public async Task<List<Paciente>> ObtenerListaPacientes()
        {
            var pacientes = await _coleccion.FindAsync(Builders<EntidadPaciente>.Filter.Empty);
            var listaPacientes = pacientes.ToEnumerable().Select(paciente => _mapper.Map<Paciente>(paciente)).ToList();
            return listaPacientes;

        }

        public Task<Paciente> ObtenerPacientePorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
