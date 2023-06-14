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
    public class AdminMembresia
    {


        public AdminMembresia()
        {

        }

        public string CrearMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            membresiaCrud.Crear(membresia);
            return "Membresia creada correctamente en base de datos";
        }

        public string EditarMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            membresiaCrud.Actualizar(membresia);
            return "Membresia actualizada correctamente en base de datos";
        }

        public string EliminarMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            membresiaCrud.Eliminar(membresia);
            return "Membresia eliminada correctamente en base de datos";
        }

        public List<Membresia> DevolverTodasMembresias()
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();
            return membresiaCrud.ListarTodos<Membresia>();
        }

        public Membresia DevolverUnaMembresia(Membresia membresia)
        {
            MembresiaCrudFactory membresiaCrud = new MembresiaCrudFactory();

            return membresiaCrud.ListarPorID<Membresia>(membresia.MembresiaId);
        }

    }
}
