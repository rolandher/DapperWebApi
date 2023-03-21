using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.PuertaEntrada.Repositorio
{
    public interface IRecetaMedicaRepositorio
    {
        Task<RecetaMedica> AgregarRecetaMedica(RecetaMedica recetaMedica);
        Task<List<RecetaMedica>> ObtenerListaRecetaMedica(int id);
    }
}
