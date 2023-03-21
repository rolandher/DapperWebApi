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
        Task<List<Paciente>> ObtenerListaPacientes();
        Task<Paciente> AgregarPaciente(Paciente paciente);
    }
}
