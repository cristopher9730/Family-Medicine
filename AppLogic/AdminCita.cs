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
    internal class AdminCita
    {
        public AdminCita()
        {

        }

        public string CrearCita(Cita cita)
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            citaCrud.Crear(cita);
            return "Cita creado correctamente en base de datos";
        }

        public string EditarCita(Cita cita)
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            citaCrud.Actualizar(cita);
            return "Cita actualizado correctamente en base de datos";
        }

        public string EliminarCita()
        {
            return "TBD";
        }

        public List<Cita> DevolverTodosCitas()
        {
            CitaCrudFactory citaCrud = new CitaCrudFactory();
            return citaCrud.ListarTodos<Cita>();
        }

    }
}
