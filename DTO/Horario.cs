using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Horario : EntidadBase
    {
        public int HorarioId { get; set; }
        public DateTime Dia { get; set; }
        public int HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int ExamenId { get; set; }
        public int Cupos { get; set; }
        public int LaboratorioId { get; set; }
        public string Estado { get; set; }

    }
}
