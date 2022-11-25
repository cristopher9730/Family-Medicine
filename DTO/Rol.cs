using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Rol : EntidadBase
    {
        public int RolId { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
    }
}
