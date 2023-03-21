using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Comandos
{
    public class IngresarRecetaMedica
    {
        public string Nombre_Medicina { get; set; }

        public string Cantidad { get; set; }

        public int Id_Paciente { get; set; }

        public int Id_Doctor { get; set; }
    }
}
