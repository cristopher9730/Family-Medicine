using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Examen
    {
        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public string Descripccion { get; set; }
        public string Laboratorio { get; set; }
        public float Precio { get; set; }
    }
}
