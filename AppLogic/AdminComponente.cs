using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminComponente
    {
        public AdminComponente()
        {

        }

        public string CrearComponente(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            componenteCrud.Crear(componente);
            return "Componente creado correctamente en base de datos";
        }

        public string EditarUsuario(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            componenteCrud.Actualizar(componente);
            return "Componente actualizado correctamente en base de datos";
        }

        public string EliminarUsuario(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            componenteCrud.Eliminar(componente);
            return "Componente eliminado correctamente en base de datos";

        }

        public List<Horario> DevolverTodosUsuarios()
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            return componenteCrud.ListarTodos<Horario>();
        }

        public Componente DevolverUnUsuario(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            return componenteCrud.ListarPorID<Componente>(componente.ComponenteId);
        }
    }
}
