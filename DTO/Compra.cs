using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Compra : EntidadBase
    {
        public int ClienteId { get; set; }
        public List<Examen> CantidadProdocutos { get; set; }
        public Cita Cita { get; set; }
        public string FechaPedido { get; set; }
        public string Promociones { get; set; }
    }
}
