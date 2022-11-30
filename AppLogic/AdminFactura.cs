using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminFactura
    {
        public AdminFactura()
        {

        }

        public string CrearFactura(Factura factura)
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
            facturaCrud.Crear(factura);
            return "Factura creada correctamente en base de datos";
        }

        public string EditarFactura(Factura factura)
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
            facturaCrud.Actualizar(factura);
            return "Factura actualizada correctamente en base de datos";
        }

        public string EliminarFactura(Factura factura)
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
            facturaCrud.Eliminar(factura);
            return "Factura eliminada correctamente en base de datos";
        }

        public List<Factura> DevolverTodasFacturas()
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();
            return facturaCrud.ListarTodos<Factura>();
        }

        public Factura DevolverUnaFactura(Factura factura)
        {
            FacturaCrudFactory facturaCrud = new FacturaCrudFactory();

            return facturaCrud.ListarPorID<Factura>(factura.FacturaId);
        }
    }
}
