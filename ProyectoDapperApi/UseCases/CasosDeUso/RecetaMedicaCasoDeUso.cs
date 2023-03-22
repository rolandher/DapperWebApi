using Entities.Entidades;
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
            return await _recetaMedicaRepositorio.AgregarRecetaMedica(recetaMedica);
        }

        public async Task<RecetaMedicaPaciente> ObtenerListaRecetaMedica(int id)
        {
            return await _recetaMedicaRepositorio.ObtenerListaRecetaMedica(id);
        }
    }
}
