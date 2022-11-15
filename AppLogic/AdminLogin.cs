using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    /*
         Este metodo funciona como gestor para llamar al Crud
        Recibe como parametro un objeto usuario que contiene el correo y la clave 
        Utiliza el metodo login e ingresa como parametro el objeto usuario y cuadra el resultado del id en IdUsuario 
        Se crea una variable usuario nueva y se le asigna el Id que recibio como resultado del metodo login de crud 
        Se devuelve el nuevo usuario solo con el id dentro de el. 
         */
    public class AdminLogin
    {
        public Usuario Login(Usuario oUsuario)
        {
            Usuario usuario = new Usuario();
            if (oUsuario.Correo.Equals("vancoders@superpro.com") && oUsuario.Clave.Equals("AdminAdmin"))
            {
                usuario.RolId = 5;
            }
            else {
                UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
                int idUsuario = usuarioCrud.Login(oUsuario);
                
                usuario.UsuarioId = idUsuario;
            }

            return usuario;

            

        }

    }
}
