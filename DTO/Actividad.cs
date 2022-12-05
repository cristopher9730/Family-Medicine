using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Actividad : EntidadBase
    {
        public int ActividadId { get; set; }
        public string NombreActividad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CreacionUsuarioId { get; set; }
    }
}
