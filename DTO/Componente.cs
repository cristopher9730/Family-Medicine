using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Componente : EntidadBase
    {
        public int LaboratorioId { get; set; }
        public string NombreComponente { get; set; }

        public string SimboloMedida { get; set; }

        public double MedidaReferencia { get; set; }

        public int ExamenId { get; set; }

        public string Estado { get; set; }
    }
}
