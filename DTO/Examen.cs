using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Examen : EntidadBase
    {
        public int SesionUsuarioId { get; set; } // Borrar si genera conflictos en otras partes
        public int ExamenId { get; set; }
        public string Nombre { get; set; }
        public string NombreInterno { get; set; }
        public double Precio { get; set; }
        public int LaboratorioId { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int Ventas { get; set; }
    }
}
