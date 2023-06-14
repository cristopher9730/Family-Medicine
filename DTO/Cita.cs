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
        public int ClienteId { get; set; }
        public int LaboratorioId { get; set; }
        public int ExamenId { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int HorarioId { get; set; }
        public string Estado { get; set; }
    }
}
