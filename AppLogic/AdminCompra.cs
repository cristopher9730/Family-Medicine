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
    internal class AdminCompra
    {

        public AdminCompra()
        {

        }

        public string CrearCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            compraCrud.Crear(compra);
            return "Compra creado correctamente en base de datos";
        }

        public string EditarCompra(Compra compra)
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            compraCrud.Actualizar(compra);
            return "Compra actualizado correctamente en base de datos";
        }

        public string EliminarCompra()
        {
            return "TBD";
        }

        public List<Compra> DevolverTodosCompras()
        {
            CompraCrudFactory compraCrud = new CompraCrudFactory();
            return compraCrud.ListarTodos<Compra>();
        }

    }
}
