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
    public class AdminCita
    {
        public AdminCita()
        {

        }

        public string CrearCita(Cita cita)
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            citaCrud.Crear(cita);
            return "Cita creada correctamente en base de datos";
        }

        public string EditarCita(Cita cita)
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            citaCrud.Actualizar(cita);
            return "Cita actualizada correctamente en base de datos";
        }

        public string EliminarCita(Cita cita)
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            citaCrud.Eliminar(cita);
            return "Cita borrada correctamente en base de datos";
        }

        public List<Cita> DevolverTodosCitas()
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            return citaCrud.ListarTodos<Cita>();
        }

        public Cita DevolverUnaCita(Cita cita)
        {
            ComponenteCrudFactory citaCrud = new ComponenteCrudFactory();
            return citaCrud.ListarPorID<Cita>(cita.CitaId);
        }

    }
}
