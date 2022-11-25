using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OTP:EntidadBase
    {
        public int usuarioId { get; set; }
        public int usuarioCodigo { get; set; }

        public DateTime fechaHoraCreacion { get; set; } 

        public string estado { get; set; }
    }
}
