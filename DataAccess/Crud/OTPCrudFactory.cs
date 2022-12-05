using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.Crud
{
    public class OTPCrudFactory : CrudFactory
    {
        private OTPMapper mapper;

        public OTPCrudFactory() : base()
        {
            mapper = new OTPMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var otp = (OTP)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(otp);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var otp = (OTP)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(otp);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var otp = (OTP)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(otp);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsOTP = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsOTP)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override T ListarPorID<T>(int UsuarioId)
        {


            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarPorId(UsuarioId));

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                dicc = listResult[0];
                var objsOTP = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsOTP, typeof(T));


            }
            return default(T);


        }

        public  T ListarPorID2<T>(int CodigoOTP, string UsuarioId)
        {


            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarPorId2(CodigoOTP, UsuarioId));

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                dicc = listResult[0];
                var objsOTP = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsOTP, typeof(T));


            }
            return default(T);


        }

    }
}
