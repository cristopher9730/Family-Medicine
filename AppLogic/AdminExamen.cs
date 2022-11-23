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
    internal class AdminExamen
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

        public string EliminarExamen()
        {
            return "TBD";
        }

        public List<Usuario> DevolverTodosExamenes()
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            return examenCrud.ListarTodos<Examen>();
        }

    }
}
