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
    public class AdminExamen
    {

        public AdminExamen()
        {

        }

        public string CrearExamen(Examen examen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            examenCrud.Crear(examen);
            return "Examen creado correctamente en base de datos";
        }

        public string EditarExamen(Examen examen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            examenCrud.Actualizar(examen);
            return "Examen actualizado correctamente en base de datos";
        }

        public string EliminarExamen(Examen examen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            examenCrud.Eliminar(examen);
            return "Examen eliminado correctamente en base de datos";
        }

        public List<Examen> DevolverTodosExamenes()
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            return examenCrud.ListarTodos<Examen>();
        }

        public List<Examen> DevolverTodosExamenesPorId(int id)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            return examenCrud.ListarTodosPorId<Examen>(id);
        }

        public Examen DevolverUnExamen(Examen examen)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();

            return examenCrud.ListarPorID<Examen>(examen.identificacion);
        }

    }
}
