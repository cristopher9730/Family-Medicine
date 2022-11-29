using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Membresia : EntidadBase
    {
        public int MembresiaId { get; set; }
        public string NombreMembresia { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }

    /*[NombreMemebresia] se escribio mal en la base de datos **/
    }
}
