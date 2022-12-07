using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyMedicine.Models
{
    public class CarritoModel
    {
        public int ExamenId { get; set; }
        public string Nombre { get; set; }
        public string NombreInterno { get; set; }
        public double Precio { get; set; }
        public int LaboratorioId { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public int Ventas { get; set; }
    }
}