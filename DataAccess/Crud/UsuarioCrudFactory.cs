using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class UsuarioCrudFactory : CrudFactory
    {
        private UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
            
        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objsUsuario = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsUsuario)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override T ListarPorID<T>(int id)
        {
            throw new NotImplementedException();
        }

        /*
         El metodo login recibe un objeto usuario con el correo y la clave dentro de si mismo 
        El metodo procede a encriptar la clave dentro del objeto usuario y utiliza al objeto mapper para convertir al usuario en una operacion sql 
        La operacion sql se ingresa como parametro al metodo de dao para ejectuar el procedimiento almacenado de login y se guarda la respuesta en la variable resultado. 
        Se devuelve la variable resultado que en este caso, contiene el id del usuario en caso de ser encontrado y 0 si no es encontrado 
         */
        public int Login(Usuario oUsuario)
        {
            oUsuario.Clave = ConvertirSha256(oUsuario.Clave);
            var correo = oUsuario.Correo;
            var resultado = dao.ExectuteStoreProcedureWithQueryLogin(mapper.Login(oUsuario));
            //var objUsuario = new Usuario();
            //idUsuario = Mapper.BuildObjectLogin(resultado);
            return resultado;
        }


        /*
         Este metodo sirve para convertir texto en encriptacion SHA256 
        Retorna un string encriptado 
         */
        public static string ConvertirSha256(string texto)
        {
            //using Sytem.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

    }
}
