using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OTP:EntidadBase
    {
        //public int SesionUsuarioId { get; set; }
        public int OTPId { get; set; }
        public int CodigoOTP { get; set; }
        public int CreacionUsuario { get; set; }
        public int InactivacionUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInactivacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Estado { get; set; }
    }
}
