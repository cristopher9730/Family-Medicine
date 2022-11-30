using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccess;
using DataAccess.Crud;

namespace AppLogic
{
    public class AdminCompra
    {

        public AdminCompra()
        {

        }

        public string CrearCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            compraCrud.Crear(compra);
            return "Compra creada correctamente en base de datos";
        }

        public string EditarCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            compraCrud.Actualizar(compra);
            return "Compra actualizada correctamente en base de datos";
        }

        public string EliminarCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            compraCrud.Eliminar(compra);
            return "Compra Eliminada correctamente en base de datos";
        }

        public List<Compra> DevolverTodosCompras()
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            return compraCrud.ListarTodos<Compra>();
        }
        public Compra DevolverUnaCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();

            return compraCrud.ListarPorID<Compra>(compra.CompraId);
        }

    }
}
