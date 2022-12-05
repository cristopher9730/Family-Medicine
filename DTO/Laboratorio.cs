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
        public int UsuarioPropietarioId { get; set; }
        public string NombreLaboratorio { get; set; }
        public string SedeLaboratorio { get; set; }
        public string Telefono { get; set; }
        public string CorreoLaboratorio { get; set; }
        public string Direccion { get; set; }
        public string CedulaJuridica { get; set; }
        public string RazonSocial { get; set; }
        public string Estado { get; set; }
        public string PaginaWeb { get; set; }
        public string RedSocial { get; set; }
        
    }
}
