using Entities.Comandos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.PuertaEntrada;
using UseCases.PuertaEntrada.Repositorio;

namespace UseCases.CasosDeUso
{
    public class PacienteCasoDeUso : IPacienteUseCase
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteCasoDeUso(IPacienteRepositorio pacienteRepositorio)
        {
            _pacienteRepositorio = pacienteRepositorio;
        }

        public async Task<Paciente> AgregarPaciente(Paciente paciente)
        {
            return await _pacienteRepositorio.AgregarPaciente(paciente);
        }

        public async Task<List<Paciente>> ObtenerListaPacientes()
        {
            return await _pacienteRepositorio.ObtenerListaPacientes();
        }       

        //public async Task<Paciente> ObtenerPacientePorId(string id)
        //{
        //    return await _pacienteRepositorio.ObtenerPacientePorId(id);
        //}

        public async Task<Paciente> ActualizarPaciente(ActualizarPaciente actualizarPaciente, string id)
        {
            return await _pacienteRepositorio.ActualizarPaciente(actualizarPaciente, id);
        }     

        public async Task<Paciente> EliminarPaciente(string id)
        {
            return await _pacienteRepositorio.EliminarPaciente(id);
        }
             

       
    }
   
}
