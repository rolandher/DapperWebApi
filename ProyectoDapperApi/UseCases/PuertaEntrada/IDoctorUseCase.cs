﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.PuertaEntrada
{
    public interface IDoctorUseCase
    {

        Task<Doctor> AgregarDoctor(Doctor doctor);
        Task<List<Doctor>> ObtenerListaDoctores();        

        Task<Doctor> ObtenerDoctorPorId(int id);
    }
}
