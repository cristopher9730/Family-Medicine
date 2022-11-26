﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Examen : EntidadBase
    {
        public int ExamenId { get; set; }
        public string NombreExamen { get; set; }
        public int Precio { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int LaboratorioId { get; set; }

    }
}
