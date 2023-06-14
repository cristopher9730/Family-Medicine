using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Compra : EntidadBase
    {
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public int CitaId { get; set; }
        public int FacturaId { get; set; }
        public int LaboratorioId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Estado { get; set; }
    }
}
