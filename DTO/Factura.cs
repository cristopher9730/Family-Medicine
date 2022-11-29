using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Factura : EntidadBase
    {
        public int FacturaId { get; set; }
        public double Subtotal { get; set; }
        public double Iva { get; set; }
        public int CompraId { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; }
    }
}
