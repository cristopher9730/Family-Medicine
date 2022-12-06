using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyMedicine.Models
{
    public class LaboratorioModel
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