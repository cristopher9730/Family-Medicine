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

        public string EditarComponente(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            componenteCrud.Actualizar(componente);
            return "Componente actualizado correctamente en base de datos";
        }

        public string EliminarComponente(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            componenteCrud.Eliminar(componente);
            return "Componente eliminado correctamente en base de datos";

        }

        public List<Componente> DevolverTodosComponentes()
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            return componenteCrud.ListarTodos<Componente>();
        }

        public Componente DevolverUnComponente(Componente componente)
        {
            ComponenteCrudFactory componenteCrud = new ComponenteCrudFactory();
            return componenteCrud.ListarPorID<Componente>(componente.ComponenteId);
        }
    }
}
