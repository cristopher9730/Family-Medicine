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

        public string EditarUsuarioCliente(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.ActualizarCliente(usuario);
            return "Usuario cliente actualizado correctamente en base de datos";
        }

        public string RecuperarClave(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.RecuperarClave(usuario);
            return "La clave ha sido actualizada con temporal";
        }

        public string RecuperarOTP(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.RecuperarOTP(usuario);
            return "El OTP ha sido actualizado con exito";
        }

        public string EliminarUsuario(Usuario usuario)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            usuarioCrud.Eliminar(usuario);
            return "Usuario eliminado correctamente en base de datos";

        }

        public List<Usuario> DevolverTodosUsuarios()
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            return usuarioCrud.ListarTodos<Usuario>();
        }

        public List<Usuario> DevolverTodosUsuariosPorId(int id)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            return usuarioCrud.ListarTodosPorId<Usuario>(id);
        }

        public Usuario DevolverUnUsuario(Usuario usuarioId)
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
             
            return usuarioCrud.ListarPorID<Usuario>(usuarioId.UsuarioId);
        }

    }
}
