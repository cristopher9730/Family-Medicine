using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Usuario: EntidadBase
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Clave { get; set; }
        public string Foto { get; set; }
        public string Estado { get; set; }
        public int RolId { get; set; }
        public int LaboratorioId { get; set; }
        public int MembresiaId { get; set; }
        public string Codigo { get; set; }

    }
}
