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
    public class RecetaMedicaCasoDeUso : IRecetaMedicaUseCase
    {
        private readonly IPacienteUseCase _pacienteUseCase;
        private readonly IDoctorUseCase _doctorUseCase;
        private readonly IRecetaMedicaRepositorio _recetaMedicaRepositorio;

        public RecetaMedicaCasoDeUso(IPacienteUseCase pacienteUseCase, IDoctorUseCase doctorUseCase, IRecetaMedicaRepositorio recetaMedicaRepositorio)
        {
            _pacienteUseCase = pacienteUseCase;
            _doctorUseCase = doctorUseCase;
            _recetaMedicaRepositorio = recetaMedicaRepositorio;
        }

        public async Task<RecetaMedica> AgregarRecetaMedica(RecetaMedica recetaMedica)
        {
            var paciente = await _pacienteUseCase.AgregarPaciente(recetaMedica.Paciente);
            var doctor = await _doctorUseCase.AgregarDoctor(recetaMedica.Doctor);

            if (paciente == null)
            {
                throw new Exception("El paciente no existe");
            }

            if (doctor == null)
            {
                throw new Exception("El doctor no existe");
            }

            return await _recetaMedicaRepositorio.AgregarRecetaMedica(recetaMedica);
        }

        public async Task<List<RecetaMedica>> ObtenerListaRecetaMedica(int id)
        {
            return await _recetaMedicaRepositorio.ObtenerListaRecetaMedica(id);
        }
    }
}
