using Entities.Comandos;
using Entities.Entidades;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.PuertaEntrada
{
    public interface IRecetaMedicaUseCase
    {
        Task<RecetaMedica> AgregarRecetaMedica(RecetaMedica recetaMedica);
        Task<RecetaMedicaPaciente> ObtenerListaRecetaMedica(int id);
    }
}
