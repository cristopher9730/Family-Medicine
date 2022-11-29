﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccess;
using DataAccess.Crud;

namespace AppLogic
{
    internal class AdminRol
    {

        public AdminRol()
        {

        }

        public string CrearRol(Rol rol)
        {
            RolCrudFactory rolCrud = new RolCrudFactory();
            rolCrud.Crear(rol);
            return "Rol creado correctamente en base de datos";
        }

        public string EditarRol(Rol rol)
        {
            RolCrudFactory rolCrud = new RolCrudFactory();
            rolCrud.Actualizar(rol);
            return "Rol actualizado correctamente en base de datos";
        }

        public string EliminarRol()
        {
            return "TBD";
        }

        public List<Rol> DevolverTodosRoles()
        {
            RolCrudFactory rolCrud = new RolCrudFactory();
            return rolCrud.ListarTodos<Rol>();
        }


    }
}
