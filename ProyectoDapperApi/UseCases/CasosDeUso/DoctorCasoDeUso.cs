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
    public class DoctorCasoDeUso : IDoctorUseCase
    {
        private readonly IDoctorRepositorio _doctorRepositorio;

        public DoctorCasoDeUso(IDoctorRepositorio doctorRepositorio)
        {
            _doctorRepositorio = doctorRepositorio;
        }

        public async Task<Doctor> AgregarDoctor(Doctor doctor)
        {
            return await _doctorRepositorio.AgregarDoctor(doctor);
        }

        public async Task<List<Doctor>> ObtenerListaDoctores()
        {
            return await _doctorRepositorio.ObtenerListaDoctores();
        }

        public async Task<Doctor> ObtenerDoctorPorId(int id)
        {
            return await _doctorRepositorio.ObtenerDoctorPorId(id);
        }
    }
}
