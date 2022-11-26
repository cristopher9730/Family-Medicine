using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Cita : EntidadBase
    {
        public int CitaId { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int LaboratorioId { get; set; }
        public int Cupo { get; set; }
        public string Estado { get; set; }
        public int PersonaEmpleadoId { get; set; }
        public int PersonaClienteId { get; set; }
    }
}
