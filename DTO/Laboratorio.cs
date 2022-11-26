using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Laboratorio : EntidadBase
    {
        public int LaboratorioId { get; set; }
        public string CedulaJuridica { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string PaginaWeb { get; set; }
        public string RedesSociales { get; set; }
        public string Correo { get; set; }
        public string Fotografias { get; set; }
        public string Estado { get; set; }
    }
}
