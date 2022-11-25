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
    internal class AdminMembresia
    {


        public AdminMembresia()
        {

        }

        public string CrearMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            membresiaCrud.Crear(membresia);
            return "Membresia creado correctamente en base de datos";
        }

        public string EditarMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            membresiaCrud.Actualizar(membresia);
            return "Membresia actualizado correctamente en base de datos";
        }

        public string EliminarMembresia()
        {
            return "TBD";
        }

        public List<Membresia> DevolverTodasMembresias()
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            return membresiaCrud.ListarTodos<Membresia>();
        }

    }
}
