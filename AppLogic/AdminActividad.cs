using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud;

namespace AppLogic
{
    public class AdminActividad
    {
        public AdminActividad()
        {

        }

        public string CrearActividad(Actividad actividad)
        {
            ActividadCrudFactory actividadCrud = new ActividadCrudFactory();
            actividadCrud.Crear(actividad);
            return "Actividad creada correctamente en base de datos";
        }

        public string EditarActividad(Actividad actividad)
        {
            ActividadCrudFactory actividadCrud = new ActividadCrudFactory();
            actividadCrud.Actualizar(actividad);
            return "Actividad actualizada correctamente en base de datos";
        }

        public string EliminarActividad(Actividad actividad)
        {
            ActividadCrudFactory actividadCrud = new ActividadCrudFactory();
            actividadCrud.Eliminar(actividad);
            return "Actividad eliminada correctamente en base de datos";
        }

        public List<Actividad> DevolverTodasActividades()
        {
            ActividadCrudFactory actividadCrud = new ActividadCrudFactory();
            return actividadCrud.ListarTodos<Actividad>();
        }

        public Actividad DevolverUnaActividad(Actividad actividad)
        {
            ActividadCrudFactory actividadCrud = new ActividadCrudFactory();

            return actividadCrud.ListarPorID<Actividad>(actividad.ActividadId);
        }
    }
}
