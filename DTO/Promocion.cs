using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Promocion : EntidadBase
    {
        public int PromocionId { get; set; }
        public string PromocionDescripcion { get; set; }
        public double Descuento { get; set; }
        public int LaboratorioId { get; set; }
        public string EstadoPromocion { get; set; }
        public int UsuarioId { get; set; }
    }
}
