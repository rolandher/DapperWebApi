using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.PuertaEntrada.Repositorio
{
    public interface IPacienteRepositorio
    {
        Task<Paciente> AgregarPaciente(Paciente paciente);
        Task<List<Paciente>> ObtenerListaPacientes();        

        Task<Paciente> ObtenerPacientePorId(int id);
    }
}
