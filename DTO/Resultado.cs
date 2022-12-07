using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Resultado : EntidadBase
    {
        public int ResultadoId { get; set; }
        public int CitaId { get; set; }
        public int ExamenId { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public double Resultado { get; set; }
        public int LaboratorioId { get; set; }
        public string Estado { get; set; }
    }
}
