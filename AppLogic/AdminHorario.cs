using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminHorario
    {
        public AdminHorario()
        {

        }

        public string CrearHorario(Horario horario)
        {
            HorarioCrudFactory horarioCrud = new HorarioCrudFactory();
            horarioCrud.Crear(horario);
            return "Horario creado correctamente en base de datos";
        }

        public string EditarHorario(Horario horario)
        {
            HorarioCrudFactory horarioCrud = new HorarioCrudFactory();
            horarioCrud.Actualizar(horario);
            return "Horario actualizado correctamente en base de datos";
        }

        public string EliminarHorario(Horario horario)
        {
            HorarioCrudFactory horarioCrud = new HorarioCrudFactory();
            horarioCrud.Eliminar(horario);
            return "Horario eliminado correctamente en base de datos";

        }

        public List<Horario> DevolverTodosHorarios()
        {
            HorarioCrudFactory horarioCrud = new HorarioCrudFactory();
            return horarioCrud.ListarTodos<Horario>();
        }

        public Horario DevolverUnHorario(Horario horario)
        {
            HorarioCrudFactory horarioCrud = new HorarioCrudFactory();

            return horarioCrud.ListarPorID<Horario>(horario.HorarioId);
        }
    }
}
