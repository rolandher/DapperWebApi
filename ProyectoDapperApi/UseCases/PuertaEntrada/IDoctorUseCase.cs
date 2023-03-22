using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.PuertaEntrada
{
    public interface IDoctorUseCase
    {
        Task<List<Doctor>> ObtenerListaDoctores();
        Task<Doctor> AgregarDoctor(Doctor doctor);

        Task<Doctor> ObtenerDoctorPorId(int id);
    }
}
