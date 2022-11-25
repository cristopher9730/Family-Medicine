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
    public class AdminUsuario
    {
        public AdminUsuario()
        {

        }

        public string CrearUsuario(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.Crear(usuario);
            return "Usuario creado correctamente en base de datos";
        }

        public string EditarUsuario(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.Actualizar(usuario);
            return "Usuario actualizado correctamente en base de datos";
        }

        public string EliminarUsuario()
        {
            return "TBD";
        }

        public List<Usuario> DevolverTodosUsuarios()
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            return usuarioCrud.ListarTodos<Usuario>();
        }

        public Usuario DevolverUnUsuario(Usuario usuarioId)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            //return usuarioCrud.ListarUnUsuario(usuarioid);
            return null;
        }

    }
}
