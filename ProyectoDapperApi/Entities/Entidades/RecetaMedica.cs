using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class RecetaMedica
    {
        public int Id { get; set; }
        public string Nombre_Medicina { get; set; }

        public string Cantidad { get; set; }

        public int Id_Paciente { get; set; }

        public Paciente Paciente { get; set; }

        public int Id_Doctor { get; set; }
        public Doctor Doctor { get; set; }
    }
}
